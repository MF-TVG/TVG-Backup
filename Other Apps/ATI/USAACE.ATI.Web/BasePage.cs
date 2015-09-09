using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Presenters;
using USAACE.ATI.Presentation.Views;
using USAACE.ATI.Web.Enum;
using USAACE.ATI.Web.Util;

namespace USAACE.ATI.Web
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
                return HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User : null;
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