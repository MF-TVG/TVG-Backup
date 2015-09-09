using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface IRoutingView : IBaseView
    {
        IList<Organization> Organizations { set; }

        Nullable<Int32> SelectedOrganization { get; }

        IList<FormType> FormTypes { set; }

        Nullable<Int32> SelectedFormType { get; }

        Boolean ShowData { set; }

        IList<OrganizationFormRouting> RoutingChains { get; set; }

        String RoutingChainName { get; set; }

        Nullable<Int32> SelectedReviewRoutingID { get; set; }

        IList<OrganizationFormReviewer> ReviewOrders { get; set; }

        Nullable<Int32> SelectedReviewOrderID { get; set; }

        Nullable<Int32> SelectedReviewOrderRoleID { get; set; }

        IList<OrganizationFormActor> ReviewOrderGroups { set; }

        IList<Nullable<Int32>> SelectedReviewGroupsID { get; set; }

        IList<ReviewRole> ReviewOrderRoles { set; }

        Nullable<Int32> SelectedReviewRoleID { get; set; }

        IList<OrganizationForwarding> OrganizationForwards { get; set; }

        Nullable<Int32> SelectedOrganizationForwardingID { get; set; }

        IList<Organization> ForwardOrganizations { set; }

        Nullable<Int32> SelectedForwardOrganizationID { get; set; }

        IList<OrganizationFormRouting> ForwardRoutingChains { set; }

        Nullable<Int32> SelectedForwardRoutingID { get; set; }

        Boolean EnableEdit { set; }

        IList<Group> Roles { get; }
    }
}
