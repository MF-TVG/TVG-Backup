using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface ITrackingView : IBaseView
    {
        IList<FormType> FormTypes { set; }

        IList<Nullable<Int32>> SelectedFormTypes { get; }

        Nullable<DateTime> SuspenseDateStart { get; }

        Nullable<DateTime> SuspenseDateEnd { get; }

        IList<OrganizationGroup> ReviewGroups { set; }

        IList<Nullable<Int32>> SelectedReviewGroups { get; }

        Nullable<DateTime> SubmitDateStart { get; }

        Nullable<DateTime> SubmitDateEnd { get; }

        IList<FormStatus> FormStatuses { set; }

        IList<Nullable<Int32>> SelectedFormStatuses { get; }

        IList<Organization> Organizations { set; }

        Nullable<Int32> SelectedOrganization { get; }

        String Subject { get; }

        Boolean ShowDashboard { set; }

        IList<Form> Forms { set; }

        IList<OrganizationGroup> MetricsQueued { set; }

        IList<OrganizationGroup> MetricsReview { set; }

        IList<OrganizationGroup> MetricsNearDue { set; }

        IList<OrganizationGroup> MetricsPastDue { set; }

        IList<OrganizationGroup> MetricsCompleted { set; }

        IList<OrganizationGroup> MetricsRejected { set; }

        IList<OrganizationGroup> MetricsTotal { set; }

        IList<Group> Roles { get; }
    }
}
