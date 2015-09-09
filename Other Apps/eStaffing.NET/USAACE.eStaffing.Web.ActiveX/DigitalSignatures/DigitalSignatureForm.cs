using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USAACE.eStaffing.Web.ActiveX.DigitalSignatures
{
    public partial class DigitalSignatureForm : Form
    {
        private String _dataHash;
        private String _signedData = null;
        private X509Certificate2 _selectedCertificate = null;

        internal String SignedData
        {
            get
            {
                return _signedData;
            }
        }

        public DigitalSignatureForm(String dataHash)
        {
            _dataHash = dataHash;
            _signedData = null;
            _selectedCertificate = null;

            InitializeComponent();
        }

        private void DigitalSignatureForm_Load(object sender, EventArgs e)
        {
            
        }

        private void lnkChooseCertificate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                X509Store certificateStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                certificateStore.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection validCollection = certificateStore.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, true);
                X509Certificate2Collection signatureCollection = validCollection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);

                X509Certificate2Collection selectedCertificate =
                    X509Certificate2UI.SelectFromCollection(signatureCollection, "eStaffing Digital Signature",
                    "Please select the digital certificate to be used for the signature.", X509SelectionFlag.SingleSelection);

                _selectedCertificate = selectedCertificate.Count > 0 ? selectedCertificate[0] : null;

                lblCertificateNameValue.Text = _selectedCertificate != null ? _selectedCertificate.GetNameInfo(X509NameType.SimpleName, false) : null;
                lblIssuerNameValue.Text = _selectedCertificate != null ? _selectedCertificate.GetNameInfo(X509NameType.SimpleName, true) : null;
            }
            catch (Exception)
            {

            }
        }

        private Byte[] GetTestData()
        {
            //For testing only

            UnicodeEncoding encoding = new UnicodeEncoding();
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
            Byte[] hashBytes = encoding.GetBytes("Test");
            Byte[] hash = sha512.ComputeHash(hashBytes);

            return hash;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCertificate != null)
                {
                    Byte[] formHash = Convert.FromBase64String(_dataHash);

                    ContentInfo content = new ContentInfo(formHash);

                    SignedCms signed = new SignedCms(content, true);

                    CmsSigner signer = new CmsSigner(_selectedCertificate);
                    signer.SignedAttributes.Add(new Pkcs9SigningTime(DateTime.Now));

                    signed.ComputeSignature(signer, true);

                    _signedData = Convert.ToBase64String(signed.Encode());

                    this.Close();
                }
                else
                {
                    MessageBox.Show("You must select a certificate to sign.", "eStaffing Digital Signature",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem accessing the selected certificate, please try again.", "eStaffing Digital Signature",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
