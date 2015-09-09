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
    /// Presenter for the HistoricalPercentView
    /// </summary>
    public class HistoricalPercentPresenter : BasePresenter
    {
        /// <summary>
        /// The HistoricalPercentView for the HistoricalPercentPresenter
        /// </summary>
        public new IHistoricalPercentView View
        {
            get
            {
                return base.View as IHistoricalPercentView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the HistoricalPercentView
        /// </summary>
        /// <param name="view">The HistoricalPercentView</param>
        public HistoricalPercentPresenter(IHistoricalPercentView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.Programs = DataService.GetPrograms().OrderBy(x => x.ProgramName).ToList();

            LoadCourses();
        }

        /// <summary>
        /// Loads the courses
        /// </summary>
        public void LoadCourses()
        {
            IList<USAACE.ATI.Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
            IList<CourseType> courseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();
            IList<CourseLevel> courseLevels = DataService.GetCourseLevels().OrderBy(x => x.CourseLevelName).ToList();

            this.View.Systems = systems;
            this.View.CourseLevels = courseLevels;
            this.View.CourseTypes = courseTypes;

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

            ChangeEditMode();
        }

        public void ChangeEditMode()
        {
            String editMode = this.View.EditMode;

            this.View.ShowByCourse = editMode == "Course";
            this.View.ShowMassEdit = editMode == "MassEdit";

            this.View.CourseID = null;

            LoadPercents();
        }

        /// <summary>
        /// Loads the historical percents for the selected course
        /// </summary>
        public void LoadPercents()
        {
            if (this.View.CourseID.HasValue)
            {
                HistoricalPercent percent = new HistoricalPercent();
                percent.CourseID = this.View.CourseID;

                percent = DataService.LoadHistoricalPercent(percent);

                this.View.PercentOctober = percent.October;
                this.View.PercentNovember = percent.November;
                this.View.PercentDecember = percent.December;
                this.View.PercentJanuary = percent.January;
                this.View.PercentFebruary = percent.February;
                this.View.PercentMarch = percent.March;
                this.View.PercentApril = percent.April;
                this.View.PercentMay = percent.May;
                this.View.PercentJune = percent.June;
                this.View.PercentJuly = percent.July;
                this.View.PercentAugust = percent.August;
                this.View.PercentSeptember = percent.September;
                this.View.PercentSupport = percent.Support;
                this.View.PercentSetback = percent.Setback;
                this.View.PercentTest = percent.Test;
                this.View.IsPercentVisible = true;
            }
            else
            {
                this.View.PercentOctober = null;
                this.View.PercentNovember = null;
                this.View.PercentDecember = null;
                this.View.PercentJanuary = null;
                this.View.PercentFebruary = null;
                this.View.PercentMarch = null;
                this.View.PercentApril = null;
                this.View.PercentMay = null;
                this.View.PercentJune = null;
                this.View.PercentJuly = null;
                this.View.PercentAugust = null;
                this.View.PercentSeptember = null;
                this.View.PercentSupport = null;
                this.View.PercentSetback = null;
                this.View.PercentTest = null;
                this.View.IsPercentVisible = this.View.EditMode != "Course";
            }
        }

        /// <summary>
        /// Saves the historical percents for the selected course
        /// </summary>
        public void Save()
        {
            if (this.View.CourseID.HasValue && this.View.EditMode == "Course")
            {
                HistoricalPercent percent = new HistoricalPercent();
                percent.CourseID = this.View.CourseID;

                percent.October = this.View.PercentOctober;
                percent.November = this.View.PercentNovember;
                percent.December = this.View.PercentDecember;
                percent.January = this.View.PercentJanuary;
                percent.February = this.View.PercentFebruary;
                percent.March = this.View.PercentMarch;
                percent.April = this.View.PercentApril;
                percent.May = this.View.PercentMay;
                percent.June = this.View.PercentJune;
                percent.July = this.View.PercentJuly;
                percent.August = this.View.PercentAugust;
                percent.September = this.View.PercentSeptember;
                percent.Support = this.View.PercentSupport;
                percent.Setback = this.View.PercentSetback;
                percent.Test = this.View.PercentTest;

                percent = DataService.SaveHistoricalPercent(percent);
            }
            else if (this.View.ProgramID.HasValue && this.View.EditMode == "MassEdit")
            {
                Course course = new Course();
                course.ProgramID = this.View.ProgramID;
                course.SearchProperties.SystemIDIsIn = this.View.SystemIDs;
                course.SearchProperties.CourseLevelIDIsIn = this.View.CourseLevelIDs;
                course.SearchProperties.CourseTypeIDIsIn = this.View.CourseTypeIDs;

                IList<Course> coursesToUpdate = DataService.ListCourses(course);

                foreach (Course courseToUpdate in coursesToUpdate)
                {
                    HistoricalPercent percent = new HistoricalPercent();
                    percent.CourseID = courseToUpdate.CourseID;

                    percent.October = this.View.PercentOctober;
                    percent.November = this.View.PercentNovember;
                    percent.December = this.View.PercentDecember;
                    percent.January = this.View.PercentJanuary;
                    percent.February = this.View.PercentFebruary;
                    percent.March = this.View.PercentMarch;
                    percent.April = this.View.PercentApril;
                    percent.May = this.View.PercentMay;
                    percent.June = this.View.PercentJune;
                    percent.July = this.View.PercentJuly;
                    percent.August = this.View.PercentAugust;
                    percent.September = this.View.PercentSeptember;
                    percent.Support = this.View.PercentSupport;
                    percent.Setback = this.View.PercentSetback;
                    percent.Test = this.View.PercentTest;

                    percent = DataService.SaveHistoricalPercent(percent);
                }
            }
        }

        /// <summary>
        /// Runs a historical percents report for the selected program
        /// </summary>
        public void RunReport()
        {
            if (this.View.ProgramID.HasValue)
            {
                Program program = new Program();
                program.ProgramID = this.View.ProgramID;

                this.View.HistoricalPercentsReport = ReportUtil.GetProgramHistoricalPercentsReport(program);
            }
        }
    }
}
