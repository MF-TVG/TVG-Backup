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
    /// Presenter for the ClassDevView
    /// </summary>
    public class ClassDevPresenter : BasePresenter
    {
        /// <summary>
        /// The ClassDevView for the ClassDevPresenter
        /// </summary>
        public new IClassDevView View
        {
            get
            {
                return base.View as IClassDevView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ClassDevView
        /// </summary>
        /// <param name="view">The ClassDevView</param>
        public ClassDevPresenter(IClassDevView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.Programs = DataService.GetPrograms().OrderBy(x => x.ProgramName).ToList();
            this.View.POIs = DataService.GetPOIs().OrderBy(x => x.POIName).ToList();

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
                this.View.Courses = new List<Course>();
                this.View.AllowEditing = true;
            }
        }

        /// <summary>
        /// Loads the course details
        /// </summary>
        public void LoadCourseDetails()
        {
            if (this.View.CourseID.HasValue)
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                course = DataService.LoadCourse(course);

                this.View.POIID = course.POIID;

                Program program = new Program();
                program.ProgramID = course.ProgramID;

                program = DataService.GetProgram(program);

                if (program.FiscalYear.HasValue)
                {
                    this.View.FirstReportDate = CalendarUtil.GetFiscalYearStart(program.FiscalYear.Value);
                }

                this.View.CourseFiscalYear = program.FiscalYear;
            }
        }

        /// <summary>
        /// Creates classes according to input parameters
        /// </summary>
        public void CreateClasses()
        {
            if (this.View.ClassLoad.HasValue && this.View.MaximumClasses.HasValue && this.View.BeginningClass.HasValue && this.View.ReportDateInterval.HasValue && this.View.FirstReportDate.HasValue &&
                this.View.CourseID.HasValue && !String.IsNullOrEmpty(this.View.StudentPopulationType))
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                POI poi = new POI();
                poi.POIID = this.View.POIID;

                Program carryOverProgram = new Program();
                carryOverProgram.ProgramID = this.View.CarryOverProgramID;

                Course carryOverCourse = new Course();
                carryOverCourse.CourseID = this.View.CarryOverCourseID;

                ClassUtil.StudentFillType fillType;

                switch (this.View.StudentPopulationType)
                {
                    case "Even": fillType = ClassUtil.StudentFillType.Even; break;
                    case "Odd": fillType = ClassUtil.StudentFillType.Odd; break;
                    default: fillType = ClassUtil.StudentFillType.All; break;
                }

                this.View.OverflowCount = ClassUtil.CreateClasses(course, poi, this.View.ClassLoad.Value, this.View.MaximumClasses.Value, this.View.BeginningClass.Value, this.View.ReportDateInterval.Value, this.View.FirstReportDate.Value, fillType, carryOverProgram, carryOverCourse);
            }
        }
        
        /// <summary>
        /// Gets the carry over course to use, not currently used
        /// </summary>
        public void GetCarryOverCourse()
        {
            /*if (this.View.CourseID.HasValue && this.View.CarryOverProgramID.HasValue)
            {
                Course carryOverCourse = new Course();
                carryOverCourse.ProgramID = this.View.CarryOverProgramID;

                IList<Course> carryOverCourses = DataService.ListCourses(carryOverCourse);

                if (carryOverCourses.Count > 0)
                {
                    this.View.CarryOverCourseID = carryOverCourses.First().CourseID;
                    this.View.CarryOverCourseText = "A carry over course already exists and will be used if needed.";
                }
                else
                {
                    this.View.CarryOverCourseID = null;
                    this.View.CarryOverCourseText = "A new carry over course will be created if needed.";
                }
            }
            else
            {
                this.View.CarryOverCourseID = null;
                this.View.CarryOverCourseText = null;
            }*/
        }
    }
}
