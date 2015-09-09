using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Controls
{
    public interface IFormListControlView : IBaseView
    {
        IList<Form> Forms { get; set; }

        Nullable<Int32> StartIndex { get; }

        Int32 IncrementRange { get; }
    }
}
