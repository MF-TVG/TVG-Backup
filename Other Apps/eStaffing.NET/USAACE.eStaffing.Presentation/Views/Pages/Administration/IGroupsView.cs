using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface IGroupsView : IBaseView
    {
        IList<Group> GroupList { set; }

        Nullable<Int32> GroupID { get; set; }

        String GroupName { get; set; }

        IList<GroupUser> GroupUsers { get; set; }

        Nullable<Int32> SelectedGroupUserID { get; }

        Boolean EnableUserSelect { set; }

        String UserName { get; set;  }

        Nullable<Int32> UserSystemID { get; set; }

        IList<User> UserChoices { set; }

        String UserSelectedChoice { get; }

        Boolean UserShowChoices { set; }

        String UserDisplayName { get; set; }

        String UserEmailAddress { get; set; }

        String UserSID { get; set; }

        String UserAuthenticationType { get; set; }

        Nullable<Boolean> UserIsADGroup { get; set; }

        Nullable<Boolean> UserMember { get; set; }

        Nullable<Boolean> UserAdmin { get; set; }

        Boolean EnableEdit { set; }

        Boolean EnableDelete { set; }

        Boolean EnableGroupNameEdit { set; }

        IList<Group> Roles { get; }
    }
}
