using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface ISystemView : IBaseView
    {
        IList<FormType> FormTypeList { set; }

        Nullable<Int32> FormTypeID { get; set; }

        String FormTypeName { get; set; }

        IList<String> SuspenseDateFields { set; }

        String SelectedSuspenseDateField { get; set; }

        IList<String> SubjectFields { set; }

        String SelectedSubjectField { get; set; }

        IList<String> FormNumberFields { set; }

        String SelectedFormNumberField { get; set; }

        IList<FormActionType> FormActionTypes { set; }

        Nullable<Int32> SelectedFormActionType { get; set; }

        IList<Group> Roles { get; }
    }
}
