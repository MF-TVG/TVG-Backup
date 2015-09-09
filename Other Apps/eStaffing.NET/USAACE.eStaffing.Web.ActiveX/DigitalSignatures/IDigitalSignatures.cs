using System;
using System.Runtime.InteropServices;

namespace USAACE.eStaffing.Web.ActiveX.DigitalSignatures
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IDigitalSignatures
    {
        [DispIdAttribute(0x60020003)]
        String SignData([In, MarshalAs(UnmanagedType.BStr)] String documentDataHash);
    }
}
