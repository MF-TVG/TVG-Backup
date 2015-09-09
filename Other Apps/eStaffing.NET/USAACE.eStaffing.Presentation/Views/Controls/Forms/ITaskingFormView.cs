using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface ITaskingFormView : IFormControlView
    {
        String TaskNumber { get; set; }

        String ECCNumber { get; set; }

        IList<TaskingType> TaskingTypes { set; }

        String SelectedTaskingType { get; set; }

        IList<TaskingSource> TaskingSources { set; }

        String SelectedTaskingSource { get; set; }

        String SourcePOC { get; set; }

        String Subject { get; set; }

        String ActionOfficer { get; set; }

        String PhoneNumber { get; set; }

        String OfficeSymbol { get; set; }

        Nullable<DateTime> SuspenseDate { get; set; }

        Nullable<DateTime> TaskingDate { get; set; }

        String SelectedTaskingDocumentType { get; set; }

        IList<TaskingDocumentType> TaskingDocumentTypes { set; }

        String SelectedTaskingActionType { get; set; }

        IList<TaskingActionType> TaskingActionTypes { set; }

        String SelectedTaskingSecurityLevel { get; set; }

        IList<TaskingSecurityLevel> TaskingSecurityLevels { set; }

        String SelectedTaskingLocation { get; set; }

        IList<TaskingLocation> TaskingLocations { set; }

        String SelectedTaskerLocation { get; set; }

        String WhereWhenWhatWhyHow { get; set; }

        String CoordinatingInstructions { get; set; }

        String TaskPOC { get; set; }

        String TaskNotes { get; set; }
    }
}
