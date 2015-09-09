using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Enum;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class Preferences : BasePage, IPreferencesView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private PreferencesPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public PreferencesPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new PreferencesPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();

                base.ShowNotice(MessageConstants.SAVE_PREFERENCES_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public Nullable<Int32> CurrentUserID
        {
            get
            {
                if (Request.QueryString["UserID"] != null)
                {
                    return Request.QueryString["UserID"].ToNullable<Int32>();
                }
                else
                {
                    return base.UserID;
                }
            }
            set
            {
                lblUserID.Text = value.ToString();
            }
        }

        public String UserName
        {
            set
            {
                lblUserName.Text = value;
            }
        }

        public String UserAuthenticationType
        {
            set
            {
                lblAuthProvider.Text = value;
            }
        }

        public String UserDisplayName
        {
            set
            {
                lblDisplayName.Text = value;
            }
        }

        public String UserEmail
        {
            set
            {
                lblEmailAddress.Text = value;
            }
        }

        public String UserRoles
        {
            set
            {
                lblRoles.Text = value;
            }
        }

        public Nullable<Boolean> NotifyReject
        {
            get
            {
                return chkNotifyReject.Checked;
            }
            set
            {
                chkNotifyReject.Checked = value == true;
            }
        }

        public Nullable<Boolean> NotifyReview
        {
            get
            {
                return chkNotifyReview.Checked;
            }
            set
            {
                chkNotifyReview.Checked = value == true;
            }
        }

        public Nullable<Boolean> NotifyComplete
        {
            get
            {
                return chkNotifyComplete.Checked;
            }
            set
            {
                chkNotifyComplete.Checked = value == true;
            }
        }
    }
}