using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface INewFormView : IBaseView
    {
        IList<FormType> FormTypes { set; }

        Nullable<Int32> SelectedFormTypeID { get; }

        IList<OrganizationGroup> SubmitGroups { set; }

        Nullable<Int32> SelectedSubmitGroupID { get; }

        String SubmitOrganization { set; }

        IList<OrganizationFormRouting> RoutingChains { set; }

        Nullable<Int32> SelectedRoutingID { get; }

        Nullable<Int32> FormID { set; }

        IList<Group> Roles { get; }
    }
}
