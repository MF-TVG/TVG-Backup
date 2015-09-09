using System;
using System.IdentityModel.Services;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web
{
    public partial class Login : BasePage
    {
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlLoginMethod.SelectedValue = LoginUtil.GetDefaultLoginMethod();
                    AttemptLogin();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlLoginMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AttemptLogin();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void AttemptLogin()
        {
            switch (ddlLoginMethod.SelectedValue)
            {
                case "SSO": LoginSSO(); break;
                case "Windows": LoginWindows(); break;
                default: break;
            }
        }

        private void LoginSSO()
        {
            if (LoginUtil.IsLoginSuccessful(AuthenticationTypeConstants.SSO_AUTH_NAME))
            {
                RedirectToReturnUrl();
            }
            else
            {
                WSFederationAuthenticationModule module = FederatedAuthentication.WSFederationAuthenticationModule;
                SignInRequestMessage mess = module.CreateSignInRequest("passive", Request.RawUrl, true);
                mess.Realm = module.Realm;
                Response.Redirect(mess.WriteQueryString(), false);
            }
            
        }

        private void LoginWindows()
        {
            if (LoginUtil.IsLoginSuccessful(AuthenticationTypeConstants.WINDOWS_AUTH_NAME))
            {
                RedirectToReturnUrl();
            }
            else if (Request.Headers["Authorization"] == null)
            {
                Response.StatusCode = 401;
            }
            else
            {
                Response.Redirect("~/Error.aspx?ErrorCode=401", false);
            }
        }

        private void RedirectToReturnUrl()
        {
            LoginUtil.Login(ddlLoginMethod.SelectedValue);
            Response.Redirect(this.ReturnUrl, false);
        }

        private String ReturnUrl
        {
            get
            {
                return !String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? Request.QueryString["ReturnUrl"] : "~/Pages/Dashboard.aspx";
            }
        }
    }
}