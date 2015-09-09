using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Controls.FormControls
{
    public interface IReviewerControlView : IFormControlView
    {
        Nullable<Int32> SelectedReviewStatusID { get; }

        IList<Organization> ReviewOrganizations { set; }

        IDictionary<String, IList<ReviewStatus>> ReviewStatuses { get; set; }

        IList<ReviewStatus> CurrentReviewStatuses { set; }

        Boolean CanModifyOrder { set; }

        Boolean CanForward { set; }

        IList<FormLog> LogItems { set; }

        String SelectedTab { get; set; }

        Boolean ShowReview { set; }

        Boolean ShowActionLog { set; }

        IList<ReviewAction> ReviewActions { set; }

        String ReviewDuty { set; }

        Nullable<Int32> SelectedReviewAction { get; set; }

        Boolean ReviewIsRejection { set; }

        Nullable<DateTime> ReviewDate { get; set; }

        Nullable<Boolean> ReviewSigned { get; set; }

        Nullable<Boolean> ReviewAutopen { get; set; }

        String ReviewRemarks { get; set; }

        Boolean ReviewCanAutopen { set; }

        Boolean ReviewCanAdmin { set; }

        String SignatureSubject { set; }

        Nullable<DateTime> SignatureDate { set; }

        Boolean SignatureValid { set; }

        String SignatureFormHash { set; }

        String SignatureData { get; }

        Nullable<Boolean> SignaturePresent { get; set; }

        Boolean SignatureEnable { set; }

        IList<ReviewStatus> ReviewOrders { get; set; }

        Nullable<Int32> SelectedReviewOrderID { get; set; }

        Nullable<Int32> SelectedReviewOrderRoleID { get; set; }

        IList<OrganizationFormActor> ReviewOrderGroups { set; }

        IList<Nullable<Int32>> SelectedReviewGroupsID { get; set; }

        IList<ReviewRole> ReviewOrderRoles { set; }

        Nullable<Int32> SelectedReviewRoleID { get; set; }

        IList<Organization> ForwardOrganizations { set; }

        Nullable<Int32> SelectedForwardOrganizationID { get; }

        IList<OrganizationFormRouting> ForwardRoutingChains { set; }

        Nullable<Int32> SelectedForwardRoutingID { get; }

        String SignatureViewSubject { set; }

        Nullable<DateTime> SignatureViewDate { set; }

        Boolean SignatureViewValid { set; }
    }
}
