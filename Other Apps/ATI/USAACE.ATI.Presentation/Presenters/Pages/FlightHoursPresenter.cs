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
    /// Presenter for the FlightHoursView
    /// </summary>
    public class FlightHoursPresenter : BasePresenter
    {
        /// <summary>
        /// The FlightHoursView for the FlightHoursPresenter
        /// </summary>
        public new IFlightHoursView View
        {
            get
            {
                return base.View as IFlightHoursView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the FlightHoursView
        /// </summary>
        /// <param name="view">The FlightHoursView</param>
        public FlightHoursPresenter(IFlightHoursView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Initialization action for the presenter
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.Programs = DataService.GetPrograms().OrderBy(x => x.ProgramName).ToList();

            this.View.HoursTypes = DataService.ListHoursTypes().OrderBy(x => x.HoursTypeName).ToList();

            LoadCourses();

            this.View.Systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
            this.View.CourseLevels = DataService.GetCourseLevels().OrderBy(x => x.CourseLevelName).ToList();
            this.View.MiscHoursTypes = DataService.GetMiscHourses().OrderBy(x => x.MiscHoursName).ToList();

            SetEntryFields();
            LoadCurrentCourse();
            LoadHours();
        }

        /// <summary>
        /// Loads the courses
        /// </summary>
        public void LoadCourses()
        {
            if (this.View.ProgramID.HasValue)
            {
                Program program = new Program();
                program.ProgramID = this.View.ProgramID;

                program = DataService.GetProgram(program);

                this.View.AllowEditing = program.Locked != true;

                IList<USAACE.ATI.Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
                IList<CourseType> courseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();

                Course courseToSearch = new Course();
                courseToSearch.ProgramID = this.View.ProgramID;

                IList<Course> courses = DataService.ListCourses(courseToSearch);

                foreach (Course course in courses)
                {
                    course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, systems, courseTypes);
                }

                this.View.Courses = courses.OrderBy(x => x.ExtendedProperties.DisplayName).ToList();
            }
            else
            {
                this.View.Courses = new List<Course>();
                this.View.AllowEditing = true;
            }
        }

        /// <summary>
        /// Loads the selected course
        /// </summary>
        public void LoadCurrentCourse()
        {
            if (this.View.CourseID.HasValue)
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                course = DataService.LoadCourse(course);

                this.View.SystemID = course.SystemID;
                this.View.CourseLevelID = course.CourseLevelID;
            }
            else
            {
                this.View.SystemID = null;
                this.View.CourseLevelID = null;
            }
        }

        /// <summary>
        /// Sets the entry fields pertinent to the forecast setting
        /// </summary>
        public void SetEntryFields()
        {
            this.View.EnableActualHours = this.View.ForecastHours == false;
            this.View.EnableAddinHours = this.View.ForecastHours == true;
            this.View.EnableBASOPSHours = true;
            this.View.EnableSupportHours = this.View.ForecastHours == false;

            if (this.View.ForecastHours == true && (this.View.HoursTypeID == 1 || this.View.HoursTypeID == 2))
            {
                this.View.HoursTypeID = 4;
            }
            else if (this.View.ForecastHours == false && this.View.HoursTypeID == 4)
            {
                this.View.HoursTypeID = 1;
            }

            if (this.View.HoursTypeID == 1)
            {
                this.View.ShowCourse = true;
                this.View.ShowMiscHoursType = false;
                this.View.SystemEnabled = false;
                this.View.CourseLevelEnabled = false;
            }
            else if (this.View.HoursTypeID == 2)
            {
                this.View.ShowCourse = false;
                this.View.ShowMiscHoursType = true;
                this.View.SystemEnabled = true;
                this.View.CourseLevelEnabled = true;
            }
            else if (this.View.HoursTypeID == 3)
            {
                this.View.ShowCourse = false;
                this.View.ShowMiscHoursType = false;
                this.View.SystemEnabled = true;
                this.View.CourseLevelEnabled = true;
            }
            else if (this.View.HoursTypeID == 4)
            {
                this.View.ShowCourse = false;
                this.View.ShowMiscHoursType = false;
                this.View.SystemEnabled = true;
                this.View.CourseLevelEnabled = true;
            }
        }

        /// <summary>
        /// Loads the actual hours based on selected hours type
        /// </summary>
        public void LoadHours()
        {
            IList<ActualHours> hoursList = new List<ActualHours>();

            if (this.View.HoursTypeID == 1)
            {
                if (this.View.ProgramID.HasValue && this.View.CourseID.HasValue)
                {
                    ActualHours hours = new ActualHours();
                    hours.HoursTypeID = this.View.HoursTypeID;
                    hours.ProgramID = this.View.ProgramID;
                    hours.CourseID = this.View.CourseID;
                    hours.Reimbursable = this.View.ReimbursableHours;

                    hoursList = DataService.ListActualHours(hours).OrderBy(x => x.CutoffDate).ToList();

                    this.View.ShowHoursUpdate = true;
                }
                else
                {
                    this.View.ShowHoursUpdate = false;
                }
            }
            else if (this.View.HoursTypeID == 2)
            {
                if (this.View.ProgramID.HasValue && this.View.MiscHoursTypeID.HasValue && this.View.SystemID.HasValue && this.View.CourseLevelID.HasValue)
                {
                    ActualHours hours = new ActualHours();
                    hours.HoursTypeID = this.View.HoursTypeID;
                    hours.ProgramID = this.View.ProgramID;
                    hours.MiscHoursID = this.View.MiscHoursTypeID;
                    hours.SystemID = this.View.SystemID;
                    hours.CourseLevelID = this.View.CourseLevelID;
                    hours.Reimbursable = this.View.ReimbursableHours;

                    hoursList = DataService.ListActualHours(hours).OrderBy(x => x.CutoffDate).ToList();

                    this.View.ShowHoursUpdate = true;
                }
                else
                {
                    this.View.ShowHoursUpdate = false;
                }
            }
            else if (this.View.HoursTypeID == 3)
            {
                if (this.View.ProgramID.HasValue && this.View.SystemID.HasValue && this.View.CourseLevelID.HasValue)
                {
                    ActualHours hours = new ActualHours();
                    hours.HoursTypeID = this.View.HoursTypeID;
                    hours.ProgramID = this.View.ProgramID;
                    hours.SystemID = this.View.SystemID;
                    hours.CourseLevelID = this.View.CourseLevelID;
                    hours.Forecast = this.View.ForecastHours;
                    hours.Reimbursable = this.View.ReimbursableHours;

                    hoursList = DataService.ListActualHours(hours).OrderBy(x => x.CutoffDate).ToList();

                    this.View.ShowHoursUpdate = true;
                }
                else
                {
                    this.View.ShowHoursUpdate = false;
                }
            }
            else if (this.View.HoursTypeID == 4)
            {
                if (this.View.ProgramID.HasValue && this.View.SystemID.HasValue && this.View.CourseLevelID.HasValue)
                {
                    ActualHours hours = new ActualHours();
                    hours.HoursTypeID = this.View.HoursTypeID;
                    hours.ProgramID = this.View.ProgramID;
                    hours.SystemID = this.View.SystemID;
                    hours.CourseLevelID = this.View.CourseLevelID;
                    hours.Reimbursable = this.View.ReimbursableHours;

                    hoursList = DataService.ListActualHours(hours).OrderBy(x => x.CutoffDate).ToList();

                    this.View.ShowHoursUpdate = true;
                }
                else
                {
                    this.View.ShowHoursUpdate = false;
                }
            }

            this.View.Hours = hoursList;
        }

        /// <summary>
        /// Saves the actual hours based on selected hours type
        /// </summary>
        public void SaveHours()
        {
            if (this.View.ProgramID.HasValue)
            {
                if (this.View.HoursTypeID == 1)
                {
                    foreach (ActualHours hours in this.View.Hours)
                    {
                        if (hours.ExtendedProperties.MarkForDeletion == true)
                        {
                            DataService.DeleteActualHours(hours);
                        }
                        else if (this.View.CourseID.HasValue)
                        {
                            hours.HoursTypeID = this.View.HoursTypeID;
                            hours.ProgramID = this.View.ProgramID;
                            hours.CourseID = this.View.CourseID;
                            hours.Forecast = false;
                            hours.Reimbursable = this.View.ReimbursableHours;

                            DataService.SaveActualHours(hours);
                        }
                    }
                }
                else if (this.View.HoursTypeID == 2)
                {
                    foreach (ActualHours hours in this.View.Hours)
                    {
                        if (hours.ExtendedProperties.MarkForDeletion == true)
                        {
                            DataService.DeleteActualHours(hours);
                        }
                        else if (this.View.MiscHoursTypeID.HasValue && this.View.SystemID.HasValue && this.View.CourseLevelID.HasValue)
                        {
                            hours.HoursTypeID = this.View.HoursTypeID;
                            hours.ProgramID = this.View.ProgramID;
                            hours.MiscHoursID = this.View.MiscHoursTypeID;
                            hours.SystemID = this.View.SystemID;
                            hours.CourseLevelID = this.View.CourseLevelID;
                            hours.Forecast = false;
                            hours.Reimbursable = this.View.ReimbursableHours;

                            DataService.SaveActualHours(hours);
                        }
                    }
                }
                else if (this.View.HoursTypeID == 3)
                {
                    foreach (ActualHours hours in this.View.Hours)
                    {
                        if (hours.ExtendedProperties.MarkForDeletion == true)
                        {
                            DataService.DeleteActualHours(hours);
                        }
                        else if (this.View.SystemID.HasValue && this.View.CourseLevelID.HasValue)
                        {
                            hours.HoursTypeID = this.View.HoursTypeID;
                            hours.ProgramID = this.View.ProgramID;
                            hours.SystemID = this.View.SystemID;
                            hours.CourseLevelID = this.View.CourseLevelID;
                            hours.Forecast = this.View.ForecastHours;
                            hours.Reimbursable = this.View.ReimbursableHours;

                            DataService.SaveActualHours(hours);
                        }
                    }
                }
                else if (this.View.HoursTypeID == 4)
                {
                    foreach (ActualHours hours in this.View.Hours)
                    {
                        if (hours.ExtendedProperties.MarkForDeletion == true)
                        {
                            DataService.DeleteActualHours(hours);
                        }
                        else if (this.View.SystemID.HasValue && this.View.CourseLevelID.HasValue)
                        {
                            hours.HoursTypeID = this.View.HoursTypeID;
                            hours.ProgramID = this.View.ProgramID;
                            hours.SystemID = this.View.SystemID;
                            hours.CourseLevelID = this.View.CourseLevelID;
                            hours.Forecast = true;
                            hours.Reimbursable = this.View.ReimbursableHours;

                            DataService.SaveActualHours(hours);
                        }
                    }
                }

                LoadHours();
            }
        }

        /// <summary>
        /// Deletes the actual hours
        /// </summary>
        public void DeleteHours()
        {
            if (this.View.ProgramID.HasValue)
            {
                foreach (ActualHours hours in this.View.Hours)
                {
                    DataService.DeleteActualHours(hours);
                }

                LoadHours();
            }
        }

        /// <summary>
        /// Adds actual hours entry
        /// </summary>
        public void AddHours()
        {
            if (this.View.ProgramID.HasValue)
            {
                IList<ActualHours> hours = this.View.Hours;

                ActualHours newHours = new ActualHours();
                newHours.CutoffDate = this.View.DefaultCutoffDate;

                hours.Add(newHours);

                this.View.Hours = hours;
            }
        }
    }
}
