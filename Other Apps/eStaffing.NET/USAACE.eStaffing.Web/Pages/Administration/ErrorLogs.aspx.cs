using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages.Administration;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;
using USAACE.eStaffing.Web.Enum;

namespace USAACE.eStaffing.Web.Pages.Administration
{
    public partial class ErrorLogs : BasePage, IErrorLogsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ErrorLogsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ErrorLogsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ErrorLogsPresenter(this);
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

        protected void dlErrors_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is ErrorLog)
                {
                    ErrorLog log = e.Item.DataItem as ErrorLog;

                    (e.Item.FindControl("ltrErrorDate") as Literal).Text = log.ErrorDate.HasValue ? log.ErrorDate.Value.ToString() : null;
                    (e.Item.FindControl("ltrErrorUser") as Literal).Text = log.UserName;
                    (e.Item.FindControl("ltrErrorType") as Literal).Text = log.ErrorType;
                    (e.Item.FindControl("ltrErrorMessage") as Literal).Text = log.Message;
                    (e.Item.FindControl("imbOpenError") as ImageButton).CommandArgument = log.ErrorLogID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbOpenError_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedErrorLogID = e.CommandArgument.ToNullable<Int32>();
                Presenter.LoadErrorLog();
                mpErrorDetails.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCloseError_Click(object sender, EventArgs e)
        {
            try
            {
                mpErrorDetails.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<ErrorLog> ErrorLogList
        {
            get
            {
                return this.ViewState["ErrorLogList"] as IList<ErrorLog>;
            }
            set
            {
                this.ViewState["ErrorLogList"] = value;

                dlErrors.DataSource = value;
                dlErrors.DataBind();
            }
        }

        public Nullable<Int32> SelectedErrorLogID
        {
            get
            {
                return this.ViewState["SelectedErrorLogID"] as Nullable<Int32>;
            }
            private set
            {
                this.ViewState["SelectedErrorLogID"] = value;
            }
        }

        public Nullable<DateTime> ErrorDate
        {
            set
            {
                ltrErrorItemDate.Text = value.HasValue ? value.Value.ToString() : null;
            }
        }

        public String ErrorUser
        {
            set
            {
                ltrErrorItemUser.Text = value;
            }
        }

        public String ErrorType
        {
            set
            {
                ltrErrorItemType.Text = value;
            }
        }

        public String ErrorUrl
        {
            set
            {
                ltrErrorItemLocation.Text = value;
            }
        }

        public String ErrorMessage
        {
            set
            {
                ltrErrorItemMessage.Text = value;
            }
        }

        public String ErrorStackTrace
        {
            set
            {
                ltrErrorItemStackTrace.Text = value;
            }
        }
    }
}