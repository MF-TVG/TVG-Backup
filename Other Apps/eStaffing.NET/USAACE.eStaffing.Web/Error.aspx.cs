using System;
using System.Web.UI.WebControls;

namespace USAACE.eStaffing.Web
{
    public partial class Error : BasePage
    {
        protected override void LoadPage()
        {
            View errorView = mvError.FindControl("vw" + this.ErrorCode) as View;

            if (errorView != null)
            {
                mvError.SetActiveView(errorView);
            }
            else
            {
                mvError.ActiveViewIndex = 0;
            }
        }

        private String ErrorCode
        {
            get
            {
                return Request.QueryString["ErrorCode"];
            }
        }
    }
}