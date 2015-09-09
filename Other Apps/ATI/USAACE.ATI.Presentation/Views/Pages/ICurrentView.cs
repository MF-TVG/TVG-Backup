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
    /// Interface for the CurrentView
    /// </summary>
    public interface ICurrentView : IBaseView
    {
        /// <summary>
        /// The list of programs
        /// </summary>
        IList<Program> Programs { set; }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        Nullable<Int32> ProgramID { get; set; }

        /// <summary>
        /// The list of courses
        /// </summary>
        IList<Course> Courses { set; }

        /// <summary>
        /// The ID of the currently selected course
        /// </summary>
        Nullable<Int32> CourseID { get; set; }

        /// <summary>
        /// The list of POIs
        /// </summary>
        IList<POI> POIs { set; }

        /// <summary>
        /// The ID of the currently selected POI
        /// </summary>
        Nullable<Int32> POIID { get; set; }

        /// <summary>
        /// The current list of classes
        /// </summary>
        IList<Class> Classes { get; set; }

        Nullable<Int32> TotalClasses { set; }

        Nullable<Int32> TotalStudents { set; }

        Nullable<Int32> TotalReimbursable { set; }

        Boolean ShowClassInfo { set; }

        /// <summary>
        /// The value for the beginning class number
        /// </summary>
        Nullable<Int16> BeginClassNumber { get; set; }

        /// <summary>
        /// The value for the new interval
        /// </summary>
        Nullable<Int16> NewInterval { get; set; }

        /// <summary>
        /// The value for the new student load
        /// </summary>
        Nullable<Int16> NewStudentLoad { get; set; }

        /// <summary>
        /// The value for the student population type
        /// </summary>
        String StudentPopulationType { get; set; }

        /// <summary>
        /// The calculated value for whether report dates can be fixed
        /// </summary>
        Boolean AllowFixReportDates { set; }

        /// <summary>
        /// The ID value for the current class report
        /// </summary>
        Nullable<Int32> ClassReportID { get; set; }

        /// <summary>
        /// The data for the class report
        /// </summary>
        DataTable ClassReport { set; }
        
        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        Boolean AllowEditing { set; }
    }
}
