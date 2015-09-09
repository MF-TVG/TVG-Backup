using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;

namespace USAACE.eStaffing.Presentation.Presenters.Pages.Administration
{
    public class GroupsPresenter : BasePresenter
    {
        /// <summary>
        /// The IGroupsView for the GroupsPresenter
        /// </summary>
        private new IGroupsView View
        {
            get
            {
                return base.View as IGroupsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IGroupsView
        /// </summary>
        /// <param name="view">The IGroupsView</param>
        public GroupsPresenter(IGroupsView view)
        {
            base.View = view;
        }

        public void Load()
        {
            Boolean isAdmin = PermissionUtil.CheckAdminPermission(this.View.Roles);

            IList<Group> groupList = DataService.GetGroups().Where(x => isAdmin || PermissionUtil.CheckGroupViewPermission(x, this.View.Roles)).OrderBy(x => x.GroupName).ToList();

            if (PermissionUtil.CheckAdminPermission(this.View.Roles))
            {
                groupList.Insert(0, new Group { GroupName = "-- New Group --" });
            }

            if (groupList.Count > 0)
            {
                this.View.GroupList = groupList;

                LoadGroup();
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
        }

        public void LoadGroup()
        {
            if (this.View.GroupID.HasValue)
            {
                Group group = new Group();
                group.GroupID = this.View.GroupID;

                group = DataService.LoadGroup(group);

                this.View.GroupName = group.GroupName;

                GroupUser groupUser = new GroupUser();
                groupUser.GroupID = this.View.GroupID;

                IList<User> users = DataService.ListUsers();

                IList<GroupUser> groupUsers = DataService.ListGroupUsers(groupUser);

                Boolean isAdmin = PermissionUtil.CheckAdminPermission(this.View.Roles);

                Boolean enableEdit = isAdmin || PermissionUtil.CheckGroupEditPermission(group, this.View.Roles);

                foreach (GroupUser userItem in groupUsers)
                {
                    if (userItem.UserID.HasValue)
                    {
                        User user = users.FirstOrDefault(x => x.UserID == userItem.UserID);

                        userItem.ExtendedProperties.AuthenticationType = user.AuthenticationType;
                        userItem.ExtendedProperties.UserName = user.UserName;
                        userItem.ExtendedProperties.DisplayName = user.UserDisplayName;
                        userItem.ExtendedProperties.EmailAddress = user.UserEmail;
                        userItem.ExtendedProperties.IsADGroup = user.IsADGroup;
                    }
                }

                this.View.GroupUsers = groupUsers;

                this.View.EnableEdit = enableEdit;
                this.View.EnableDelete = group.GroupName != PermissionUtil.ADMINISTRATOR_GROUP && isAdmin;
                this.View.EnableGroupNameEdit = group.GroupName != PermissionUtil.ADMINISTRATOR_GROUP && enableEdit;
            }
            else
            {
                this.View.GroupName = null;
                this.View.GroupUsers = new List<GroupUser>();

                Boolean enableEdit = PermissionUtil.CheckAdminPermission(this.View.Roles);

                this.View.EnableEdit = enableEdit;
                this.View.EnableDelete = false;
                this.View.EnableGroupNameEdit = enableEdit;
            }
        }

        public void LoadGroupUser()
        {
            if (this.View.SelectedGroupUserID.HasValue)
            {
                IList<GroupUser> groupUsers = this.View.GroupUsers;

                GroupUser groupUser = groupUsers.FirstOrDefault(x => x.GroupUserID == this.View.SelectedGroupUserID);

                this.View.UserName = groupUser.ExtendedProperties.UserName;
                this.View.UserSystemID = groupUser.UserID;
                this.View.UserDisplayName = groupUser.ExtendedProperties.DisplayName;
                this.View.UserEmailAddress = groupUser.ExtendedProperties.EmailAddress;
                this.View.UserMember = groupUser.Member;
                this.View.UserAdmin = groupUser.Admin;

                this.View.EnableUserSelect = false;
            }
            else
            {
                this.View.UserName = null;
                this.View.UserSystemID = null;
                this.View.UserDisplayName = null;
                this.View.UserEmailAddress = null;
                this.View.UserMember = null;
                this.View.UserAdmin = null;
                this.View.UserSID = null;
                this.View.UserAuthenticationType = null;
                this.View.UserIsADGroup = null;

                this.View.EnableUserSelect = true;
            }
        }

        public void SaveGroupUser()
        {
            if (!String.IsNullOrEmpty(this.View.UserName))
            {
                if (this.View.SelectedGroupUserID.HasValue)
                {
                    IList<GroupUser> groupUsers = this.View.GroupUsers;

                    GroupUser groupUser = groupUsers.FirstOrDefault(x => x.GroupUserID == this.View.SelectedGroupUserID);

                    groupUser.Member = this.View.UserMember;
                    groupUser.Admin = this.View.UserAdmin;

                    this.View.GroupUsers = groupUsers;
                }
                else
                {
                    IList<GroupUser> groupUsers = this.View.GroupUsers;

                    if (!groupUsers.Any(x => x.ExtendedProperties.UserName == this.View.UserName))
                    {
                        Int32 newId = -1 * groupUsers.Count(x => x.GroupUserID < 0) - 1;

                        GroupUser groupUser = new GroupUser();
                        groupUser.GroupUserID = newId;
                        groupUser.UserID = this.View.UserSystemID;
                        groupUser.ExtendedProperties.UserName = this.View.UserName;
                        groupUser.ExtendedProperties.AuthenticationType = this.View.UserAuthenticationType;
                        groupUser.ExtendedProperties.DisplayName = this.View.UserDisplayName;
                        groupUser.ExtendedProperties.EmailAddress = this.View.UserEmailAddress;
                        groupUser.ExtendedProperties.SID = this.View.UserSID;
                        groupUser.ExtendedProperties.IsADGroup = this.View.UserIsADGroup;
                        groupUser.Member = this.View.UserMember;
                        groupUser.Admin = this.View.UserAdmin;

                        groupUsers.Add(groupUser);

                        this.View.GroupUsers = groupUsers;
                    }
                    else if (groupUsers.Any(x => x.ExtendedProperties.UserName == this.View.UserName && x.ExtendedProperties.MarkForDeletion != true))
                    {
                        GroupUser groupUser = groupUsers.FirstOrDefault(x => x.ExtendedProperties.UserName == this.View.UserName);

                        groupUser.ExtendedProperties.MarkForDeletion = null;
                        groupUser.UserID = this.View.UserSystemID;
                        groupUser.ExtendedProperties.UserName = this.View.UserName;
                        groupUser.ExtendedProperties.AuthenticationType = this.View.UserAuthenticationType;
                        groupUser.ExtendedProperties.DisplayName = this.View.UserDisplayName;
                        groupUser.ExtendedProperties.EmailAddress = this.View.UserEmailAddress;
                        groupUser.ExtendedProperties.SID = this.View.UserSID;
                        groupUser.ExtendedProperties.IsADGroup = this.View.UserIsADGroup;
                        groupUser.Member = this.View.UserMember;
                        groupUser.Admin = this.View.UserAdmin;

                        this.View.GroupUsers = groupUsers;
                    }
                }
            }
        }

        public void DeleteGroupUser()
        {
            if (this.View.SelectedGroupUserID.HasValue)
            {
                IList<GroupUser> groupUsers = this.View.GroupUsers;

                GroupUser groupUser = groupUsers.FirstOrDefault(x => x.GroupUserID == this.View.SelectedGroupUserID);
                groupUser.ExtendedProperties.MarkForDeletion = true;

                this.View.GroupUsers = groupUsers;
            }
        }

        public void LookupUser()
        {
            if (!String.IsNullOrEmpty(this.View.UserName))
            {
                if (this.View.UserName.ToNullable<Int32>().HasValue)
                {
                    User user = new User();
                    user.UserID = this.View.UserName.ToNullable<Int32>();

                    user = DataService.LoadUser(user);

                    this.View.UserSystemID = user.UserID;
                    this.View.UserName = user.UserName;
                    this.View.UserAuthenticationType = user.AuthenticationType;
                    this.View.UserDisplayName = user.UserDisplayName;
                    this.View.UserEmailAddress = user.UserEmail;
                    this.View.UserSID = user.UserSID;
                    this.View.UserIsADGroup = user.IsADGroup;

                    this.View.UserShowChoices = false;
                }
                else
                {
                    IList<User> searchResults = UserService.SearchUser(this.View.UserName);

                    if (searchResults.Count == 0)
                    {
                        this.View.UserShowChoices = false;
                    }
                    else if (searchResults.Count == 1)
                    {
                        User user = searchResults[0];

                        this.View.UserSystemID = user.UserID;
                        this.View.UserName = user.UserName;
                        this.View.UserAuthenticationType = user.AuthenticationType;
                        this.View.UserDisplayName = user.UserDisplayName;
                        this.View.UserEmailAddress = user.UserEmail;
                        this.View.UserSID = user.UserSID;
                        this.View.UserIsADGroup = user.IsADGroup;

                        this.View.UserShowChoices = false;
                    }
                    else
                    {
                        this.View.UserChoices = searchResults;
                        this.View.UserShowChoices = true;
                    }
                }
            }
            else
            {
                this.View.UserSystemID = null;
                this.View.UserName = null;
                this.View.UserAuthenticationType = null;
                this.View.UserDisplayName = null;
                this.View.UserEmailAddress = null;
                this.View.UserSID = null;
            }
        }

        public void Save()
        {
            Group group = new Group();

            if (this.View.GroupID.HasValue)
            {
                group.GroupID = this.View.GroupID;
                group = DataService.LoadGroup(group);
            }

            if (DataService.GetGroups().Any(x => x.GroupID != this.View.GroupID && x.GroupName == this.View.GroupName))
            {
                throw new USAACEException(ExceptionType.Recoverable, MessageConstants.SAVE_GROUP_DUPLICATE);
            }
            else
            {
                group.GroupName = this.View.GroupName;

                group = DataService.SaveGroup(group);

                foreach (GroupUser groupUser in this.View.GroupUsers)
                {
                    if (groupUser.ExtendedProperties.MarkForDeletion != true)
                    {
                        if (groupUser.GroupUserID < 0)
                        {
                            groupUser.GroupUserID = null;
                        }

                        if (groupUser.UserID == null)
                        {
                            User user = new User();

                            user.AuthenticationType = groupUser.ExtendedProperties.AuthenticationType;
                            user.UserName = groupUser.ExtendedProperties.UserName;
                            user.UserDisplayName = groupUser.ExtendedProperties.DisplayName;
                            user.UserSID = groupUser.ExtendedProperties.SID;
                            user.UserEmail = groupUser.ExtendedProperties.EmailAddress;
                            user.IsADGroup = groupUser.ExtendedProperties.IsADGroup;

                            user = DataService.SaveUser(user);

                            groupUser.UserID = user.UserID;
                        }

                        groupUser.GroupID = group.GroupID;
                        DataService.SaveGroupUser(groupUser);
                    }
                    else
                    {
                        if (groupUser.GroupUserID > 0)
                        {
                            DataService.DeleteGroupUser(groupUser);
                        }
                    }
                }

                this.View.GroupList = DataService.GetGroups().OrderBy(x => x.GroupName).ToList();
                this.View.GroupID = group.GroupID;

                LoadGroup();
            }
        }

        public void DeleteGroup()
        {
            if (this.View.GroupID.HasValue)
            {
                Group group = new Group();

                group.GroupID = this.View.GroupID;
                DataService.DeleteGroup(group);

                Load();
            }
        }

        public void SelectUser()
        {
            this.View.UserName = this.View.UserSelectedChoice;

            LookupUser();
        }
    }
}
