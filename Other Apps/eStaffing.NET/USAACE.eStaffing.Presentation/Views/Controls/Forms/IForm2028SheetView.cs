using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface IForm2028SheetView : IFormControlView
    {
        String LessonID { get; set; }

        String LessonVersion { get; set; }

        String SelectedCourseType { get; set; }

        IList<Form2028CourseType> CourseTypes { set; }

        String SelectedCourseNumber { get; set; }

        IList<Form2028Course> CourseNumbers { set; }

        String CourseTitle { set; }

        IList<PublicationChange> PublicationChanges { get; set; }

        Nullable<Int32> SelectedPublicationChange { get; set; }

        IList<RepairPartChange> RepairChanges { get; set; }

        Nullable<Int32> SelectedRepairChange { get; set; }

        String Remarks { get; set; }

        String SubmitterName { get; set; }

        String PhoneNumber { get; set; }

        String PublicationPageNumber { get; set; }

        String PublicationParagraph { get; set; }

        String PublicationLineNumber { get; set; }

        String PublicationFigureNumber { get; set; }

        String PublicationTableNumber { get; set; }

        String PublicationRecommendedChanges { get; set; }

        String RepairPageNumber { get; set; }

        String RepairColumnNumber { get; set; }

        String RepairLineNumber { get; set; }

        String RepairNationalStockNumber { get; set; }

        String RepairReferenceNumber { get; set; }

        String RepairFigureNumber { get; set; }

        String RepairItemNumber { get; set; }

        String RepairItemCount { get; set; }

        String RepairRecommendedAction { get; set; }
    }
}
