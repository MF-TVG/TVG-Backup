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
    public partial class Groups : BasePage, IGroupsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private GroupsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public GroupsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new GroupsPresenter(this);
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

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadGroup();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlGroupUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is GroupUser)
                {
                    GroupUser groupUser = e.Item.DataItem as GroupUser;

                    (e.Item.FindControl("ltrUserName") as Literal).Text = groupUser.ExtendedProperties.UserName;
                    (e.Item.FindControl("ltrUserID") as Literal).Text = groupUser.UserID.ToStringSafe();
                    (e.Item.FindControl("ltrUserDisplayName") as Literal).Text = groupUser.ExtendedProperties.DisplayName;
                    (e.Item.FindControl("ltrUserEmailAddress") as Literal).Text = groupUser.ExtendedProperties.EmailAddress;
                    (e.Item.FindControl("imgUserMember") as Image).Visible = groupUser.Member == true;
                    (e.Item.FindControl("imgUserAdmin") as Image).Visible = groupUser.Admin == true;
                    (e.Item.FindControl("imbEditGroupUser") as ImageButton).CommandArgument = groupUser.GroupUserID.ToStringSafe();
                    (e.Item.FindControl("imbDeleteGroupUser") as ImageButton).CommandArgument = groupUser.GroupUserID.ToStringSafe();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditGroupUser_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedGroupUserID = e.CommandArgument.ToNullable<Int32>();
                Presenter.LoadGroupUser();
                mpEditUser.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteGroupUser_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedGroupUserID = e.CommandArgument.ToNullable<Int32>();
                mpDeleteGroupUserConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteGroupUserConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteGroupUser();
                mpDeleteGroupUserConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteGroupUserCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteGroupUserConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddGroupUser_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedGroupUserID = null;
                Presenter.LoadGroupUser();
                mpEditUser.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imgUserCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.LookupUser();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveGroupUser();
                mpEditUser.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelUser_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditUser.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();
                base.ShowNotice(MessageConstants.SAVE_GROUP_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteGroupConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteGroupConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteGroup();
                mpDeleteGroupConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteGroupCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteGroupConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SelectUser();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public IList<Group> GroupList
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

        public Nullable<Int32> GroupID
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

        public String GroupName
        {
            get
            {
                return txtGroupName.Text;
            }
            set
            {
                txtGroupName.Text = value;
            }
        }

        public IList<GroupUser> GroupUsers
        {
            get
            {
                return this.ViewState["GroupUsers"] as IList<GroupUser>;
            }
            set
            {
                this.ViewState["GroupUsers"] = value;

                dlGroupUsers.DataSource = value.Where(x => x.ExtendedProperties.MarkForDeletion != true);
                dlGroupUsers.DataBind();
            }
        }

        public Nullable<Int32> SelectedGroupUserID
        {
            get
            {
                return this.ViewState["SelectedGroupUserID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedGroupUserID"] = value;
            }
        }

        public Boolean EnableUserSelect
        {
            set
            {
                trFindNewUser.Visible = value;
            }
        }

        public String UserName
        {
            get
            {
                return txtUserName.Text;
            }
            set
            {
                txtUserName.Text = value;
            }
        }

        public Nullable<Int32> UserSystemID
        {
            get
            {
                return lblUserID.Text.ToNullable<Int32>();
            }
            set
            {
                lblUserID.Text = value.ToStringSafe();
            }
        }

        public String UserDisplayName
        {
            get
            {
                return lblUserDisplayName.Text;
            }
            set
            {
                lblUserDisplayName.Text = value;
            }
        }

        public String UserEmailAddress
        {
            get
            {
                return lblUserEmailAddress.Text;
            }
            set
            {
                lblUserEmailAddress.Text = value;
            }
        }

        public String UserSID
        {
            get
            {
                return hdfUserSID.Value;
            }
            set
            {
                hdfUserSID.Value = value;
            }
        }

        public String UserAuthenticationType
        {
            get
            {
                return hdfUserAuthenticationType.Value;
            }
            set
            {
                hdfUserAuthenticationType.Value = value;
            }
        }

        public Nullable<Boolean> UserIsADGroup
        {
            get
            {
                return hdfUserIsADGroup.Value.ToNullable<Boolean>();
            }
            set
            {
                hdfUserIsADGroup.Value = value.ToStringSafe();
            }
        }

        public Nullable<Boolean> UserMember
        {
            get
            {
                return chkUserMember.Checked;
            }
            set
            {
                chkUserMember.Checked = value == true;
            }
        }

        public Nullable<Boolean> UserAdmin
        {
            get
            {
                return chkUserAdmin.Checked;
            }
            set
            {
                chkUserAdmin.Checked = value == true;
            }
        }

        public IList<User> UserChoices
        {
            set
            {
                lstUsers.Items.Clear();

                foreach (User user in value)
                {
                    lstUsers.Items.Add(new ListItem(user.UserDisplayName, user.UserID.HasValue ? user.UserID.Value.ToString() : user.UserName));
                }
            }
        }

        public String UserSelectedChoice
        {
            get
            {
                return lstUsers.SelectedValue;
            }
        }

        public Boolean UserShowChoices
        {
            set
            {
                lstUsers.Visible = value;
            }
        }

        public Boolean EnableEdit
        {
            set
            {
                btnSaveGroup.Visible = value;
                btnAddGroupUser.Visible = value;

                foreach (RepeaterItem item in dlGroupUsers.Items)
                {
                    (item.FindControl("imbEditGroupUser") as ImageButton).Visible = value;
                    (item.FindControl("imbDeleteGroupUser") as ImageButton).Visible = value;
                }
            }
        }

        public Boolean EnableDelete
        {
            set
            {
                btnDeleteGroup.Visible = value;
            }
        }

        public Boolean EnableGroupNameEdit
        {
            set
            {
                txtGroupName.Enabled = value;
            }
        }
    }
}