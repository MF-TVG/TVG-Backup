using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface IFormSettingsView : IBaseView
    {
        IList<Organization> Organizations { set; }

        Nullable<Int32> SelectedOrganization { get; }

        IList<FormType> FormTypes { set; }

        Nullable<Int32> SelectedFormType { get; }

        Boolean ShowData { set; }

        Nullable<Boolean> ParallelReview { get; set; }

        Nullable<Int16> PastDueDays { get; set; }

        Nullable<Int16> NearDueDays { get; set; }

        Nullable<Int16> SuspenseAdjust { get; set; }

        IList<OrganizationFormActor> Actors { get; set; }

        Nullable<Int32> SelectedFormActorID { get; }

        String SelectedFormActorName { set; }

        Nullable<Boolean> CanAdmin { get; set; }

        Nullable<Boolean> CanSubmit { get; set; }

        Nullable<Boolean> CanReview { get; set; }

        Nullable<Boolean> CanChooseRoute { get; set; }

        Nullable<Boolean> CanChangeRoute { get; set; }

        Nullable<Boolean> CanEditSubmission { get; set; }

        Nullable<Boolean> CanForward { get; set; }

        Nullable<Boolean> CanSeeComments { get; set; }

        Nullable<Boolean> CanViewAll { get; set; }

        Nullable<Boolean> CanAssignAutopen { get; set; }

        Nullable<Boolean> MustReview { get; set; }

        Nullable<Boolean> NotifyComplete { get; set; }

        String SelectedNoticeType { get; }

        String ReviewSubject { get; set; }

        String ReviewMessage { get; set; }

        String RejectSubject { get; set; }

        String RejectMessage { get; set; }

        String CompleteSubject { get; set; }

        String CompleteMessage { get; set; }

        String EditSubject { get; set; }

        String EditMessage { get; set; }

        Boolean EnableEdit { set; }

        IList<Group> Roles { get; }
    }
}
