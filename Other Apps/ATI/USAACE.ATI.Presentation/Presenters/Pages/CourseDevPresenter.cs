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
    /// Presenter for the CourseDevView
    /// </summary>
    public class CourseDevPresenter : BasePresenter
    {
        /// <summary>
        /// The CourseDevView for the CourseDevPresenter
        /// </summary>
        public new ICourseDevView View
        {
            get
            {
                return base.View as ICourseDevView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the CourseDevView
        /// </summary>
        /// <param name="view">The CourseDevView</param>
        public CourseDevPresenter(ICourseDevView view)
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
            IList<USAACE.ATI.Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
            IList<CourseType> courseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();

            this.View.CourseLevels = DataService.GetCourseLevels().OrderBy(x => x.CourseLevelName).ToList();
            this.View.Systems = systems;
            this.View.POIs = DataService.GetPOIs().OrderBy(x => x.POIName).ToList();
            this.View.Programs = DataService.GetPrograms().OrderBy(x => x.ProgramName).ToList();
            this.View.CourseTypes = courseTypes;
            this.View.CourseNumbers = DataService.GetCourseNumbers().OrderBy(x => x.CourseNumberName).ToList();

            LoadCourses();
        }

        /// <summary>
        /// Loads the courses
        /// </summary>
        public void LoadCourses()
        {
            IList<USAACE.ATI.Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
            IList<CourseType> courseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();

            if (this.View.ProgramID != null)
            {
                Program program = new Program();
                program.ProgramID = this.View.ProgramID;

                program = DataService.GetProgram(program);

                this.View.AllowEditing = program.Locked != true;

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
                this.View.Courses = null;
                this.View.AllowEditing = true;
            }

            LoadCourse();
        }

        /// <summary>
        /// Loads the selected course
        /// </summary>
        public void LoadCourse()
        {
            if (this.View.CourseID.HasValue)
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                course = DataService.LoadCourse(course);

                this.View.CourseName = course.CourseName;
                this.View.CourseNumberID = course.CourseNumberID;
                this.View.MinClassSize = course.MinClassSize;
                this.View.OptClassSize = course.OptimumClassSize;
                this.View.MaxClassSize = course.MaxClassSize;
                this.View.Prefix = course.Prefix;
                this.View.Phase = course.Phase;
                this.View.CourseLevelID = course.CourseLevelID;
                this.View.SystemID = course.SystemID;
                this.View.POIID = course.POIID;
                this.View.CourseTypeID = course.CourseTypeID;
                this.View.Interval = course.ClassInterval;
                this.View.TrainNoFlyDay = course.TrainNoFlyDay;
                this.View.ReportNoFlyDay = course.ReportNoFlyDay;
                this.View.IsNewCourse = false;
                //this.View.IsCarryOver = course.PreviousCourseID.HasValue;
            }
            else
            {
                this.View.CourseName = null;
                this.View.CourseNumberID = null;
                this.View.MinClassSize = null;
                this.View.OptClassSize = null;
                this.View.MaxClassSize = null;
                this.View.Prefix = null;
                this.View.Phase = null;
                this.View.CourseLevelID = null;
                this.View.SystemID = null;
                this.View.POIID = null;
                this.View.CourseTypeID = null;
                this.View.Interval = null;
                this.View.TrainNoFlyDay = null;
                this.View.ReportNoFlyDay = null;
                this.View.IsNewCourse = true;
                this.View.IsCarryOver = false;
            }

            LoadPOIDays();
        }

        /// <summary>
        /// Saves the selected course
        /// </summary>
        public void Save()
        {
            Course course = new Course();
            course.CourseID = this.View.CourseID;

            if (course.CourseID.HasValue)
            {
                course = DataService.LoadCourse(course);
            }

            course.CourseName = this.View.CourseName;
            course.CourseNumberID = this.View.CourseNumberID;
            course.MinClassSize = this.View.MinClassSize;
            course.OptimumClassSize = this.View.OptClassSize;
            course.MaxClassSize = this.View.MaxClassSize;
            course.Prefix = this.View.Prefix;
            course.Phase = this.View.Phase;
            course.CourseLevelID = this.View.CourseLevelID;
            course.SystemID = this.View.SystemID;
            course.POIID = this.View.POIID;
            course.ProgramID = this.View.ProgramID;
            course.CourseTypeID = this.View.CourseTypeID;
            course.ClassInterval = this.View.Interval;
            course.TrainNoFlyDay = this.View.TrainNoFlyDay;
            course.ReportNoFlyDay = this.View.ReportNoFlyDay;

            course = DataService.SaveCourse(course);

            LoadCourses();

            this.View.CourseID = course.CourseID;

            LoadCourse();
        }

        /// <summary>
        /// Deletes the selected course
        /// </summary>
        public void Delete()
        {
            Course course = new Course();
            course.CourseID = this.View.CourseID;

            DataService.DeleteCourse(course);

            Load();
        }

        /// <summary>
        /// Loads the POI days for the selected course
        /// </summary>
        public void LoadPOIDays()
        {
            if (this.View.POIID.HasValue)
            {
                POI poi = new POI();
                poi.POIID = this.View.POIID;

                poi = DataService.GetPOI(poi);

                Int32 daysPerWeek = CalendarUtil.GetWeekLength(poi);

                if (poi.Days.HasValue)
                {
                    this.View.CourseWeeks = poi.Days.Value / daysPerWeek;
                    this.View.CourseDays = poi.Days.Value % daysPerWeek;
                }
                else
                {
                    this.View.CourseWeeks = null;
                    this.View.CourseDays = null;
                }
            }
            else
            {
                this.View.CourseWeeks = null;
                this.View.CourseDays = null;
            }
        }

        /// <summary>
        /// Copies the selected course
        /// </summary>
        public void CreateCopy()
        {
            Course course = new Course();
            course.CourseID = this.View.CourseID;

            Course copyCourse = DataService.CopyCourse(course, this.View.CopyCourseName, this.View.ProgramID, null);

            LoadCourses();

            this.View.CourseID = copyCourse.CourseID;

            LoadCourse();
        }
    }
}
