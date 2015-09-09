using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.Forms
{
    public class Form2028SheetPresenter : BasePresenter
    {
        /// <summary>
        /// The IForm2028SheetView for the Form2028SheetPresenter
        /// </summary>
        private new IForm2028SheetView View
        {
            get
            {
                return base.View as IForm2028SheetView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IForm2028SheetView
        /// </summary>
        /// <param name="view">The IForm2028SheetView</param>
        public Form2028SheetPresenter(IForm2028SheetView view)
        {
            base.View = view;
        }

        public void LoadLookups()
        {
            this.View.CourseTypes = FormLookupUtil.LoadSpecificLookup<Form2028CourseType>(this.View.FormTypeID, this.View.SubmitOrganizationID, "Form2028CourseType");
        }

        public void Load()
        {
            FormData formData = new FormData();
            formData.FormID = this.View.FormID;

            formData = DataService.LoadFormData(formData);

            Form2028 form2028 = FormDataUtil.LoadSpecificFormData<Form2028>(formData);

            this.View.LessonID = form2028.LessonID;
            this.View.LessonVersion = form2028.LessonVersion;
            this.View.SelectedCourseType = form2028.CourseType;

            LoadCourses();

            this.View.SelectedCourseNumber = form2028.CourseNumber;

            LoadSelectedCourse();

            this.View.Remarks = form2028.Remarks;
            this.View.SubmitterName = form2028.SubmitterName;
            this.View.PhoneNumber = form2028.PhoneNumber;

            this.View.PublicationChanges = form2028.PublicationChanges;
            this.View.RepairChanges = form2028.RepairPartChanges;
        }

        public void Save()
        {
            FormData formData = new FormData();
            formData.FormID = this.View.FormID;

            formData = DataService.LoadFormData(formData);

            Form2028 form2028 = FormDataUtil.LoadSpecificFormData<Form2028>(formData);

            form2028.LessonID = this.View.LessonID;
            form2028.LessonVersion = this.View.LessonVersion;
            form2028.CourseType = this.View.SelectedCourseType;
            form2028.CourseNumber = this.View.SelectedCourseNumber;
            form2028.Remarks = this.View.Remarks;
            form2028.SubmitterName = this.View.SubmitterName;
            form2028.PhoneNumber = this.View.PhoneNumber;

            form2028.PublicationChanges = (List<PublicationChange>)this.View.PublicationChanges;
            form2028.RepairPartChanges = (List<RepairPartChange>)this.View.RepairChanges;

            DataService.SaveFormData(formData, form2028);

            Form form = new Form();
            form.FormID = this.View.FormID;

            form = DataService.LoadForm(form);

            FormUtil.SetFormTypeValues(form, form2028);

            form = DataService.SaveForm(form);

            Load();
        }

        public void LoadCourses()
        {
            String selectedCourse = this.View.SelectedCourseNumber;

            IList<Form2028Course> courseNumbers = FormLookupUtil.LoadSpecificLookup<Form2028Course>(this.View.FormTypeID, this.View.SubmitOrganizationID, "Form2028Course")
                .Where(x => String.IsNullOrEmpty(this.View.SelectedCourseType) || x.CourseType == this.View.SelectedCourseType).ToList();

            this.View.CourseNumbers = courseNumbers;

            this.View.SelectedCourseNumber = selectedCourse;
        }

        public void LoadSelectedCourse()
        {
            if (!String.IsNullOrEmpty(this.View.SelectedCourseNumber))
            {
                IList<Form2028Course> courseNumbers = FormLookupUtil.LoadSpecificLookup<Form2028Course>(this.View.FormTypeID, this.View.SubmitOrganizationID, "Form2028Course");

                Form2028Course courseNumber = courseNumbers.FirstOrDefault(x => x.CourseNumber == this.View.SelectedCourseNumber);

                this.View.CourseTitle = courseNumber != null ? courseNumber.CourseTitle : null;
            }
            else
            {
                this.View.CourseTitle = null;
            }
        }

        public void LoadPublicationChange()
        {
            if (this.View.SelectedPublicationChange.HasValue)
            {
                PublicationChange change = this.View.PublicationChanges.FirstOrDefault(x => x.ListIndex == this.View.SelectedPublicationChange);

                this.View.PublicationPageNumber = change.PageNumber;
                this.View.PublicationParagraph = change.Paragraph;
                this.View.PublicationLineNumber = change.LineNumber;
                this.View.PublicationFigureNumber = change.FigureNumber;
                this.View.PublicationTableNumber = change.TableNumber;
                this.View.PublicationRecommendedChanges = change.RecommendedChanges;
            }
            else
            {
                this.View.PublicationPageNumber = null;
                this.View.PublicationParagraph = null;
                this.View.PublicationLineNumber = null;
                this.View.PublicationFigureNumber = null;
                this.View.PublicationTableNumber = null;
                this.View.PublicationRecommendedChanges = null;
            }
        }

        public void SavePublicationChange()
        {
            IList<PublicationChange> changes = this.View.PublicationChanges;

            PublicationChange change = this.View.SelectedPublicationChange.HasValue ?
                changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedPublicationChange) :
                new PublicationChange { ListIndex = changes.Count > 0 ? changes.Last().ListIndex + 1 : 0 };

            change.PageNumber = this.View.PublicationPageNumber;
            change.Paragraph = this.View.PublicationParagraph;
            change.LineNumber = this.View.PublicationLineNumber;
            change.FigureNumber = this.View.PublicationFigureNumber;
            change.TableNumber = this.View.PublicationTableNumber;
            change.RecommendedChanges = this.View.PublicationRecommendedChanges;

            if (this.View.SelectedPublicationChange.HasValue == false)
            {
                changes.Add(change);
            }

            this.View.PublicationChanges = changes;
        }

        public void DeletePublicationChange()
        {
            if (this.View.SelectedPublicationChange.HasValue)
            {
                IList<PublicationChange> changes = this.View.PublicationChanges;

                PublicationChange change = changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedPublicationChange);

                changes.Remove(change);

                this.View.PublicationChanges = changes;
            }
        }

        public void LoadRepairChange()
        {
            if (this.View.SelectedRepairChange.HasValue)
            {
                RepairPartChange change = this.View.RepairChanges.FirstOrDefault(x => x.ListIndex == this.View.SelectedRepairChange);

                this.View.RepairPageNumber = change.PageNumber;
                this.View.RepairColumnNumber = change.ColumnNumber;
                this.View.RepairLineNumber = change.LineNumber;
                this.View.RepairNationalStockNumber = change.NationalStockNumber;
                this.View.RepairReferenceNumber = change.ReferenceNumber;
                this.View.RepairFigureNumber = change.FigureNumber;
                this.View.RepairItemNumber = change.ItemNumber;
                this.View.RepairItemCount = change.ItemCount;
                this.View.RepairRecommendedAction = change.RecommendedChanges;
            }
            else
            {
                this.View.RepairPageNumber = null;
                this.View.RepairColumnNumber = null;
                this.View.RepairLineNumber = null;
                this.View.RepairNationalStockNumber = null;
                this.View.RepairReferenceNumber = null;
                this.View.RepairFigureNumber = null;
                this.View.RepairItemNumber = null;
                this.View.RepairItemCount = null;
                this.View.RepairRecommendedAction = null;
            }
        }

        public void SaveRepairChange()
        {
            IList<RepairPartChange> changes = this.View.RepairChanges;

            RepairPartChange change = this.View.SelectedRepairChange.HasValue ?
                changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedRepairChange) :
                new RepairPartChange { ListIndex = changes.Count > 0 ? changes.Last().ListIndex + 1 : 0 };

            change.PageNumber = this.View.RepairPageNumber;
            change.ColumnNumber = this.View.RepairColumnNumber;
            change.LineNumber = this.View.RepairLineNumber;
            change.NationalStockNumber = this.View.RepairNationalStockNumber;
            change.ReferenceNumber = this.View.RepairReferenceNumber;
            change.FigureNumber = this.View.RepairFigureNumber;
            change.ItemNumber = this.View.RepairItemNumber;
            change.ItemCount = this.View.RepairItemCount;
            change.RecommendedChanges = this.View.RepairRecommendedAction;

            if (this.View.SelectedRepairChange.HasValue == false)
            {
                changes.Add(change);
            }

            this.View.RepairChanges = changes;
        }

        public void DeleteRepairChange()
        {
            if (this.View.SelectedRepairChange.HasValue)
            {
                IList<RepairPartChange> changes = this.View.RepairChanges;

                RepairPartChange change = changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedRepairChange);

                changes.Remove(change);

                this.View.RepairChanges = changes;
            }
        }

        public void SaveDefault()
        {
            Form2028 form2028 = new Form2028();

            form2028.LessonID = this.View.LessonID;
            form2028.LessonVersion = this.View.LessonVersion;
            form2028.CourseType = this.View.SelectedCourseType;
            form2028.CourseNumber = this.View.SelectedCourseNumber;
            form2028.Remarks = this.View.Remarks;
            form2028.SubmitterName = this.View.SubmitterName;
            form2028.PhoneNumber = this.View.PhoneNumber;

            form2028.PublicationChanges = (List<PublicationChange>)this.View.PublicationChanges;
            form2028.RepairPartChanges = (List<RepairPartChange>)this.View.RepairChanges;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, form2028);
        }
    }
}
