using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common;
using USAACE.Common.Presentation;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Domain.Entities;
using System.Collections;
using USAACE.ATI.Business.Util;
using USAACE.ATI.Business.Services;

namespace USAACE.ATI.Presentation.Presenters.Pages
{
    /// <summary>
    /// Presenter for the CurrentView
    /// </summary>
    public class CurrentPresenter : BasePresenter
    {
        /// <summary>
        /// The CurrentView for the CurrentPresenter
        /// </summary>
        public new ICurrentView View
        {
            get
            {
                return base.View as ICurrentView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the CurrentView
        /// </summary>
        /// <param name="view">The CurrentView</param>
        public CurrentPresenter(ICurrentView view)
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
            LoadClasses();
        }

        /// <summary>
        /// Loads the courses
        /// </summary>
        public void LoadCourses()
        {
            IList<Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
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

            LoadClasses();
        }

        /// <summary>
        /// Loads the classes
        /// </summary>
        public void LoadClasses()
        {
            if (this.View.CourseID.HasValue)
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                course.Load();

                this.View.POIID = course.POIID;

                Class searchClass = new Class();
                searchClass.CourseID = this.View.CourseID;

                IList<Class> classes = DataService.ListClasses(searchClass).OrderByDescending(x => x.ReportDate.HasValue).ThenBy(x => x.ReportDate).ToList();

                this.View.AllowFixReportDates = false;

                if (classes.Count > 0)
                {
                    POI firstPoi = DataService.GetPOI(new POI { POIID = classes[0].POIID });

                    DateTime currentDate = ClassUtil.GetNextDate(classes[0].ReportDate.Value, classes[0].Interval.Value, course.TrainNoFlyDay == true, firstPoi.Mobilization == true);

                    foreach (Class classItem in classes)
                    {
                        POI poi = DataService.GetPOI(new POI { POIID = classItem.POIID });

                        Int16 classItemInterval = classItem.Interval.HasValue ? classItem.Interval.Value : (Int16)0;

                        DateTime calcReportDate = classes.IndexOf(classItem) == 0 ? classItem.ReportDate.Value : ClassUtil.GetNextDate(currentDate, Convert.ToInt16(classItem.Interval.Value * -1), course.ReportNoFlyDay == true, poi.Mobilization == true);

                        DateTime startDate = ClassUtil.GetNextDate(classItem.ReportDate.Value, classItemInterval, course.TrainNoFlyDay == true, poi.Mobilization == true);
                        DateTime endDate = ClassUtil.GetNextDate(classItem.ReportDate.Value, Convert.ToInt16(poi.Days.Value + classItemInterval - 1), course.TrainNoFlyDay == true, poi.Mobilization == true);

                        classItem.ExtendedProperties.CalcReportDate = calcReportDate;
                        classItem.ExtendedProperties.StartDate = startDate;
                        classItem.ExtendedProperties.EndDate = endDate;
                        classItem.ExtendedProperties.POIMatch = poi.POIID == course.POIID;
                        classItem.ExtendedProperties.POIName = poi.POIName;

                        if (classItem.ReportDate.Value != calcReportDate)
                        {
                            this.View.AllowFixReportDates = true;
                        }

                        classItem.ExtendedProperties.ADPCode = ClassUtil.GetADPCode(classItem);

                        currentDate = ClassUtil.GetNextDate(currentDate, course.ClassInterval.Value, course.TrainNoFlyDay == true, poi.Mobilization == true);
                    }
                }

                this.View.Classes = classes;
                this.View.ShowClassInfo = true;

                this.View.BeginClassNumber = null;
                this.View.NewInterval = null;
                this.View.NewStudentLoad = null;
                this.View.StudentPopulationType = "All";
            }
            else
            {
                this.View.Classes = new List<Class>();
                this.View.ShowClassInfo = false;
            }

            TotalClasses();
        }

        /// <summary>
        /// Saves the classes
        /// </summary>
        public void SaveClasses()
        {
            if (this.View.CourseID.HasValue)
            {
                foreach (Class classItem in this.View.Classes)
                {
                    DataService.SaveClass(classItem);
                }

                LoadClasses();
            }
        }

        /// <summary>
        /// Deletes the selected classes
        /// </summary>
        public void DeleteClasses()
        {
            if (this.View.CourseID.HasValue)
            {
                foreach (Class classItem in this.View.Classes.Where(x => x.ExtendedProperties.IsSelected == true))
                {
                    DataService.DeleteClass(classItem);
                }

                LoadClasses();
            }
        }

        public void TotalClasses()
        {
            if (this.View.CourseID.HasValue)
            {
                IList<Class> classes = this.View.Classes;

                this.View.TotalClasses = classes.Count;
                this.View.TotalStudents = classes.Sum(x => x.Students.GetValueOrDefault(0));
                this.View.TotalReimbursable = classes.Sum(x => x.Reimbursable.GetValueOrDefault(0));
            }
            else
            {
                this.View.TotalClasses = null;
                this.View.TotalStudents = null;
                this.View.TotalReimbursable = null;
            }
        }

