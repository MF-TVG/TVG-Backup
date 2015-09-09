using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class Tracking : BasePage, ITrackingView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private TrackingPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public TrackingPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new TrackingPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Event occurring on Page Load, loads appropriate lookups on initial event
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
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

        /// <summary>
        /// Event occurring on clicking of Filter button, generates the dashboard
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.GenerateDashboard();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring on clicking of Select All button, checks all forms
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbSelectAllForms_Click(object sender, EventArgs e)
        {
            try
            {
                cklFormTypes.SetAll(true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring on clicking of Unselect All button, unchecks all forms
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbUnselectAllForms_Click(object sender, EventArgs e)
        {
            try
            {
                cklFormTypes.SetAll(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring on clicking of Select All button, checks all reviewers
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbSelectAllUnits_Click(object sender, EventArgs e)
        {
            try
            {
                cklReviewers.SetAll(true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring on clicking of Unselect All button, unchecks all reviewers
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbUnselectAllUnits_Click(object sender, EventArgs e)
        {
            try
            {
                cklReviewers.SetAll(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring on selection of Organization dropdown, loads the review groups appropriate to that organization
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadReviewGroups();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlReviewers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is ListItem)
                {
                    ListItem item = e.Item.DataItem as ListItem;

                    (e.Item.FindControl("ltrReviewerName") as Literal).Text = item.Text;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlForms_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Form)
                {
                    Form form = e.Item.DataItem as Form;

                    (e.Item.FindControl("ltrType") as Literal).Text = form.ExtendedProperties.FormTypeName;
                    (e.Item.FindControl("lnkSubject") as HyperLink).Text = !String.IsNullOrEmpty(form.Subject) ? form.Subject : "(No Subject)";
                    (e.Item.FindControl("lnkSubject") as HyperLink).NavigateUrl = NavigateUtil.GetFormLink(form);
                    (e.Item.FindControl("ltrSuspense") as Literal).Text = form.SuspenseDate.HasValue ? form.SuspenseDate.Value.ToString("MM/dd/yyyy") : "None Given";

                    (e.Item.FindControl("dlFormReviews") as Repeater).DataSource = form.ExtendedProperties.Reviews;
                    (e.Item.FindControl("dlFormReviews") as Repeater).DataBind();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlFormReviews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is ReviewStatus)
                {
                    ReviewStatus reviewStatus = e.Item.DataItem as ReviewStatus;

                    Image imgStatus = e.Item.FindControl("imgStatus") as Image;
                
                    if (imgStatus != null && reviewStatus != null)
                    {
                        imgStatus.Visible = true;
                        imgStatus.ImageUrl = ImageUtil.GetColorCode((StatusType)reviewStatus.ExtendedProperties.StatusType);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlFormCount_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is OrganizationGroup)
                {
                    OrganizationGroup organizationGroup = e.Item.DataItem as OrganizationGroup;

                    (e.Item.FindControl("ltrCount") as Literal).Text = GetMetricDisplayValue(organizationGroup.ExtendedProperties.MetricValue.GetValueOrDefault(0));
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private static String GetMetricDisplayValue(Int32 count)
        {
            if (count < 1000)
            {
                return count.ToString();
            }
            else
            {
                return String.Format("{0}k", (count / 1000.0).ToString("N0"));
            }
        }

        public IList<FormType> FormTypes
        {
            set
            {
                cklFormTypes.Items.Clear();

                foreach (FormType formType in value)
                {
                    ListItem item = new ListItem(formType.FormTypeName, formType.FormTypeID.ToStringSafe());
                    item.Selected = true;
                    cklFormTypes.Items.Add(item);
                }
            }
        }

        public IList<Nullable<Int32>> SelectedFormTypes
        {
            get
            {
                return cklFormTypes.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
            }
        }

        public Nullable<DateTime> SuspenseDateStart
        {
            get
            {
                return dcStartDate.SelectedDate;
            }
        }

        public Nullable<DateTime> SuspenseDateEnd
        {
            get
            {
                return dcEndDate.SelectedDate;
            }
        }

        public IList<OrganizationGroup> ReviewGroups
        {
            set
            {
                cklReviewers.Items.Clear();

                foreach (OrganizationGroup organizationGroup in value)
                {
                    ListItem item = new ListItem(organizationGroup.OrganizationGroupName, organizationGroup.OrganizationGroupID.ToStringSafe());
                    item.Selected = true;

                    cklReviewers.Items.Add(item);
                }
            }
        }

        public IList<Nullable<Int32>> SelectedReviewGroups
        {
            get
            {
                return cklReviewers.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
            }
        }

        public Nullable<DateTime> SubmitDateStart
        {
            get
            {
                return dcSubmitDateStart.SelectedDate;
            }
        }

        public Nullable<DateTime> SubmitDateEnd
        {
            get
            {
                return dcSubmitDateEnd.SelectedDate;
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

        public IList<Organization> Organizations
        {
            set
            {
                ddlOrganization.Items.Clear();

                foreach (Organization organization in value)
                {
                    ddlOrganization.Items.Add(new ListItem(organization.OrganizationName, organization.OrganizationID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> SelectedOrganization
        {
            get
            {
                return ddlOrganization.SelectedValue.ToNullable<Int32>();
            }
        }

        public String Subject
        {
            get
            {
                return txtSubject.Text;
            }
        }

        public Boolean ShowDashboard
        {
            set
            {
                pnlDashboard.Visible = value;
            }
        }

        public IList<Form> Forms
        {
            set
            {
                dlReviewers.DataSource = cklReviewers.GetSelectedItems();
                dlReviewers.DataBind();

                dlForms.DataSource = value;
                dlForms.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsQueued
        {
            set
            {
                dlFormCountQueued.DataSource = value;
                dlFormCountQueued.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsReview
        {
            set
            {
                dlFormCountReview.DataSource = value;
                dlFormCountReview.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsNearDue
        {
            set
            {
                dlFormCountNearDue.DataSource = value;
                dlFormCountNearDue.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsPastDue
        {
            set
            {
                dlFormCountPastDue.DataSource = value;
                dlFormCountPastDue.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsCompleted
        {
            set
            {
                dlFormCountCompleted.DataSource = value;
                dlFormCountCompleted.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsRejected
        {
            set
            {
                dlFormCountRejected.DataSource = value;
                dlFormCountRejected.DataBind();
            }
        }

        public IList<OrganizationGroup> MetricsTotal
        {
            set
            {
                dlFormCountTotal.DataSource = value;
                dlFormCountTotal.DataBind();
            }
        }
    }
}