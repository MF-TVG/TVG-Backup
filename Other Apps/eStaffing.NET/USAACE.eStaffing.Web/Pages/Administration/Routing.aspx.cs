using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Web;
using USAACE.Common.Web.Controls;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages.Administration;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;
using USAACE.eStaffing.Web.Enum;

namespace USAACE.eStaffing.Web.Pages.Administration
{
    public partial class Routing : BasePage, IRoutingView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private RoutingPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public RoutingPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new RoutingPresenter(this);
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

        protected void dlOrganizationFormRoutings_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                OrganizationFormRouting routing = e.Item.DataItem as OrganizationFormRouting;

                (e.Item.FindControl("ltrRoutingChainName") as Literal).Text = routing.RoutingName;
                (e.Item.FindControl("ltrRoutingChainReviewers") as Literal).Text = routing.ExtendedProperties.RoutingReviewers;
                (e.Item.FindControl("imbEditRoutingChain") as ImageButton).CommandArgument = routing.OrganizationFormRoutingID.ToStringSafe();
                (e.Item.FindControl("imbDeleteRoutingChain") as ImageButton).CommandArgument = routing.OrganizationFormRoutingID.ToStringSafe();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditRoutingChain_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewRoutingID = e.CommandArgument.ToNullable<Int32>();
                Presenter.EditRoutingChain();
                mpModifyReviewChain.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteRoutingChain_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedReviewRoutingID = e.CommandArgument.ToNullable<Int32>();
                Presenter.DeleteRoutingChain();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddRoutingChain_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedReviewRoutingID = null;
                Presenter.EditRoutingChain();
                mpModifyReviewChain.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlOrganizationForwards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                OrganizationForwarding forward = e.Item.DataItem as OrganizationForwarding;

                (e.Item.FindControl("ltrForwardOrganizationName") as Literal).Text = forward.ExtendedProperties.OrganizationName;
                (e.Item.FindControl("ltrForwardRoutingChain") as Literal).Text = forward.ExtendedProperties.RoutingName;
                (e.Item.FindControl("imbEditForwardRoutingChain") as ImageButton).CommandArgument = forward.OrganizationForwardingID.ToStringSafe();
                (e.Item.FindControl("imbDeleteForwardRoutingChain") as ImageButton).CommandArgument = forward.OrganizationForwardingID.ToStringSafe();

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditForwardRoutingChain_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedOrganizationForwardingID = e.CommandArgument.ToNullable<Int32>();
                Presenter.EditForwarding();
                mpModifyForward.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteForwardRoutingChain_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedOrganizationForwardingID = e.CommandArgument.ToNullable<Int32>();
                Presenter.DeleteForwarding();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddForward_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedOrganizationForwardingID = null;
                Presenter.EditForwarding();
                mpModifyForward.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveRouting_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveRouting();
                this.ShowNotice(MessageConstants.SAVE_ROUTING_SUCCESS, NoticeType.Information);
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
                OrganizationFormReviewer reviewer = e.Item.DataItem as OrganizationFormReviewer;

                (e.Item.FindControl("imbReviewOrderMoveUp") as ImageButton).Visible = reviewer.ExtendedProperties.IsFirst != true && reviewer.ExtendedProperties.CanMove == true;
                (e.Item.FindControl("imbReviewOrderMoveUp") as ImageButton).CommandArgument = reviewer.OrganizationFormReviewerID.ToStringSafe();
                (e.Item.FindControl("imbReviewOrderMoveDown") as ImageButton).Visible = reviewer.ExtendedProperties.IsLast != true && reviewer.ExtendedProperties.CanMove == true;
                (e.Item.FindControl("imbReviewOrderMoveDown") as ImageButton).CommandArgument = reviewer.OrganizationFormReviewerID.ToStringSafe();
                (e.Item.FindControl("imbReviewOrderDelete") as ImageButton).CommandArgument = reviewer.OrganizationFormReviewerID.ToStringSafe();
                (e.Item.FindControl("ltrReviewOrderDuty") as Literal).Text = reviewer.ExtendedProperties.OrganizationGroupName;

