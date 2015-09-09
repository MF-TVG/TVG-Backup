using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
    public partial class Organizations : BasePage, IOrganizationsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private OrganizationsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public OrganizationsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new OrganizationsPresenter(this);
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

        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadOrganization();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlOrganizationGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is OrganizationGroup)
                {
                    OrganizationGroup organizationGroup = e.Item.DataItem as OrganizationGroup;

                    (e.Item.FindControl("ltrOrganizationGroupName") as Literal).Text = organizationGroup.OrganizationGroupName;
                    (e.Item.FindControl("ltrOrganizationGroupGroup") as Literal).Text = organizationGroup.ExtendedProperties.GroupName;
                    (e.Item.FindControl("imbEditOrganizationGroup") as ImageButton).CommandArgument = organizationGroup.OrganizationGroupID.ToStringSafe();
                    (e.Item.FindControl("imbDeleteOrganizationGroup") as ImageButton).CommandArgument = organizationGroup.OrganizationGroupID.ToStringSafe();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditOrganizationGroup_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedOrganizationGroupID = e.CommandArgument.ToNullable<Int32>();
                Presenter.LoadSelectedOrganizationGroup();
                mpEditOrganizationGroup.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveOrganizationGroup_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveSelectedOrganizationGroup();
                mpEditOrganizationGroup.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelOrganizationGroup_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditOrganizationGroup.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteOrganizationGroup_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedOrganizationGroupID = e.CommandArgument.ToNullable<Int32>();
                mpDeleteOrganizationGroupConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteOrganizationGroupConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteSelectedOrganizationGroup();
                mpDeleteOrganizationGroupConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteOrganizationGroupCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteOrganizationGroupConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddOrganizationGroup_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedOrganizationGroupID = null;
                Presenter.LoadSelectedOrganizationGroup();
                mpEditOrganizationGroup.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveOrganization_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();
                base.ShowNotice(MessageConstants.SAVE_ORGANIZATION_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<Organization> OrganizationList
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

        public Nullable<Int32> OrganizationID
        {
            get
            {
                return ddlOrganization.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlOrganization.SelectedValue = value.ToStringSafe();
            }
        }

        public String OrganizationName
        {
            get
            {
                return txtOrganizationName.Text;
            }
            set
            {
                txtOrganizationName.Text = value;
            }
        }

        public IList<OrganizationGroup> OrganizationGroups
        {
            get
            {
                return this.ViewState["OrganizationGroups"] as IList<OrganizationGroup>;
            }
            set
            {
                this.ViewState["OrganizationGroups"] = value;

                dlOrganizationGroups.DataSource = value.Where(x => x.ExtendedProperties.MarkForDeletion != true);
                dlOrganizationGroups.DataBind();
            }
        }

        public Nullable<Int32> SelectedOrganizationGroupID
        {
            get
            {
                return this.ViewState["SelectedOrganizationGroupID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedOrganizationGroupID"] = value;
            }
        }

        public String OrganizationGroupName
        {
            get
            {
                return txtOrganizationGroupName.Text;
            }
            set
            {
                txtOrganizationGroupName.Text = value;
            }
        }

        public IList<Group> Groups
        {
            set
            {
                ddlGroup.Items.Clear();

                foreach (Group group in value)
                {
                    ddlGroup.Items.Add(new ListItem(group.GroupName, group.GroupID.ToStringSafe()));
                }
            }
        }

        public Nullable<Int32> OrganizationGroupGroupID
        {
            get
            {
                return ddlGroup.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                ddlGroup.SelectedValue = value.ToStringSafe();
            }
        }

        public String OrganizationGroupGroupName
        {
            get
            {
                return this.OrganizationGroupGroupID.HasValue ? ddlGroup.SelectedItem.Text : String.Empty;
            }
        }

        public Boolean EnableEdit
        {
            set
            {
                txtOrganizationName.Enabled = value;

                foreach (RepeaterItem item in dlOrganizationGroups.Items)
                {
                    (item.FindControl("imbEditOrganizationGroup") as ImageButton).Visible = value;
                    (item.FindControl("imbDeleteOrganizationGroup") as ImageButton).Visible = value;
                }

                btnAddOrganizationGroup.Visible = value;
                btnSaveOrganization.Visible = value;
            }
        }
    }
}