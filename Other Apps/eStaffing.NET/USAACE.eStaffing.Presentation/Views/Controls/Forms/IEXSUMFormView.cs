using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface IEXSUMFormView : IFormControlView
    {
        Nullable<DateTime> EXSUMDate { get; set; }

        String EXSUMTitle { get; set; }

        String Issues { get; set; }

        String CurrentStatus { get; set; }

        String FutureStatus { get; set; }

        String PointOfContact { get; set; }

        String AdditionalInfo { get; set; }
    }
}
