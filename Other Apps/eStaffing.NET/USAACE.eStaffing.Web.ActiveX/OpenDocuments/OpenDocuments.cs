using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using USAACE.eStaffing.Web.ActiveX.ObjectSafety;

namespace USAACE.eStaffing.Web.ActiveX.OpenDocuments
{
    [ProgId("USAACE.eStaffing.Web.ActiveX.OpenDocuments")]
    [Guid("A0562BD3-15D6-9AA0-41BF-0AD6714B5F78")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IOpenDocuments))]
    public class OpenDocuments : IOpenDocuments, IObjectSafety
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

        public OpenDocuments() { }

        [ComVisible(true)]
        bool IOpenDocuments.OpenServerDocument(String documentUrl)
        {
            try
            {
                DialogResult result = MessageBox.Show(String.Format("The system is attempting to load a document from the following location:" +
                    "{1}{1}{0}{1}{1}" + "Are you sure you want to open this document?", documentUrl, Environment.NewLine), 
                    "eStaffing Open Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    String webDavUrl = WebDAVUtil.ConvertUrlToWebDav(documentUrl);

                    Process fileOpenProcess = new Process();
                    fileOpenProcess.StartInfo.FileName = webDavUrl;
                    fileOpenProcess.StartInfo.UseShellExecute = true;
                    fileOpenProcess.Start();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}