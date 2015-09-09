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
    public class SchoolsRequestFormPresenter : BasePresenter
    {
        /// <summary>
        /// The ISchoolsRequestFormView for the SchoolsRequestFormPresenter
        /// </summary>
        private new ISchoolsRequestFormView View
        {
            get
            {
                return base.View as ISchoolsRequestFormView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ISchoolsRequestFormView
        /// </summary>
        /// <param name="view">The ISchoolsRequestFormView</param>
        public SchoolsRequestFormPresenter(ISchoolsRequestFormView view)
        {
            base.View = view;
        }

        public void LoadLookups()
        {
            this.View.RequestTypes = FormLookupUtil.LoadSpecificLookup<SchoolsRequestType>(this.View.FormTypeID, this.View.SubmitOrganizationID, "SchoolsRequestType");
        }

        public void Load()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                SchoolsRequest schoolsRequest = FormDataUtil.LoadSpecificFormData<SchoolsRequest>(formData);

                this.View.Title = schoolsRequest.Title;
                this.View.SelectedRequestType = schoolsRequest.RequestType;

                LoadChecklist();

                this.View.Who = schoolsRequest.Who;
                this.View.APFTScore = schoolsRequest.APFTScore;
                this.View.APFTPass = schoolsRequest.APFTPass;
                this.View.BodyFatPercent = schoolsRequest.BodyFatPercent;
                this.View.SSDLevel = schoolsRequest.SSDLevel;
                this.View.What = schoolsRequest.What;
                this.View.When = schoolsRequest.When;
                this.View.Where = schoolsRequest.Where;
                this.View.Remarks = schoolsRequest.Remarks;

                this.View.SelectedChecklistItems = schoolsRequest.SchoolsRequestCheckItems;
            }
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                SchoolsRequest schoolsRequest = FormDataUtil.LoadSpecificFormData<SchoolsRequest>(formData);

                schoolsRequest.Title = this.View.Title;
                schoolsRequest.RequestType = this.View.SelectedRequestType;
                schoolsRequest.Who = this.View.Who;
                schoolsRequest.APFTScore = this.View.APFTScore;
                schoolsRequest.APFTPass = this.View.APFTPass;
                schoolsRequest.BodyFatPercent = this.View.BodyFatPercent;
                schoolsRequest.SSDLevel = this.View.SSDLevel;
                schoolsRequest.What = this.View.What;
                schoolsRequest.When = this.View.When;
                schoolsRequest.Where = this.View.Where;
                schoolsRequest.Remarks = this.View.Remarks;

                schoolsRequest.SchoolsRequestCheckItems = (List<SchoolsRequestCheckItem>)this.View.SelectedChecklistItems;

                DataService.SaveFormData(formData, schoolsRequest);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, schoolsRequest);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void LoadChecklist()
        {
            IList<SchoolsRequestCheckItem> selectedChecklistItems = this.View.SelectedChecklistItems;

            IList<SchoolsChecklistItem> checklistOptions = FormLookupUtil.LoadSpecificLookup<SchoolsChecklistItem>(this.View.FormTypeID, this.View.SubmitOrganizationID, "SchoolsChecklistItem")
                .Where(x => x.RequestType == this.View.SelectedRequestType).ToList();

            this.View.ChecklistOptions = checklistOptions;

            this.View.SelectedChecklistItems = selectedChecklistItems;
        }

        public void SaveDefault()
        {
            SchoolsRequest schoolsRequest = new SchoolsRequest();

            schoolsRequest.Title = this.View.Title;
            schoolsRequest.RequestType = this.View.SelectedRequestType;
            schoolsRequest.Who = this.View.Who;
            schoolsRequest.APFTScore = this.View.APFTScore;
            schoolsRequest.APFTPass = this.View.APFTPass;
            schoolsRequest.BodyFatPercent = this.View.BodyFatPercent;
            schoolsRequest.SSDLevel = this.View.SSDLevel;
            schoolsRequest.What = this.View.What;
            schoolsRequest.When = this.View.When;
            schoolsRequest.Where = this.View.Where;
            schoolsRequest.Remarks = this.View.Remarks;

            schoolsRequest.SchoolsRequestCheckItems = (List<SchoolsRequestCheckItem>)this.View.SelectedChecklistItems;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, schoolsRequest);
        }
    }
}
