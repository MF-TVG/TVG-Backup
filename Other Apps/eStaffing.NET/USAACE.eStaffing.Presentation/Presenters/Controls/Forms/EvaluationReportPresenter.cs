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
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.Forms
{
    public class EvaluationReportPresenter : BasePresenter
    {
        /// <summary>
        /// The IEvaluationReportView for the EvaluationReportPresenter
        /// </summary>
        private new IEvaluationReportView View
        {
            get
            {
                return base.View as IEvaluationReportView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IEvaluationReportView
        /// </summary>
        /// <param name="view">The IEvaluationReportView</param>
        public EvaluationReportPresenter(IEvaluationReportView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                EvaluationReport evaluation = FormDataUtil.LoadSpecificFormData<EvaluationReport>(formData);

                this.View.ActionOfficer = evaluation.ActionOfficer;
                this.View.Ratee = evaluation.Ratee;
                this.View.ThruDate = evaluation.ThruDate;
                this.View.Rater = evaluation.Rater;
                this.View.IntermediateRater = evaluation.IntermediateRater;
                this.View.SeniorRater = evaluation.SeniorRater;
                this.View.Reviewer = evaluation.Reviewer;
                this.View.SubmissionReason = evaluation.SubmissionReason;
                this.View.SupportForm = evaluation.SupportForm;
                this.View.CivilianForm = evaluation.CounselingForm;
                this.View.PTCard = evaluation.PhysicalProfile;
                this.View.RecommendedComments = evaluation.RecommendedComments;
                this.View.Remarks = evaluation.Remarks;
                this.View.LossDate = evaluation.LossDate;
            }
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                EvaluationReport evaluation = FormDataUtil.LoadSpecificFormData<EvaluationReport>(formData);

                evaluation.ActionOfficer = this.View.ActionOfficer;
                evaluation.Ratee = this.View.Ratee;
                evaluation.ThruDate = this.View.ThruDate;
                evaluation.Rater = this.View.Rater;
                evaluation.IntermediateRater = this.View.IntermediateRater;
                evaluation.SeniorRater = this.View.SeniorRater;
                evaluation.Reviewer = this.View.Reviewer;
                evaluation.SubmissionReason = this.View.SubmissionReason;
                evaluation.SupportForm = this.View.SupportForm;
                evaluation.CounselingForm = this.View.CivilianForm;
                evaluation.PhysicalProfile = this.View.PTCard;
                evaluation.RecommendedComments = this.View.RecommendedComments;
                evaluation.Remarks = this.View.Remarks;
                evaluation.LossDate = this.View.LossDate;

                DataService.SaveFormData(formData, evaluation);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, evaluation);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void SaveDefault()
        {
            EvaluationReport evaluation = new EvaluationReport();

            evaluation.ActionOfficer = this.View.ActionOfficer;
            evaluation.Ratee = this.View.Ratee;
            evaluation.ThruDate = this.View.ThruDate;
            evaluation.Rater = this.View.Rater;
            evaluation.IntermediateRater = this.View.IntermediateRater;
            evaluation.SeniorRater = this.View.SeniorRater;
            evaluation.Reviewer = this.View.Reviewer;
            evaluation.SubmissionReason = this.View.SubmissionReason;
            evaluation.SupportForm = this.View.SupportForm;
            evaluation.CounselingForm = this.View.CivilianForm;
            evaluation.PhysicalProfile = this.View.PTCard;
            evaluation.RecommendedComments = this.View.RecommendedComments;
            evaluation.Remarks = this.View.Remarks;
            evaluation.LossDate = this.View.LossDate;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, evaluation);
        }
    }
}
