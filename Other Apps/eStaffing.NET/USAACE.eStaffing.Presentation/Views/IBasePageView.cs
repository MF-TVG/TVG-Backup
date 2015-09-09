using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views
{
    public interface IBasePageView : IBaseView
    {
        IPrincipal CurrentUser { get; }

        String DisplayName { get; set; }

        Nullable<Int32> UserID { get; set; }

        String AuthenticationType { get; }

        IList<Group> Roles { set; }

        Exception LastError { get; }

        String CurrentLocation { get; }

        Boolean ShowLogout { set; }
    }
}