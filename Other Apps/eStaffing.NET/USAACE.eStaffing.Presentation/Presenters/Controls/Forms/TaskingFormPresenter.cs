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
    public class TaskingFormPresenter : BasePresenter
    {
        /// <summary>
        /// The ITaskingFormView for the TaskingFormPresenter
        /// </summary>
        private new ITaskingFormView View
        {
            get
            {
                return base.View as ITaskingFormView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ITaskingFormView
        /// </summary>
        /// <param name="view">The ITaskingFormView</param>
        public TaskingFormPresenter(ITaskingFormView view)
        {
            base.View = view;
        }

        public void LoadLookups()
        {
            this.View.TaskingTypes = FormLookupUtil.LoadSpecificLookup<TaskingType>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TaskingType");
            this.View.TaskingSources = FormLookupUtil.LoadSpecificLookup<TaskingSource>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TaskingSource");
            this.View.TaskingDocumentTypes = FormLookupUtil.LoadSpecificLookup<TaskingDocumentType>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TaskingDocumentType");
            this.View.TaskingActionTypes = FormLookupUtil.LoadSpecificLookup<TaskingActionType>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TaskingActionType");
            this.View.TaskingSecurityLevels = FormLookupUtil.LoadSpecificLookup<TaskingSecurityLevel>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TaskingSecurityLevel");
            this.View.TaskingLocations = FormLookupUtil.LoadSpecificLookup<TaskingLocation>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TaskingLocation");
        }

        public void Load()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                Tasking tasking = FormDataUtil.LoadSpecificFormData<Tasking>(formData);

                this.View.TaskNumber = tasking.TaskNumber;
                this.View.ECCNumber = tasking.ECCNumber;
                this.View.SelectedTaskingType = tasking.TaskingType;
                this.View.SelectedTaskingSource = tasking.TaskingSource;
                this.View.SourcePOC = tasking.SourcePOC;
                this.View.Subject = tasking.Subject;
                this.View.ActionOfficer = tasking.ActionOfficer;
                this.View.PhoneNumber = tasking.PhoneNumber;
                this.View.OfficeSymbol = tasking.OfficeSymbol;
                this.View.SuspenseDate = tasking.SuspenseDate;
                this.View.TaskingDate = tasking.TaskDate;
                this.View.SelectedTaskingDocumentType = tasking.DocumentType;
                this.View.SelectedTaskingActionType = tasking.ActionRequired;
                this.View.SelectedTaskingSecurityLevel = tasking.SecurityLevel;
                this.View.SelectedTaskingLocation = tasking.Location;
                this.View.WhereWhenWhatWhyHow = tasking.Task5W;
                this.View.CoordinatingInstructions = tasking.TaskInstructions;
                this.View.TaskPOC = tasking.TaskPOC;
                this.View.TaskNotes = tasking.TaskNotes;
            }
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                Tasking tasking = FormDataUtil.LoadSpecificFormData<Tasking>(formData);

                tasking.TaskNumber = this.View.TaskNumber;
                tasking.ECCNumber = this.View.ECCNumber;
                tasking.TaskingType = this.View.SelectedTaskingType;
                tasking.TaskingSource = this.View.SelectedTaskingSource;
                tasking.SourcePOC = this.View.SourcePOC;
                tasking.Subject = this.View.Subject;
                tasking.ActionOfficer = this.View.ActionOfficer;
                tasking.PhoneNumber = this.View.PhoneNumber;
                tasking.OfficeSymbol = this.View.OfficeSymbol;
                tasking.SuspenseDate = this.View.SuspenseDate;
                tasking.TaskDate = this.View.TaskingDate;
                tasking.DocumentType = this.View.SelectedTaskingDocumentType;
                tasking.ActionRequired = this.View.SelectedTaskingActionType;
                tasking.SecurityLevel = this.View.SelectedTaskingSecurityLevel;
                tasking.Location = this.View.SelectedTaskingLocation;
                tasking.Task5W = this.View.WhereWhenWhatWhyHow;
                tasking.TaskInstructions = this.View.CoordinatingInstructions;
                tasking.TaskPOC = this.View.TaskPOC;
                tasking.TaskNotes = this.View.TaskNotes;

                DataService.SaveFormData(formData, tasking);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, tasking);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void SaveDefault()
        {
            Tasking tasking = new Tasking();

            tasking.TaskNumber = this.View.TaskNumber;
            tasking.ECCNumber = this.View.ECCNumber;
            tasking.TaskingType = this.View.SelectedTaskingType;
            tasking.TaskingSource = this.View.SelectedTaskingSource;
            tasking.SourcePOC = this.View.SourcePOC;
            tasking.Subject = this.View.Subject;
            tasking.ActionOfficer = this.View.ActionOfficer;
            tasking.PhoneNumber = this.View.PhoneNumber;
            tasking.OfficeSymbol = this.View.OfficeSymbol;
            tasking.SuspenseDate = this.View.SuspenseDate;
            tasking.TaskDate = this.View.TaskingDate;
            tasking.DocumentType = this.View.SelectedTaskingDocumentType;
            tasking.ActionRequired = this.View.SelectedTaskingActionType;
            tasking.SecurityLevel = this.View.SelectedTaskingSecurityLevel;
            tasking.Location = this.View.SelectedTaskingLocation;
            tasking.Task5W = this.View.WhereWhenWhatWhyHow;
            tasking.TaskInstructions = this.View.CoordinatingInstructions;
            tasking.TaskPOC = this.View.TaskPOC;
            tasking.TaskNotes = this.View.TaskNotes;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, tasking);
        }
    }
}
