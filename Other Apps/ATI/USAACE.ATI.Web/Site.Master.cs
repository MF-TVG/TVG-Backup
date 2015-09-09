using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Presentation.Views;
using USAACE.ATI.Web.Enum;
using USAACE.ATI.Web.Util;
using USAACE.Common.Exceptions;
using USAACE.Common.Web;
using USAACE.ATI.Presentation.Presenters;

namespace USAACE.ATI.Web
{
    /// <summary>
    /// Class for the master page
    /// </summary>
    public partial class Site : MasterPage, ISiteView
    {
            /// <summary>
        /// Private member for the presenter
        /// </summary>
        private SitePresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public SitePresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new SitePresenter(this);
                }

                return _presenter;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HandleDisclaimer();
                    Presenter.Load();
                    SetSelectedMenuItem();
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void btnNoticeOK_Click(object sender, EventArgs e)
        {
            try
            {
                mpNotice.Hide();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void btnDisclaimerOK_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Cookies["TRADisclaimer"].Value = "1";
                Response.Cookies["TRADisclaimer"].Expires = DateTime.Now.AddDays(1);
                mpDisclaimer.Hide();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        public String IADesignation
        {
            set
            {
                ltrIADTop.Text = value;
                ltrIADBottom.Text = value;
            }
        }

        internal void HandleException(Exception ex)
        {
            if (ex is USAACEException)
            {
                USAACEException exception = ex as USAACEException;

                switch (exception.Type)
                {
                    case ExceptionType.Unrecoverable: this.ShowNotice(ex.Message, NoticeType.Error, null); break;
                    case ExceptionType.Recoverable: this.ShowNotice(ex.Message, NoticeType.Warning, null); break;
                    default: break;
                }
            }
            else
            {
                this.ShowNotice(String.Format("The following unexpected error has occurred: {0}<br /><br />{1}", ex.Message, ex.StackTrace), NoticeType.Critical, null);
            }
        }

        internal void ShowNotice(String text, NoticeType noticeType, String customUrl)
        {
            imgNotice.ImageUrl = NoticeUtil.GetNoticeImageUrl(noticeType);
            ltrNoticeTitle.Text = NoticeUtil.GetNoticeTitle(noticeType);
            ltrNoticeText.Text = text;

            cphBody.Visible = noticeType != NoticeType.Error;
            btnNoticeOK.Visible = noticeType != NoticeType.Error && String.IsNullOrEmpty(customUrl);
            lnkErrorNoticeOK.Visible = noticeType == NoticeType.Error || customUrl != null;
            lnkErrorNoticeOK.NavigateUrl = customUrl ?? "~/";

            mpNotice.Show();
        }

        internal String DisplayName
        {
            set
            {
                lnkUserName.Text = value;
            }
        }

        private void HandleDisclaimer()
        {
            if (Request.Cookies["TRADisclaimer"] == null)
            {
                mpDisclaimer.Show();
            }
        }

        private void SetSelectedMenuItem()
        {
            MenuItem item = mnuMainMenu.GetAllItems().LastOrDefault(x => !String.IsNullOrEmpty(x.NavigateUrl) && Request.RawUrl.StartsWith(ResolveUrl(x.NavigateUrl)));

            if (item != null)
            {
                if (item.Parent != null)
                {
                    item.Parent.Selected = true;
                }
                else
                {
                    item.Selected = true;
                }

                Page.Title = item.Text;
            }
        }
    }
}