                DropDownControl ddlReviewOrderRole = e.Item.FindControl("ddlReviewOrderRole") as DropDownControl;

                ddlReviewOrderRole.CommandArgument = reviewer.OrganizationFormReviewerID.ToStringSafe();

                ddlReviewOrderRole.Items.Clear();

                foreach (ReviewRole role in reviewer.ExtendedProperties.ReviewRoles)
                {
                    ddlReviewOrderRole.Items.Add(new ListItem(role.ReviewRoleName, role.ReviewRoleID.ToStringSafe()));
                }

                ddlReviewOrderRole.SelectedValue = reviewer.ReviewRoleID.ToStringSafe();
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
                Presenter.SaveRoutingChain();
                mpModifyReviewChain.Hide();
                this.ShowNotice(MessageConstants.SAVE_ROUTING_CHAIN_SUCCESS, NoticeType.Information);
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
                mpModifyReviewChain.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveReviewForward_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveForwarding();
                mpModifyForward.Hide();
                this.ShowNotice(MessageConstants.SAVE_FORWARDING_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelReviewForward_Click(object sender, EventArgs e)
        {
            try
            {
                mpModifyForward.Hide();
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

        public IList<OrganizationFormRouting> RoutingChains
        {
            get
            {
                return this.ViewState["RoutingChains"] as IList<OrganizationFormRouting>;
            }
            set
            {
                this.ViewState["RoutingChains"] = value;

                dlOrganizationFormRoutings.DataSource = value.Where(x => x.ExtendedProperties.MarkForDeletion != true);
                dlOrganizationFormRoutings.DataBind();
            }
        }

        public String RoutingChainName
        {
            get
            {
                return txtRoutingChain.Text;
            }
            set
            {
                txtRoutingChain.Text = value;
            }
        }

        public Nullable<Int32> SelectedReviewRoutingID
        {
            get
            {
                return this.ViewState["SelectedReviewRoutingID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedReviewRoutingID"] = value;
            }
        }

        public IList<OrganizationFormReviewer> ReviewOrders
        {
            get
            {
                return this.ViewState["ReviewOrders"] as IList<OrganizationFormReviewer>;
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

        public IList<OrganizationForwarding> OrganizationForwards
        {
            get
            {
                return this.ViewState["OrganizationForwards"] as IList<OrganizationForwarding>;
            }
            set
            {
                this.ViewState["OrganizationForwards"] = value;

                dlOrganizationForwards.DataSource = value.Where(x => x.ExtendedProperties.MarkForDeletion != true);
                dlOrganizationForwards.DataBind();
            }
        }

        public Nullable<Int32> SelectedOrganizationForwardingID
        {
            get
            {
                return this.ViewState["SelectedOrganizationForwardingID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedOrganizationForwardingID"] = value;
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
            set
            {
                ddlForwardOrganization.SelectedValue = value.ToStringSafe();
            }
        }

        public IList<OrganizationFormRouting> ForwardRoutingChains
        {
            set
            {
                ddlForwardRouting.Items.Clear();

                foreach (OrganizationFormRouting routing in value)
                {
                    ddlForwardRouting.Items.Add(new ListItem(routing.RoutingName, routing.OrganizationFormRoutingID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> SelectedForwardRoutingID
        {
            get
            {
                return ddlForwardRouting.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlForwardRouting.SelectedValue = value.ToStringSafe();
            }
        }

        public Boolean EnableEdit
        {
            set
            {
                foreach (RepeaterItem item in dlOrganizationFormRoutings.Items)
                {
                    (item.FindControl("imbEditRoutingChain") as ImageButton).Visible = value;
                    (item.FindControl("imbDeleteRoutingChain") as ImageButton).Visible = value;
                }

                btnAddRoutingChain.Visible = value;

                foreach (RepeaterItem item in dlOrganizationForwards.Items)
                {
                    (item.FindControl("imbEditForwardRoutingChain") as ImageButton).Visible = value;
                    (item.FindControl("imbDeleteForwardRoutingChain") as ImageButton).Visible = value;
                }

                btnAddForward.Visible = value;

                btnSaveRouting.Visible = value;
            }
        }
    }
}