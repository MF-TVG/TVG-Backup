using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface IFormListView : IBaseView
    {
        Nullable<Int32> FormTypeID { get; }

        String SortField { get; }

        String SortDirection { get; }

        String FormTitle { set; }

        String ControlName { set; }

        IList<Group> Roles { get; }

        IList<Form> Forms { get; set; }

        Nullable<Int32> StartIndex { get; set; }

        Nullable<Int32> EndIndex { set; }

        Int32 IncrementRange { get; }

        Boolean ShowPrev { set; }

        Boolean ShowNext { set; }
    }
}
