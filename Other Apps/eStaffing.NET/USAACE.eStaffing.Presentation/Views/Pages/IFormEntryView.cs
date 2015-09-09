using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface IFormEntryView : IBaseView
    {
        Nullable<Int32> FormID { get; }

        Nullable<Int32> FormTypeID { get; set; }

        String FormLink { get; }

        String ControlName { set; }

        String FormTitle { set; }

        String FormNumber { set; }

        Nullable<Boolean> Submitted { get; set; }

        Nullable<Boolean> HighPriority { get; set; }

        String SubmitGroupName { set; }

        Nullable<Int32> SubmitGroupID { set; }

        Nullable<Int32> SubmitOrganizationID { set; }

        Boolean EnableEdit { set; }

        Boolean EnableDelete { set; }

        Boolean EnableUndelete { set; }

        Boolean EnableSubmit { set; }

        Boolean EnableImport { set; }

        String ImportSearch { get; set; }

        IList<Form> ImportForms { set; }

        Nullable<Int32> SelectedImportFormID { get; }

        Nullable<Boolean> ImportIncludeAttachments { get; set; }

        IList<Group> Roles { get; }

        String DisplayName { get; }
    }
}
