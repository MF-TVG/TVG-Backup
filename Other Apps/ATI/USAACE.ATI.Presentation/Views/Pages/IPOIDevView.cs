using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;
using System.Data;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the POIDevView
    /// </summary>
    public interface IPOIDevView : IBaseView
    {
        /// <summary>
        /// The list of POIs
        /// </summary>
        IList<POI> POIs { set; }

        /// <summary>
        /// The ID of the currently selected POI
        /// </summary>
        Nullable<Int32> POIID { get; set; }

        /// <summary>
        /// The value for POI name
        /// </summary>
        String POIName { get; set; }

        /// <summary>
        /// The value for number of POI days
        /// </summary>
        Nullable<Int16> POIDays { get; set; }

        /// <summary>
        /// The value for POI mobilization
        /// </summary>
        Nullable<Boolean> Mobilization { get; set; }

        /// <summary>
        /// The value for POI effective date
        /// </summary>
        Nullable<DateTime> EffectiveDate { get; set; }

        /// <summary>
        /// The calculated value for if this is a new POI
        /// </summary>
        Boolean IsNewPOI { set; }

        /// <summary>
        /// The list of objectives
        /// </summary>
        IList<Objective> Objectives { set; }

        /// <summary>
        /// The ID for the currently selected objective
        /// </summary>
        Nullable<Int32> ObjectiveID { get; set; }

        /// <summary>
        /// The current list of POI flight days
        /// </summary>
        IList<POIFlightDay> FlightDays { get; set; }

        /// <summary>
        /// The calculated value for total of objective hours
        /// </summary>
        Nullable<Decimal> ObjectiveHours { set; }

        /// <summary>
        /// The calculated value for total of POI hours
        /// </summary>
        Nullable<Decimal> TotalHours { set; }

        /// <summary>
        /// The value for the copied POI name
        /// </summary>
        String CopyPOIName { get; set; }

        /// <summary>
        /// The data for the POI report
        /// </summary>
        DataTable POIReport { set; }

        /// <summary>
        /// The name of the POI report
        /// </summary>
        String POIReportName { set; }

        /// <summary>
        /// The length in days of the POI report
        /// </summary>
        String POIReportLength { set; }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        Boolean AllowEditing { set; }
    }
}
