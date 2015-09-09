using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.Common.Presentation;
using USAACE.ATI.Business.Services;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Business.Util;

namespace USAACE.ATI.Presentation.Presenters.Pages
{
    /// <summary>
    /// Presenter for the POIDevView
    /// </summary>
    public class POIDevPresenter : BasePresenter
    {
        /// <summary>
        /// The POIDevView for the POIDevPresenter
        /// </summary>
        public new IPOIDevView View
        {
            get
            {
                return base.View as IPOIDevView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the POIDevView
        /// </summary>
        /// <param name="view">The POIDevView</param>
        public POIDevPresenter(IPOIDevView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.POIs = DataService.GetPOIs().OrderBy(x => x.POIName).ToList();
            this.View.Objectives = DataService.GetObjectives().OrderBy(x => x.ObjectiveName).ToList();

            LoadPOI();
        }

        /// <summary>
        /// Loads the selected POI
        /// </summary>
        public void LoadPOI()
        {
            if (this.View.POIID.HasValue)
            {
                POI poi = new POI();
                poi.POIID = this.View.POIID;

                poi = DataService.GetPOI(poi);

                this.View.POIName = poi.POIName;
                this.View.CopyPOIName = String.Format("{0} Copy", poi.POIName);
                this.View.POIDays = poi.Days;
                this.View.Mobilization = poi.Mobilization;
                this.View.EffectiveDate = poi.EffectiveDate;
                this.View.IsNewPOI = false;

                this.View.AllowEditing = !POIUtil.CheckLockedStatus(poi);
            }
            else
            {
                this.View.POIName = null;
                this.View.CopyPOIName = null;
                this.View.POIDays = null;
                this.View.Mobilization = null;
                this.View.EffectiveDate = null;
                this.View.IsNewPOI = true;

                this.View.AllowEditing = true;
            }

            this.View.ObjectiveID = null;

            LoadPOIDays();
        }

        /// <summary>
        /// Loads the POI days for the selected POI
        /// </summary>
        public void LoadPOIDays()
        {
            if (this.View.POIID.HasValue && this.View.ObjectiveID.HasValue)
            {
                POIFlightDay poiFlightDay = new POIFlightDay();
                poiFlightDay.POIID = this.View.POIID;
                poiFlightDay.ObjectiveID = this.View.ObjectiveID;

                IList<POIFlightDay> poiFlightDays = DataService.ListPOIFlightDaysByObjective(poiFlightDay).OrderBy(x => x.FlightDayNumber).ToList();

                this.View.FlightDays = poiFlightDays;

                Decimal totalHours = 0.0M;

                foreach (POIFlightDay day in poiFlightDays)
                {
                    totalHours += day.Units.HasValue ? day.Units.Value : 0.0M;
                }

                this.View.ObjectiveHours = totalHours;
            }
            else
            {
                this.View.FlightDays = new List<POIFlightDay>();
                this.View.ObjectiveHours = null;
            }

            if (this.View.POIID.HasValue)
            {
                POIFlightDay poiFlightDay = new POIFlightDay();
                poiFlightDay.POIID = this.View.POIID;

                IList<POIFlightDay> poiFlightDays = DataService.ListPOIFlightDays(poiFlightDay);

                Decimal totalHours = 0.0M;

                foreach (POIFlightDay day in poiFlightDays)
                {
                    totalHours += day.Units.HasValue ? day.Units.Value : 0.0M;
                }

                this.View.TotalHours = totalHours;
            }
            else
            {
                this.View.TotalHours = null;
            }
            
            ResetFlightDays();
        }

        /// <summary>
        /// Copies the selected POI
        /// </summary>
        public void CreateCopy()
        {
            POI poi = new POI();
            poi.POIID = this.View.POIID;

            POI copyPOI = DataService.CopyPOI(poi, this.View.CopyPOIName);

            Load();

            this.View.POIID = copyPOI.POIID;

            LoadPOI();
        }

        /// <summary>
        /// Saves the selected POI
        /// </summary>
        public void Save()
        {
            POI poi = new POI();
            poi.POIID = this.View.POIID;

            if (poi.POIID.HasValue)
            {
                poi = DataService.GetPOI(poi);
            }

            poi.POIName = this.View.POIName;
            poi.Days = this.View.POIDays;
            poi.Mobilization = this.View.Mobilization;
            poi.EffectiveDate = this.View.EffectiveDate;

            poi = DataService.SavePOI(poi);

            Nullable<Int32> objectiveId = this.View.ObjectiveID;

            if (this.View.ObjectiveID.HasValue)
            {
                POIFlightDay poiFlightDay = new POIFlightDay();
                poiFlightDay.POIID = poi.POIID;
                poiFlightDay.ObjectiveID = this.View.ObjectiveID;

                DataService.SavePOIFlightDays(poiFlightDay, this.View.FlightDays);
            }

            Load();

            this.View.POIID = poi.POIID;

            LoadPOI();

            this.View.ObjectiveID = objectiveId;

            LoadPOIDays();
        }

        /// <summary>
        /// Deletes the selected POI
        /// </summary>
        public void Delete()
        {
            POI poi = new POI();
            poi.POIID = this.View.POIID;

            DataService.DeletePOI(poi);

            Load();
        }

        /// <summary>
        /// Resets the flight days
        /// </summary>
        public void ResetFlightDays()
        {
            if (this.View.ObjectiveID.HasValue)
            {
                IList<POIFlightDay> flightDays = this.View.FlightDays;

                Int16 newCount = this.View.POIDays.HasValue ? this.View.POIDays.Value : Convert.ToInt16(flightDays.Count);

                if (newCount > flightDays.Count)
                {
                    for (int i = 0; i < newCount; i++)
                    {
                        if (flightDays.Any(x => x.FlightDayNumber == i + 1) == false)
                        {
                            POIFlightDay day = new POIFlightDay();
                            day.FlightDayNumber = Convert.ToInt16(i + 1);
                            day.Units = 0.0M;

                            flightDays.Insert(i, day);
                        }
                    }
                }
                else if (newCount < flightDays.Count)
                {
                    while (flightDays.Count > newCount)
                    {
                        flightDays.RemoveAt(flightDays.Count - 1);
                    }
                }

                this.View.FlightDays = flightDays;
            }
            else
            {
                this.View.FlightDays = new List<POIFlightDay>();
            }
        }
        
        /// <summary>
        /// Generates a report for the selected POI
        /// </summary>
        public void GeneratePOIReport()
        {
            if (this.View.POIID.HasValue)
            {
                POI poi = new POI();
                poi.POIID = this.View.POIID;

                poi = DataService.GetPOI(poi);

                this.View.POIReport = ReportUtil.GetPOIReport(poi);
                this.View.POIReportName = poi.POIName;
                this.View.POIReportLength = poi.Days.GetValueOrDefault(0).ToString();
            }
        }
    }
}
