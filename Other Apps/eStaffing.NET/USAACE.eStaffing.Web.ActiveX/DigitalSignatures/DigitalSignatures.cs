using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using USAACE.eStaffing.Web.ActiveX.ObjectSafety;
using System.Security.Cryptography.X509Certificates;

namespace USAACE.eStaffing.Web.ActiveX.DigitalSignatures
{    
    [ProgId("USAACE.eStaffing.Web.ActiveX.DigitalSignatures")]
    [Guid("A0562BD3-15D6-9AA0-41BF-0AD6714B5F79")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IDigitalSignatures))]
    public class DigitalSignatures : IDigitalSignatures, IObjectSafety
    {
        public long GetInterfaceSafetyOptions(ref Guid iid, out int pdwSupportedOptions, out int pdwEnabledOptions)
        {
            pdwEnabledOptions = (Int32)(ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_CALLER | ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_DATA);
            pdwSupportedOptions = (Int32)(ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_CALLER | ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_DATA);
            return 0;
        }

        public long SetInterfaceSafetyOptions(ref Guid iid, int dwOptionSetMask, int dwEnabledOptions)
        {
            return 0;
        }

        public DigitalSignatures() { }

        [ComVisible(true)]
        String IDigitalSignatures.SignData(String documentDataHash)
        {
            try
            {
                DigitalSignatureForm form = new DigitalSignatureForm(documentDataHash);
                form.ShowDialog();

                return form.SignedData;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}