using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface IPreferencesView : IBaseView
    {
        Nullable<Int32> CurrentUserID { get; set; }

        String UserName { set; }

        String UserAuthenticationType { set; }

        String UserDisplayName { set; }

        String UserEmail { set; }

        String UserRoles { set; }

        Nullable<Boolean> NotifyReject { get; set; }

        Nullable<Boolean> NotifyReview { get; set; }

        Nullable<Boolean> NotifyComplete { get; set; }

        IList<Group> Roles { get; }

        Nullable<Int32> UserID { get; }
    }
}
