using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the CalendarView
    /// </summary>
    public interface ICalendarView : IBaseView
    {
        /// <summary>
        /// Current fiscal year selection
        /// </summary>
        Nullable<Int32> FiscalYear { get; set; }

        /// <summary>
        /// Current mobilization show/hide selection
        /// </summary>
        Boolean ShowMobilization { get; }

        /// <summary>
        /// The dictionary of no fly days by date
        /// </summary>
        IDictionary<DateTime, NoFlyType> NoFlyDays { get; set; }

        /// <summary>
        /// The list of no fly types
        /// </summary>
        IList<NoFlyType> NoFlyTypes { set; }
    }
}
