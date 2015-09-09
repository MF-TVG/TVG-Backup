using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Presentation.Presenters.Pages;
using USAACE.Common;

namespace USAACE.ATI.Web.Pages
{
    public partial class Calendar : BasePage, ICalendarView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private CalendarPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public CalendarPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new CalendarPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Loads the control
        /// </summary>
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();
                    InitializeCalendar();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the mobilization check box is checked or unchecked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void chkMobilization_Checked(object sender, EventArgs e)
        {
            try
            {
                Presenter.Load();
                InitializeCalendar();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when a day in the calendar is rendered
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The calendar day arguments of the event</param>
        protected void calCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                if (this.NoFlyDays.ContainsKey(e.Day.Date))
                {
                    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml(String.Format("#{0}", this.NoFlyDays[e.Day.Date].NoFlyTypeColor));
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when an item is bound to the no fly types data list
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The data list item arguments of the event</param>
        protected void dlNoFlyTypes_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is NoFlyType)
                {
                    NoFlyType type = e.Item.DataItem as NoFlyType;

                    (e.Item.FindControl("pnlNoFlyTypeColor") as Panel).BackColor = System.Drawing.ColorTranslator.FromHtml(String.Format("#{0}", type.NoFlyTypeColor));
                    (e.Item.FindControl("ltrNoFlyTypeName") as Literal).Text = type.NoFlyTypeName;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the fiscal year down arrow is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void imbFiscalYearDown_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DecrementFiscalYear();
                InitializeCalendar();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the fiscal year up arrow is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void imbFiscalYearUp_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.IncrementFiscalYear();
                InitializeCalendar();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Initializes the calendar
        /// </summary>
        private void InitializeCalendar()
        {
            if (FiscalYear.HasValue)
            {
                ltrFiscalYear.Text = String.Format("FY{1} (OCT {0} - SEP {1})", (FiscalYear.Value - 1).ToString(), FiscalYear.Value.ToString());

                calOctober.VisibleDate = new DateTime(FiscalYear.Value - 1, 10, 1);
                calNovember.VisibleDate = new DateTime(FiscalYear.Value - 1, 11, 1);
                calDecember.VisibleDate = new DateTime(FiscalYear.Value - 1, 12, 1);
                calJanuary.VisibleDate = new DateTime(FiscalYear.Value, 1, 1);
                calFebruary.VisibleDate = new DateTime(FiscalYear.Value, 2, 1);
                calMarch.VisibleDate = new DateTime(FiscalYear.Value, 3, 1);
                calApril.VisibleDate = new DateTime(FiscalYear.Value, 4, 1);
                calMay.VisibleDate = new DateTime(FiscalYear.Value, 5, 1);
                calJune.VisibleDate = new DateTime(FiscalYear.Value, 6, 1);
                calJuly.VisibleDate = new DateTime(FiscalYear.Value, 7, 1);
                calAugust.VisibleDate = new DateTime(FiscalYear.Value, 8, 1);
                calSeptember.VisibleDate = new DateTime(FiscalYear.Value, 9, 1);
            }
        }

        /// <summary>
        /// Current fiscal year selection
        /// </summary>
        public Nullable<Int32> FiscalYear
        {
            get
            {
                return this.ViewState["FiscalYear"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["FiscalYear"] = value;
            }
        }

        /// <summary>
        /// Current mobilization show/hide selection
        /// </summary>
        public Boolean ShowMobilization
        {
            get
            {
                return chkMobilization.Checked;
            }
        }

        /// <summary>
        /// The dictionary of no fly days by date
        /// </summary>
        public IDictionary<DateTime, NoFlyType> NoFlyDays
        {
            get
            {
                return this.ViewState["NoFlyDays"] as IDictionary<DateTime, NoFlyType>;
            }
            set
            {
                this.ViewState["NoFlyDays"] = value;
            }
        }

        /// <summary>
        /// The list of no fly types
        /// </summary>
        public IList<NoFlyType> NoFlyTypes
        {
            set
            {
                dlNoFlyTypes.DataSource = value;
                dlNoFlyTypes.DataBind();
            }
        }
    }
}