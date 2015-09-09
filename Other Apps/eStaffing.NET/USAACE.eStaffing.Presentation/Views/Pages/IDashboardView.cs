using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface IDashboardView : IBaseView
    {
        IList<FormStatus> FormStatuses { set; }

        IList<Nullable<Int32>> SelectedFormStatuses { get; }

        Boolean MyReviewOnly { get; }

        String SubjectFilter { get; }

        String SortField { get; }

        String SortDirection { get; }

        IList<Form> SubmitForms { set; }

        IList<Form> ReviewForms { set; }

        IList<Group> Roles { get; }
    }
}
