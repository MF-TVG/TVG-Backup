using System;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web
{
    public partial class Logout : BasePage
    {
        protected override void InitPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    LoginUtil.Logout();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}