using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface IOrganizationsView : IBaseView
    {
        IList<Organization> OrganizationList { set; }

        Nullable<Int32> OrganizationID { get; set; }

        String OrganizationName { get; set; }

        IList<OrganizationGroup> OrganizationGroups { get; set; }

        Nullable<Int32> SelectedOrganizationGroupID { get; }

        String OrganizationGroupName { get; set; }

        IList<Group> Groups { set; }

        Nullable<Int32> OrganizationGroupGroupID { get; set; }

        String OrganizationGroupGroupName { get; }

        Boolean EnableEdit { set; }

        IList<Group> Roles { get; }
    }
}
