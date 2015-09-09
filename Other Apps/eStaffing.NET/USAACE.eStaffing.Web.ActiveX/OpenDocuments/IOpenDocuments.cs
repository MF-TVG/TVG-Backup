using System;
using System.Runtime.InteropServices;

namespace USAACE.eStaffing.Web.ActiveX.OpenDocuments
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IOpenDocuments
    {
        [DispIdAttribute(0x60020003)]
        bool OpenServerDocument([In, MarshalAs(UnmanagedType.BStr)] String documentUrl);
    }
}
