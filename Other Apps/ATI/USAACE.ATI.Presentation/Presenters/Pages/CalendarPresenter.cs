using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Presentation;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Domain.Entities;
using System.Collections;
using USAACE.ATI.Business.Util;
using USAACE.ATI.Business.Services;

namespace USAACE.ATI.Presentation.Presenters.Pages
{
    /// <summary>
    /// Presenter for the CalendarView
    /// </summary>
    public class CalendarPresenter : BasePresenter
    {
        /// <summary>
        /// The CalendarView for the CalendarPresenter
        /// </summary>
        public new ICalendarView View
        {
            get
            {
                return base.View as ICalendarView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the CalendarView
        /// </summary>
        /// <param name="view">The CalendarView</param>
        public CalendarPresenter(ICalendarView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.NoFlyTypes = DataService.ListNoFlyTypes().OrderBy(x => x.NoFlyTypeName).ToList();
            this.View.FiscalYear = CalendarUtil.GetFiscalYear(DateTime.Now);

            LoadNoFlyDays();
        }

        /// <summary>
        /// Loads the no fly days
        /// </summary>
        public void LoadNoFlyDays()
        {
            IDictionary<DateTime, NoFlyType> noFlyDays = new Dictionary<DateTime, NoFlyType>();

            DateTime nextFiscalYear = CalendarUtil.GetFiscalYearStart(this.View.FiscalYear.Value + 1);

            DateTime currentDay = CalendarUtil.GetFiscalYearStart(this.View.FiscalYear.Value);

            while (currentDay < nextFiscalYear)
            {
                NoFlyType noFlyType = CalendarUtil.GetNoFlyType(currentDay, this.View.ShowMobilization);

                if (noFlyType != null)
                {
                    noFlyDays.Add(new KeyValuePair<DateTime, NoFlyType>(new DateTime(currentDay.Year, currentDay.Month, currentDay.Day), noFlyType));
                }

                currentDay = currentDay.AddDays(1);
            }

            this.View.NoFlyDays = noFlyDays;
        }

        /// <summary>
        /// Increments the fiscal year
        /// </summary>
        public void IncrementFiscalYear()
        {
            this.View.FiscalYear += 1;

            LoadNoFlyDays();
        }

        /// <summary>
        /// Decrements the fiscal year
        /// </summary>
        public void DecrementFiscalYear()
        {
            this.View.FiscalYear -= 1;

            LoadNoFlyDays();
        }
    }
}
