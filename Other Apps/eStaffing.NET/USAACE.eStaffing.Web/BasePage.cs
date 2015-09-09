using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters;
using USAACE.eStaffing.Presentation.Views;
using USAACE.eStaffing.Web.Enum;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web
{
    public abstract class BasePage : Page, IBasePageView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private BasePagePresenter _basePresenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public BasePagePresenter BasePresenter
        {
            get
            {
                if (_basePresenter == null)
                {
                    _basePresenter = new BasePagePresenter(this);
                }

                return _basePresenter;
            }
        }

        /// <summary>
        /// Event occurring on Page Init
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                this.InitPage();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring on Page Load
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BasePresenter.LoadUser();
                }

                this.LoadPage();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private Site SiteMaster
        {
            get
            {
                return this.Master as Site;
            }
        }

        public IPrincipal CurrentUser
        {
            get
            {
                return LoginUtil.GetCurrentUser();
            }
        }

        public String DisplayName
        {
            get
            {
                return this.ViewState["DisplayName"] as String;
            }
            set
            {
                this.ViewState["DisplayName"] = value;

                if (SiteMaster != null)
                {
                    SiteMaster.DisplayName = value;
                }
            }
        }

        public Boolean ShowLogout
        {
            set
            {
                if (SiteMaster != null)
                {
                    SiteMaster.ShowLogout = value;
                }
            }
        }

        public Nullable<Int32> UserID
        {
            get
            {
                return this.ViewState["UserID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["UserID"] = value;
            }
        }

        public String AuthenticationType
        {
            get
            {
                return UserUtil.GetAuthenticationName(this.CurrentUser);
            }
        }

        public IList<Group> Roles
        {
            get
            {
                return this.ViewState["Roles"] as IList<Group>;
            }
            set
            {
                this.ViewState["Roles"] = value;
            }
        }

        private Exception _lastError;

        public Exception LastError
        {
            get
            {
                return _lastError;
            }
            private set
            {
                _lastError = value;
            }
        }

        public String CurrentLocation
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }

        internal void ShowNotice(String text, NoticeType noticeType)
        {
            ShowNotice(text, noticeType, null);
        }

        internal void ShowNotice(String text, NoticeType noticeType, String customUrl)
        {
            if (SiteMaster != null)
            {
                SiteMaster.ShowNotice(text, noticeType, customUrl);
            }
        }

        internal void HandleException(Exception ex)
        {
            try
            {
                this.LastError = ex;
                BasePresenter.SaveError();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (SiteMaster != null)
                {
                    SiteMaster.HandleException(ex);
                }
            }
        }

        protected virtual void InitPage()
        {

        }

        protected virtual void LoadPage()
        {

        }

        protected override PageStatePersister PageStatePersister
        {
            get
            {
                Boolean useSession = ConfigurationManager.AppSettings["StoreViewStateInSession"].ToNullable<Boolean>() == true;

                if (useSession)
                {
                    return new SessionPageStatePersister(this);
                }
                else
                {
                    return new HiddenFieldPageStatePersister(this);
                }
            }
        }
    }
}