        /// <summary>
        /// Adds a class
        /// </summary>
        public void AddClass()
        {
            if (this.View.CourseID.HasValue)
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                course = DataService.LoadCourse(course);

                IDictionary<Nullable<Int32>, POI> poiList = DataService.ListPOIDictionary();

                POI poi = poiList[course.POIID];

                IList<Class> classes = this.View.Classes;

                Class newClass = new Class();
                newClass.CourseID = this.View.CourseID;
                newClass.POIID = poi.POIID;

                newClass.ExtendedProperties.POIMatch = true;
                newClass.ExtendedProperties.POIName = poi.POIName;

                newClass.ExtendedProperties.ADPCode = ClassUtil.GetADPCode(newClass);

                classes.Add(newClass);

                this.View.Classes = classes;

                TotalClasses();
            }
        }

        /// <summary>
        /// Applies the selected POI to selected classes
        /// </summary>
        public void ApplyPOI()
        {
            if (this.View.CourseID.HasValue && this.View.POIID.HasValue)
            {
                IList<Class> classes = this.View.Classes;

                foreach (Class classItem in classes)
                {
                    if (classItem.ExtendedProperties.IsSelected == true)
                    {
                        classItem.ExtendedProperties.IsSelected = null;
                        classItem.POIID = this.View.POIID;
                    }
                }

                this.View.Classes = classes;

                TotalClasses();
            }
        }

        /// <summary>
        /// Changes all classes by assigning selected values
        /// </summary>
        public void ChangeAllClasses()
        {
            IList<Class> classes = this.View.Classes.OrderBy(x => x.ClassNumber).ToList();

            if (this.View.BeginClassNumber.HasValue)
            {
                for (Int16 i = 0; i < classes.Count; i++)
                {
                    classes[i].ClassNumber = (this.View.BeginClassNumber.Value + i).ToString();
                }
            }

            if (this.View.NewInterval.HasValue)
            {
                for (Int16 i = 0; i < classes.Count; i++)
                {
                    classes[i].Interval = this.View.NewInterval;
                }
            }

            if (this.View.NewStudentLoad.HasValue)
            {
                ClassUtil.StudentFillType fillType;

                switch (this.View.StudentPopulationType)
                {
                    case "Even": fillType = ClassUtil.StudentFillType.Even; break;
                    case "Odd": fillType = ClassUtil.StudentFillType.Odd; break;
                    default: fillType = ClassUtil.StudentFillType.All; break;
                }

                classes = ClassUtil.SetStudentClassCount(classes, this.View.NewStudentLoad.Value, fillType);
            }

            this.View.Classes = classes.OrderByDescending(x => x.ReportDate.HasValue).ThenBy(x => x.ReportDate).ToList();

            this.View.BeginClassNumber = null;
            this.View.NewInterval = null;
            this.View.NewStudentLoad = null;
            this.View.StudentPopulationType = "All";

            TotalClasses();
        }

        /// <summary>
        /// Recalculates report dates for the classes
        /// </summary>
        public void RecalculateReportDates()
        {
            Course course = new Course();
            course.CourseID = this.View.CourseID;

            course.Load();

            POI poi = new POI();
            poi.POIID = course.POIID;

            poi.Load();

            IList<Class> classes = this.View.Classes.OrderByDescending(x => x.ReportDate.HasValue).ThenBy(x => x.ReportDate).ToList();

            if (classes.Count > 0)
            {
                DateTime currentDate = ClassUtil.GetNextDate(classes[0].ReportDate.Value, classes[0].Interval.Value, course.TrainNoFlyDay == true, poi.Mobilization == true);

                foreach (Class classItem in classes)
                {
                    classItem.ReportDate = classes.IndexOf(classItem) == 0 ? classItem.ReportDate.Value : ClassUtil.GetNextDate(currentDate, Convert.ToInt16(classItem.Interval.Value * -1), course.ReportNoFlyDay == true, poi.Mobilization == true);
                    currentDate = ClassUtil.GetNextDate(currentDate, course.ClassInterval.Value, course.TrainNoFlyDay == true, poi.Mobilization == true);

                    Int16 classItemInterval = classItem.Interval.HasValue ? classItem.Interval.Value : (Int16)0;

                    DateTime startDate = ClassUtil.GetNextDate(classItem.ReportDate.Value, classItemInterval, course.TrainNoFlyDay == true, poi.Mobilization == true);
                    DateTime endDate = ClassUtil.GetNextDate(classItem.ReportDate.Value, Convert.ToInt16(poi.Days.Value + classItemInterval - 1), course.TrainNoFlyDay == true, poi.Mobilization == true);

                    classItem.ExtendedProperties.CalcReportDate = classItem.ReportDate.Value;
                    classItem.ExtendedProperties.StartDate = startDate;
                    classItem.ExtendedProperties.EndDate = endDate;
                    classItem.ExtendedProperties.ADPCode = ClassUtil.GetADPCode(classItem);
                }
            }

            this.View.Classes = classes;

            TotalClasses();
        }

        /// <summary>
        /// Loads the class report
        /// </summary>
        public void LoadClassReport()
        {
            Class classItem = new Class();
            classItem.ClassID = this.View.ClassReportID;

            this.View.ClassReport = ReportUtil.GetClassReport(classItem);
        }
    }
}
