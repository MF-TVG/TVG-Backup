using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class Dashboard : BasePage, IDashboardView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private DashboardPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public DashboardPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new DashboardPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Event occurring on Page Load, loads forms list on initial load
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    this.SortField = "Suspense";
                    this.SortDirection = SortDirectionConstants.ASCENDING;

                    Presenter.LoadLookups();
                    Presenter.Load();
                    SetSortArrows();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when a row is databound to a form list grid
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void dlFormList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Form)
                {
                    Form form = e.Item.DataItem as Form;

                    Nullable<DateTime> suspenseDate = form.SuspenseDate;
                    String status = form.ExtendedProperties.Status;
                    Nullable<DateTime> lastActionDate = form.ExtendedProperties.LastAction;

                    (e.Item.FindControl("imgHighPriority") as Image).Style[HtmlTextWriterStyle.Visibility] = form.HighPriority == true ? "visible" : "hidden";
                    (e.Item.FindControl("imgStatus") as Image).ImageUrl = ImageUtil.GetColorCode((StatusType)form.ExtendedProperties.StatusType);

                    HyperLink lnkFormTitle = e.Item.FindControl("lnkFormTitle") as HyperLink;
                    lnkFormTitle.Text = !String.IsNullOrEmpty(form.Subject) ? form.Subject : "{No Subject}";
                    lnkFormTitle.NavigateUrl = NavigateUtil.GetFormLink(form);

                    (e.Item.FindControl("ltrFormType") as Literal).Text = form.ExtendedProperties.FormTypeName;
                    (e.Item.FindControl("ltrFormNumber") as Literal).Text = form.FormNumber;
                    (e.Item.FindControl("ltrSubmitDate") as Literal).Text = form.SubmitDate.HasValue ? form.SubmitDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrSuspenseDate") as Literal).Text = suspenseDate.HasValue ? suspenseDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrLastActionDate") as Literal).Text = lastActionDate.HasValue ? lastActionDate.Value.ToShortDateString() : null;
                    (e.Item.FindControl("ltrStatus") as Literal).Text = status;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when the Search button is clicked, reloads forms according to parameters
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnFormSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Load();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when a Header is clicked, alters the sort parameters accordingly and reload the forms
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void lkbHeader_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (this.SortField == e.CommandArgument.ToString())
                {
                    this.SortDirection = this.SortDirection == SortDirectionConstants.ASCENDING ? SortDirectionConstants.DESCENDING : SortDirectionConstants.ASCENDING;
                }
                else
                {
                    this.SortField = e.CommandArgument.ToString();
                    this.SortDirection = SortDirectionConstants.ASCENDING;
                }

                Presenter.Load();
                SetSortArrows();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Loads all the forms based on the specified filter data
        /// </summary>
        private void SetSortArrows()
        {
            String submitImageControlName = String.Format("imgSubmit{0}{1}", this.SortField, this.SortDirection);

            foreach (Image submitImage in trSubmitHeaders.GetAllChildControls().OfType<Image>())
            {
                submitImage.Visible = submitImage.ID == submitImageControlName;
            }

            String reviewImageControlName = String.Format("imgReview{0}{1}", this.SortField, this.SortDirection);

            foreach (Image reviewImage in trReviewHeaders.GetAllChildControls().OfType<Image>())
            {
                reviewImage.Visible = reviewImage.ID == reviewImageControlName;
            }
        }

        public IList<FormStatus> FormStatuses
        {
            set
            {
                cklFormStatus.Items.Clear();

                foreach (FormStatus status in value)
                {
                    ListItem statusItem = new ListItem(status.FormStatusName, status.FormStatusID.ToStringSafe());
                    statusItem.Selected = status.ExtendedProperties.Preselected == true;

                    cklFormStatus.Items.Add(statusItem);
                }
            }
        }

        public IList<Nullable<Int32>> SelectedFormStatuses
        {
            get
            {
                return cklFormStatus.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
            }
        }

        public Boolean MyReviewOnly
        {
            get
            {
                return chkMyReviewOnly.Checked;
            }
        }

        public String SubjectFilter
        {
            get
            {
                return txtFormSubject.Text;
            }
        }

        public String SortField
        {
            get
            {
                return this.ViewState["SortField"] as String;
            }
            private set
            {
                this.ViewState["SortField"] = value;
            }
        }

        public String SortDirection
        {
            get
            {
                return this.ViewState["SortDirection"] as String;
            }
            private set
            {
                this.ViewState["SortDirection"] = value;
            }
        }

        public IList<Form> SubmitForms
        {
            set
            {
                dlSubmittedList.DataSource = value;
                dlSubmittedList.DataBind();
            }
        }

        public IList<Form> ReviewForms
        {
            set
            {
                dlReviewList.DataSource = value;
                dlReviewList.DataBind();
            }
        }
    }
}