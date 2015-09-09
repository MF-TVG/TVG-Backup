using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Web;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages.Administration;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;
using USAACE.eStaffing.Web.Enum;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Pages.Administration
{
    public partial class FormSettings : BasePage, IFormSettingsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private FormSettingsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public FormSettingsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new FormSettingsPresenter(this);
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
                    rblParallelReview.BindBooleanListControl("Parallel", "Serial");
                    Presenter.Load();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlOrganizationFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadOrganizationFormType();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlOrganizationFormActors_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is OrganizationFormActor)
                {
                    OrganizationFormActor actor = e.Item.DataItem as OrganizationFormActor;

                    (e.Item.FindControl("ltrOrganizationGroupName") as Literal).Text = actor.ExtendedProperties.OrganizationGroupName;
                    (e.Item.FindControl("imgAdmin") as Image).Visible = actor.CanAdmin == true;
                    (e.Item.FindControl("imgSubmit") as Image).Visible = actor.CanSubmit == true;
                    (e.Item.FindControl("imgReview") as Image).Visible = actor.CanReview == true;
                    (e.Item.FindControl("imgChooseRoute") as Image).Visible = actor.CanChooseRoute == true;
                    (e.Item.FindControl("imgChangeRoute") as Image).Visible = actor.CanChangeRoute == true;
                    (e.Item.FindControl("imgEditSubmission") as Image).Visible = actor.CanEditSubmission == true;
                    (e.Item.FindControl("imgForward") as Image).Visible = actor.CanForward == true;
                    (e.Item.FindControl("imgSeeComments") as Image).Visible = actor.CanSeeComments == true;
                    (e.Item.FindControl("imgViewAll") as Image).Visible = actor.CanView == true;
                    (e.Item.FindControl("imgAssignAutopen") as Image).Visible = actor.CanAssignAutopen == true;
                    (e.Item.FindControl("imgMustReview") as Image).Visible = actor.MustReview == true;
                    (e.Item.FindControl("imgNotifyComplete") as Image).Visible = actor.NotifyComplete == true;
                    (e.Item.FindControl("imbEditFormActor") as ImageButton).CommandArgument = actor.OrganizationFormActorID.ToStringSafe();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditFormActor_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedFormActorID = e.CommandArgument.ToNullable<Int32>();
                Presenter.LoadSelectedActor();
                mpEditFormActor.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveFormActor_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveSelectedActor();
                mpEditFormActor.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelFormActor_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditFormActor.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditMessage_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedNoticeType = e.CommandArgument.ToString();
                Presenter.LoadSelectedMessage();
                mpEditMessage.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveSelectedMessage();
                mpEditMessage.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelMessage_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditMessage.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveFormSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();
                base.ShowNotice(MessageConstants.SAVE_FORM_SETTINGS_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<Organization> Organizations
        {
            set
            {
                ddlOrganization.Items.Clear();

                ddlOrganization.Items.Add(new ListItem("-- Select an Organization --", String.Empty));

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

        public IList<FormType> FormTypes
        {
            set
            {
                ddlFormType.Items.Clear();

                ddlFormType.Items.Add(new ListItem("-- Select a Form Type --", String.Empty));

                foreach (FormType formType in value)
                {
                    ddlFormType.Items.Add(new ListItem(formType.FormTypeName, formType.FormTypeID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> SelectedFormType
        {
            get
            {
                return ddlFormType.SelectedValue.ToNullable<Int32>();
            }
        }

        public Boolean ShowData
        {
            set
            {
                pnlData.Visible = value;
            }
        }

        public Nullable<Boolean> ParallelReview
        {
            get
            {
                return rblParallelReview.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblParallelReview.SelectedValue = value.ToStringSafe();
            }
        }

        public Nullable<Int16> PastDueDays
        {
            get
            {
                return txtPastDueDays.Text.ToNullable<Int16>();
            }
            set
            {
                txtPastDueDays.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> NearDueDays
        {
            get
            {
                return txtNearDueDays.Text.ToNullable<Int16>();
            }
            set
            {
                txtNearDueDays.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> SuspenseAdjust
        {
            get
            {
                return txtSuspenseAdjust.Text.ToNullable<Int16>();
            }
            set
            {
                txtSuspenseAdjust.Text = value.ToStringSafe();
            }
        }

        public IList<OrganizationFormActor> Actors
        {
            get
            {
                return this.ViewState["FormActors"] as IList<OrganizationFormActor>;
            }
            set
            {
                this.ViewState["FormActors"] = value;

                dlOrganizationFormActors.DataSource = value;
                dlOrganizationFormActors.DataBind();
            }
        }

        public Nullable<Int32> SelectedFormActorID
        {
            get
            {
                return this.ViewState["SelectedFormActorID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedFormActorID"] = value;
            }
        }

        public String SelectedFormActorName
        {
            set
            {
                ltrSelectedOrganizationName.Text = value;
            }
        }

        public Nullable<Boolean> CanAdmin
        {
            get
            {
                return chkAdmin.Checked;
            }
            set
            {
                chkAdmin.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanSubmit
        {
            get
            {
                return chkSubmit.Checked;
            }
            set
            {
                chkSubmit.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanReview
        {
            get
            {
                return chkReview.Checked;
            }
            set
            {
                chkReview.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanChooseRoute
        {
            get
            {
                return chkChooseRoute.Checked;
            }
            set
            {
                chkChooseRoute.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanChangeRoute
        {
            get
            {
                return chkChangeRoute.Checked;
            }
            set
            {
                chkChangeRoute.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanEditSubmission
        {
            get
            {
                return chkEditSubmission.Checked;
            }
            set
            {
                chkEditSubmission.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanForward
        {
            get
            {
                return chkForward.Checked;
            }
            set
            {
                chkForward.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanSeeComments
        {
            get
            {
                return chkSeeComments.Checked;
            }
            set
            {
                chkSeeComments.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanViewAll
        {
            get
            {
                return chkViewAll.Checked;
            }
            set
            {
                chkViewAll.Checked = value == true;
            }
        }

        public Nullable<Boolean> CanAssignAutopen
        {
            get
            {
                return chkAssignAutopen.Checked;
            }
            set
            {
                chkAssignAutopen.Checked = value == true;
            }
        }

        public Nullable<Boolean> MustReview
        {
            get
            {
                return chkMustReview.Checked;
            }
            set
            {
                chkMustReview.Checked = value == true;
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

        public String SelectedNoticeType
        {
            get
            {
                return ltrSelectedNoticeType.Text;
            }
            set
            {
                ltrSelectedNoticeType.Text = value;
            }
        }

        public String ReviewSubject
        {
            get
            {
                return ltrReviewSubject.Text;
            }
            set
            {
                ltrReviewSubject.Text = value;
            }
        }

        public String ReviewMessage
        {
            get
            {
                return ltrReviewMessage.Text;
            }
            set
            {
                ltrReviewMessage.Text = value;
            }
        }

        public String RejectSubject
        {
            get
            {
                return ltrRejectSubject.Text;
            }
            set
            {
                ltrRejectSubject.Text = value;
            }
        }

        public String RejectMessage
        {
            get
            {
                return ltrRejectMessage.Text;
            }
            set
            {
                ltrRejectMessage.Text = value;
            }
        }

        public String CompleteSubject
        {
            get
            {
                return ltrCompleteSubject.Text;
            }
            set
            {
                ltrCompleteSubject.Text = value;
            }
        }

        public String CompleteMessage
        {
            get
            {
                return ltrCompleteMessage.Text;
            }
            set
            {
                ltrCompleteMessage.Text = value;
            }
        }

        public String EditSubject
        {
            get
            {
                return txtEditSubject.Text;
            }
            set
            {
                txtEditSubject.Text = value;
            }
        }

        public String EditMessage
        {
            get
            {
                return hteEditMessage.Text;
            }
            set
            {
                hteEditMessage.Text = value;
            }
        }

        public Boolean EnableEdit
        {
            set
            {
                txtNearDueDays.Enabled = value;
                txtPastDueDays.Enabled = value;
                txtSuspenseAdjust.Enabled = value;

                foreach (RepeaterItem item in dlOrganizationFormActors.Items)
                {
                    (item.FindControl("imbEditFormActor") as ImageButton).Visible = value;
                }

                imbEditReviewMessage.Visible = value;
                imbEditRejectMessage.Visible = value;
                imbEditCompleteMessage.Visible = value;

                btnSaveFormSettings.Visible = value;
            }
        }
    }
}