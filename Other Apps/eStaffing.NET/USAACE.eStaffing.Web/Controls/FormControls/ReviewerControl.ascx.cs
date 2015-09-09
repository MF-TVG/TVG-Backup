using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.Common.Web.Controls;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Controls.FormControls;
using USAACE.eStaffing.Presentation.Views.Controls.FormControls;
using USAACE.eStaffing.Web.Controls.Forms;
using USAACE.eStaffing.Web.Enum;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.FormControls
{
    public partial class ReviewerControl : FormControl, IReviewerControlView
    {
        private const String PROMOTE_BOX_TEXT = "This packet should be forwarded to {0} upon completion of the review process";

        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ReviewerControlPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ReviewerControlPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ReviewerControlPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            Presenter.Load();
        }

        protected override void SaveForm()
        {

        }

        /// <summary>
        /// Event occurring on Page Load, sets appropriate labels
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["__EVENTTARGET"] == "reviewSignature")
                {
                    Presenter.SignFinal();
                    this.SignatureData = null;
                    this.ShowNotice(MessageConstants.SIGNATURE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void mnuReviewMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            try
            {
                Presenter.ChangeReviewTab();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when a reviewer item is databound, loads the item information and sets permissions
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void dlReviewers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                ReviewStatus reviewer = e.Item.DataItem as ReviewStatus;

                ImageButton imbReviewerEdit = e.Item.FindControl("imbReviewerEdit") as ImageButton;

                if (imbReviewerEdit != null)
                {
                    imbReviewerEdit.CommandArgument = reviewer.ReviewStatusID.ToStringSafe();
                    imbReviewerEdit.Visible = reviewer.Notified == true && (reviewer.ExtendedProperties.CanReview == true || reviewer.ExtendedProperties.CanAdmin == true);
                }

                Boolean canViewComments = reviewer.ExtendedProperties.CanReview == true || reviewer.ExtendedProperties.CanAdmin == true ||
                    reviewer.ExtendedProperties.CanViewComments == true;
                
                (e.Item.FindControl("ltrReviewerDuty") as Literal).Text = reviewer.ExtendedProperties.ReviewGroupName;
                (e.Item.FindControl("ltrReviewerAction") as Literal).Text = reviewer.ExtendedProperties.ReviewActionName;
                (e.Item.FindControl("ltrReviewerDate") as Literal).Text = reviewer.ActionDate.HasValue ? reviewer.ActionDate.Value.ToShortDateString() : null;

                ImageButton imbReviewerSigned = e.Item.FindControl("imbReviewerSigned") as ImageButton;

                if (imbReviewerSigned != null)
                {
                    imbReviewerSigned.CommandArgument = reviewer.ReviewStatusID.ToStringSafe();
                    imbReviewerSigned.Style[HtmlTextWriterStyle.Visibility] = reviewer.DigitalSignature == true ? "visible" : "hidden";
                }

                (e.Item.FindControl("imgReviewerDocumentSigned") as Image).Style[HtmlTextWriterStyle.Visibility] = reviewer.Signed == true ? "visible" : "hidden";
                (e.Item.FindControl("imgReviewerAutopen") as Image).Style[HtmlTextWriterStyle.Visibility] = reviewer.Autopen == true ? "visible" : "hidden";

                (e.Item.FindControl("ltrReviewerRemarks") as Literal).Text = canViewComments ? reviewer.Comments : "< Remarks Hidden >";

                TreeView trvReviewerAttachments = e.Item.FindControl("trvReviewerAttachments") as TreeView;

                if (trvReviewerAttachments != null)
                {
                    trvReviewerAttachments.Visible = canViewComments && reviewer.ExtendedProperties.Attachments.Count > 0;

                    if (canViewComments)
                    {
                        TreeNode mainNode = trvReviewerAttachments.Nodes[0];
                        mainNode.ChildNodes.Clear();

                        foreach (FormAttachment attachment in reviewer.ExtendedProperties.Attachments)
                        {
                            mainNode.ChildNodes.Add(new TreeNode(attachment.FileName, attachment.FileName, null, NavigateUtil.GetFormAttachmentLink(attachment), "_blank"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when an item is bound to the Action Log repeater, it gets information about the action and displays the information
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void dlActionLog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                FormLog log = e.Item.DataItem as FormLog;

                (e.Item.FindControl("ltrActionDate") as Literal).Text = log.LogDate.Value.ToString();
                (e.Item.FindControl("ltrActionAction") as Literal).Text = log.Action;
                (e.Item.FindControl("ltrActionRole") as Literal).Text = log.Role;
                (e.Item.FindControl("ltrActionUser") as Literal).Text = log.UserName;
                (e.Item.FindControl("ltrActionNotes") as Literal).Text = log.Notes;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbReviewerEdit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewStatusID = e.CommandArgument.ToNullable<Int32>();
                ucFileControl.ReviewStatusID = e.CommandArgument.ToNullable<Int32>();
                Presenter.LoadReviewStatus();
                ucFileControl.LoadData();
                mpEditReview.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbReviewerSigned_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewStatusID = e.CommandArgument.ToNullable<Int32>();
                Presenter.ViewReviewSignature();
                mpViewDigitalSignature.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlReviewAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetReviewDate();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnResetReview_Click(object sender, EventArgs e)
        {
            try
            {
                mpReviewResetConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnResetReviewConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ResetReviewStatus();
                mpReviewResetConfirm.Hide();
                mpEditReview.Hide();
                this.ShowNotice(MessageConstants.RESET_REVIEW_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnResetReviewCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpReviewResetConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnNotifyReview_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.NotifyReviewStatus();
                mpEditReview.Hide();
                this.ShowNotice(MessageConstants.NOTIFY_REVIEW_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveReview_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("ReviewStatus");

                if (Page.IsValid)
                {
                    Presenter.SaveReviewStatus();
                    ucFileControl.SaveData();
                    mpEditReview.Hide();
                    this.ReloadForm();
                    this.ShowNotice(MessageConstants.SAVE_REVIEW_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelReview_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditReview.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void cvReviewRemarks_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = !this.ReviewIsRejection || !String.IsNullOrWhiteSpace(hteReviewRemarks.PlainText);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnModifyOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadReviewOrders();
                mpModifyReviewOrder.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlReviewOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                ReviewStatus reviewStatus = e.Item.DataItem as ReviewStatus;

                (e.Item.FindControl("imbReviewOrderMoveUp") as ImageButton).Visible = reviewStatus.ExtendedProperties.IsFirst != true && reviewStatus.ExtendedProperties.CanMove == true;
                (e.Item.FindControl("imbReviewOrderMoveUp") as ImageButton).CommandArgument = reviewStatus.ReviewStatusID.ToStringSafe();
                (e.Item.FindControl("imbReviewOrderMoveDown") as ImageButton).Visible = reviewStatus.ExtendedProperties.IsLast != true && reviewStatus.ExtendedProperties.CanMove == true;
                (e.Item.FindControl("imbReviewOrderMoveDown") as ImageButton).CommandArgument = reviewStatus.ReviewStatusID.ToStringSafe();
                (e.Item.FindControl("imbReviewOrderDelete") as ImageButton).CommandArgument = reviewStatus.ReviewStatusID.ToStringSafe();
                (e.Item.FindControl("ltrReviewOrderDuty") as Literal).Text = reviewStatus.ExtendedProperties.ReviewGroupName;

                DropDownControl ddlReviewOrderRole = e.Item.FindControl("ddlReviewOrderRole") as DropDownControl;

                ddlReviewOrderRole.CommandArgument = reviewStatus.ReviewStatusID.ToStringSafe();

                ddlReviewOrderRole.Items.Clear();

                foreach (ReviewRole role in reviewStatus.ExtendedProperties.ReviewRoles)
                {
                    ddlReviewOrderRole.Items.Add(new ListItem(role.ReviewRoleName, role.ReviewRoleID.ToStringSafe()));
                }

                ddlReviewOrderRole.SelectedValue = reviewStatus.ReviewRoleID.ToStringSafe();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbReviewOrderMoveUp_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewOrderID = e.CommandArgument.ToNullable<Int32>();
                Presenter.MoveReviewOrderUp();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbReviewOrderMoveDown_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewOrderID = e.CommandArgument.ToNullable<Int32>();
                Presenter.MoveReviewOrderDown();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbReviewOrderDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewOrderID = e.CommandArgument.ToNullable<Int32>();
                Presenter.DeleteReviewOrder();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlReviewOrderRole_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewOrderID = e.CommandArgument.ToNullable<Int32>();
                this.SelectedReviewOrderRoleID = ((sender as Control).Parent.FindControl("ddlReviewOrderRole") as DropDownControl).SelectedValue.ToNullable<Int32>();
                Presenter.ChangeReviewOrderRole();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void lkbReviewSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                cklReviewOrderAdd.SetAll(true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void lkbReviewUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                cklReviewOrderAdd.SetAll(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddReviewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.AddReviewOrder();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveReviewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveReviewOrder();
                mpModifyReviewOrder.Hide();
                this.ShowNotice(MessageConstants.SAVE_REVIEW_ORDER_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelReviewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                mpModifyReviewOrder.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnForwardPacket_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadForwarding();
                mpForwardPacket.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveForwardPacket_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveForwarding();
                mpForwardPacket.Hide();
                this.ShowNotice(MessageConstants.FORWARD_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelForwardPacket_Click(object sender, EventArgs e)
        {
            try
            {
                mpForwardPacket.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSignReview_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Sign();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Sign",
                    NavigateUtil.GetSignatureScript(this.SignatureFormHash, hdfSignatureData.ClientID), true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnUnsignReview_Click(object sender, EventArgs e)
        {
            try
            {
                mpUnsignConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnUnsignConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Unsign();
                mpUnsignConfirm.Hide();
                this.ShowNotice(MessageConstants.SIGNATURE_REMOVE_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnUnsignCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpUnsignConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnViewSignatureConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                mpViewDigitalSignature.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<Organization> ReviewOrganizations
        {
            set
            {
                mnuReviewMenu.Items.Clear();

                foreach (Organization organization in value)
                {
                    MenuItem item = new MenuItem(organization.ExtendedProperties.ReviewTabValue, organization.ExtendedProperties.ReviewTabKey,
                        ImageUtil.GetColorCode((StatusType)organization.ExtendedProperties.StatusType));

                    mnuReviewMenu.Items.Add(item);
                    
                }

                mnuReviewMenu.Items.Add(new MenuItem("Action Log", "ActionLog", "~/images/log.gif"));

                mnuReviewMenu.Items[0].Selected = true;
            }
        }

        public IDictionary<String, IList<ReviewStatus>> ReviewStatuses
        {
            get
            {
                return this.ViewState["ReviewStatuses"] as IDictionary<String, IList<ReviewStatus>>;
            }
            set
            {
                this.ViewState["ReviewStatuses"] = value;

                dlAllReviewers.DataSource = value != null ? value.Values.SelectMany(x => x).OrderBy(x => x.ReviewOrder) : null;
                dlAllReviewers.DataBind();
            }
        }

        public IList<ReviewStatus> CurrentReviewStatuses
        {
            set
            {
                dlReviewers.DataSource = value;
                dlReviewers.DataBind();
            }
        }

        public Boolean CanModifyOrder
        {
            set
            {
                btnModifyOrder.Visible = value;
            }
        }

        public Boolean CanForward
        {
            set
            {
                btnForwardPacket.Visible = value;
            }
        }

        public IList<FormLog> LogItems
        {
            set
            {
                dlActionLog.DataSource = value;
                dlActionLog.DataBind();
            }
        }

        public Nullable<Int32> SelectedReviewStatusID
        {
            get
            {
                return this.ViewState["SelectedReviewStatusID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedReviewStatusID"] = value;
            }
        }

        public String SelectedTab
        {
            get
            {
                return mnuReviewMenu.SelectedValue;
            }
            set
            {
                mnuReviewMenu.FindItem(value).Selected = true;
            }
        }

        public Boolean ShowReview
        {
            set
            {
                pnlReviewGrid.Visible = value;
            }
        }

        public Boolean ShowActionLog
        {
            set
            {
                pnlActionLog.Visible = value;
            }
        }

        public IList<ReviewAction> ReviewActions
        {
            set
            {
                ddlReviewAction.Items.Clear();

                ddlReviewAction.Items.Add(new ListItem("-- Choose Action --", String.Empty));

                foreach (ReviewAction action in value)
                {
                    ddlReviewAction.Items.Add(new ListItem(action.ReviewActionName, action.ReviewActionID.ToString(), action.ExtendedProperties.CanSelect == true));
                }
            }
        }

        public String ReviewDuty
        {
            set
            {
                ltrReviewDuty.Text = value;
            }
        }

        public Nullable<Int32> SelectedReviewAction
        {
            get
            {
                return ddlReviewAction.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlReviewAction.SelectedValue = value.ToStringSafe();
            }
        }

        public Boolean ReviewIsRejection
        {
            get
            {
                return this.ViewState["ReviewIsRejection"].ToNullable<Boolean>() == true;
            }
            set
            {
                this.ViewState["ReviewIsRejection"] = value;
            }
        }

        public Nullable<DateTime> ReviewDate
        {
            get
            {
                return ltrReviewDate.Text.ToNullable<DateTime>();
            }
            set
            {
                ltrReviewDate.Text = value.HasValue ? value.Value.ToShortDateString() : null;
            }
        }

        public Nullable<Boolean> ReviewSigned
        {
            get
            {
                return chkReviewSigned.Checked;
            }
            set
            {
                chkReviewSigned.Checked = value == true;
            }
        }

        public Nullable<Boolean> ReviewAutopen
        {
            get
            {
                return chkReviewAutopen.Checked;
            }
            set
            {
                chkReviewAutopen.Checked = value == true;
            }
        }

        public String ReviewRemarks
        {
            get
            {
                return hteReviewRemarks.Text;
            }
            set
            {
                hteReviewRemarks.Text = value;
            }
        }

        public Boolean ReviewCanAutopen
        {
            set
            {
                chkReviewAutopen.Visible = value;
            }
        }

        public Boolean ReviewCanAdmin
        {
            set
            {
                btnResetReview.Visible = value;
                btnNotifyReview.Visible = value;
            }
        }

        public String SignatureSubject
        {
            set
            {
                lblSignatureName.Text = value;
            }
        }

        public Nullable<DateTime> SignatureDate
        {
            set
            {
                lblSignatureDate.Text = value.ToStringSafe();
            }
        }

        public Boolean SignatureValid
        {
            set
            {
                imgSignatureValid.ImageUrl = ImageUtil.GetSignatureImage(value);
                lblSignatureName.CssClass = value != true ? "validationError" : null;
                lblSignatureDate.CssClass = value != true ? "validationError" : null;
                ltrSignatureValidText.Text = value != true ? MessageConstants.SIGNATURE_INVALID : MessageConstants.SIGNATURE_VALID;
            }
        }

        public String SignatureFormHash
        {
            private get
            {
                return this.ViewState["SignatureFormHash"] as String;
            }
            set
            {
                this.ViewState["SignatureFormHash"] = value;
            }
        }

        public String SignatureData
        {
            get
            {
                return hdfSignatureData.Value;
            }
            set
            {
                hdfSignatureData.Value = value;
            }
        }

        public Nullable<Boolean> SignaturePresent
        {
            get
            {
                return btnUnsignReview.Visible;
            }
            set
            {
                pnlSignatureData.Visible = value == true;
                btnSignReview.Visible = value != true;

                ddlReviewAction.Enabled = value != true;
                chkReviewSigned.Enabled = value != true;
                chkReviewAutopen.Enabled = value != true;
                hteReviewRemarks.Enabled = value != true;
                btnSaveReview.Visible = value != true;
                btnCloseReview.Visible = value == true;
                btnCancelReview.Visible = value != true;
            }
        }

        public Boolean SignatureEnable
        {
            set
            {
                pnlSignature.Visible = value;
                pnlSignatureDisable.Visible = !value;
            }
        }

        public IList<ReviewStatus> ReviewOrders
        {
            get
            {
                return this.ViewState["ReviewOrders"] as IList<ReviewStatus>;
            }
            set
            {
                this.ViewState["ReviewOrders"] = value;

                dlReviewOrder.DataSource = value.Where(x => x.ExtendedProperties.MarkForDeletion != true);
                dlReviewOrder.DataBind();
            }
        }

        public Nullable<Int32> SelectedReviewOrderID
        {
            get
            {
                return this.ViewState["SelectedReviewOrderID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedReviewOrderID"] = value;
            }
        }

        public Nullable<Int32> SelectedReviewOrderRoleID
        {
            get
            {
                return this.ViewState["SelectedReviewOrderRoleID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedReviewOrderRoleID"] = value;
            }
        }

        public IList<OrganizationFormActor> ReviewOrderGroups
        {
            set
            {
                cklReviewOrderAdd.Items.Clear();

                foreach (OrganizationFormActor actor in value)
                {
                    cklReviewOrderAdd.Items.Add(new ListItem(actor.ExtendedProperties.OrganizationGroupName, actor.OrganizationGroupID.ToStringSafe()));
                }
            }
        }

        public IList<Nullable<Int32>> SelectedReviewGroupsID
        {
            get
            {
                return cklReviewOrderAdd.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
            }
            set
            {
                foreach (ListItem item in cklReviewOrderAdd.Items)
                {
                    item.Selected = value != null && value.Contains(item.Value.ToNullable<Int32>());
                }
            }
        }

        public IList<ReviewRole> ReviewOrderRoles
        {
            set
            {
                ddlReviewOrderRole.Items.Clear();

                foreach (ReviewRole role in value)
                {
                    ddlReviewOrderRole.Items.Add(new ListItem(role.ReviewRoleName, role.ReviewRoleID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> SelectedReviewRoleID
        {
            get
            {
                return ddlReviewOrderRole.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlReviewOrderRole.SelectedValue = value.ToStringSafe();
            }
        }

        public IList<Organization> ForwardOrganizations
        {
            set
            {
                ddlForwardOrganization.Items.Clear();

                foreach (Organization organization in value)
                {
                    ddlForwardOrganization.Items.Add(new ListItem(organization.OrganizationName, organization.OrganizationID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> SelectedForwardOrganizationID
        {
            get
            {
                return ddlForwardOrganization.SelectedValue.ToNullable<Int32>();
            }
        }

        public IList<OrganizationFormRouting> ForwardRoutingChains
        {
            set
            {
                rblForwardRoutingChain.Items.Clear();

                foreach (OrganizationFormRouting routing in value)
                {
                    rblForwardRoutingChain.Items.Add(new ListItem(routing.ExtendedProperties.RoutingNameAndReviewers, routing.OrganizationFormRoutingID.ToStringSafe()));
                }

                if (rblForwardRoutingChain.Items.Count > 0)
                {
                    rblForwardRoutingChain.SelectedIndex = 0;
                }
            }
        }

        public Nullable<Int32> SelectedForwardRoutingID
        {
            get
            {
                return rblForwardRoutingChain.SelectedValue.ToNullable<Int32>();
            }
        }

        public String SignatureViewSubject
        {
            set
            {
                lblViewSignatureName.Text = value;
            }
        }

        public Nullable<DateTime> SignatureViewDate
        {
            set
            {
                lblViewSignatureDate.Text = value.ToStringSafe();
            }
        }

        public Boolean SignatureViewValid
        {
            set
            {
                imgViewSignatureValid.ImageUrl = ImageUtil.GetSignatureImage(value);
                lblViewSignatureName.CssClass = value != true ? "validationError" : null;
                lblViewSignatureDate.CssClass = value != true ? "validationError" : null;
                ltrViewSignatureValidText.Text = value != true ? MessageConstants.SIGNATURE_INVALID : MessageConstants.SIGNATURE_VALID;
            }
        }

        internal override void SetEnabledState(bool enabled)
        {

        }
    }
}