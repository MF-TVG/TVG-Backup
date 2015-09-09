using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Business.Util
{
    public static class SignatureUtil
    {
        public static String CalculateFormDataHash(FormData formData)
        {
            return Convert.ToBase64String(GetFormDataHash(formData));
        }

        public static Boolean VerifyFormSignature(FormData formData, ReviewSignature signature)
        {
            Byte[] signatureBytes = Convert.FromBase64String(signature.SignatureData);

            ContentInfo content = new ContentInfo(GetFormDataHash(formData));

            SignedCms signed = new SignedCms(content, true);

            signed.Decode(signatureBytes);

            try
            {
                signed.CheckSignature(false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // FOR TESTING ONLY
        public static Boolean VerifyFormSignature(String data, String signatureData)
        {
            try
            {
                UnicodeEncoding encoding = new UnicodeEncoding();
                SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
                Byte[] formDataBytes = encoding.GetBytes(data);
                Byte[] hashBytes = sha512.ComputeHash(formDataBytes);

                Byte[] signatureBytes = Convert.FromBase64String(signatureData);

                ContentInfo content = new ContentInfo(hashBytes);

                SignedCms signed = new SignedCms(content, true);

                signed.Decode(signatureBytes);
            
                signed.CheckSignature(false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static String GetSignatureName(ReviewSignature signature)
        {
            Byte[] signatureBytes = Convert.FromBase64String(signature.SignatureData);

            SignedCms signed = new SignedCms(new ContentInfo(new Byte[] { }), true);

            signed.Decode(signatureBytes);

            return signed.SignerInfos[0].Certificate.GetNameInfo(X509NameType.SimpleName, false);
        }

        public static Nullable<DateTime> GetSignatureDate(ReviewSignature signature)
        {
            Byte[] signatureBytes = Convert.FromBase64String(signature.SignatureData);

            SignedCms signed = new SignedCms(new ContentInfo(new Byte[] { }), true);

            signed.Decode(signatureBytes);

            try
            {
                foreach (CryptographicAttributeObject cryptoObject in signed.SignerInfos[0].SignedAttributes)
                {
                    foreach (AsnEncodedData data in cryptoObject.Values)
                    {
                        if (data is Pkcs9SigningTime)
                        {
                            return (data as Pkcs9SigningTime).SigningTime;
                        }
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Byte[] GetFormDataHash(FormData formData)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
            Byte[] formDataBytes = encoding.GetBytes(formData.FormDataXML);
            Byte[] hashBytes = sha512.ComputeHash(formDataBytes);

            return hashBytes;
        }
    }
}
