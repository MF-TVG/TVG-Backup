using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class FormListPresenter : BasePresenter
    {
        /// <summary>
        /// The IFormListView for the FormListPresenter
        /// </summary>
        private new IFormListView View
        {
            get
            {
                return base.View as IFormListView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IFormEntryView
        /// </summary>
        /// <param name="view">The IFormEntryView</param>
        public FormListPresenter(IFormListView view)
        {
            base.View = view;
        }

        public void Initialize()
        {
            if (this.View.FormTypeID.HasValue)
            {
                FormType formType = new FormType();
                formType.FormTypeID = this.View.FormTypeID;

                formType = DataService.GetFormType(formType);

                if (formType != null)
                {
                    this.View.ControlName = formType.ListPageName;
                    this.View.FormTitle = formType.FormTypeName;
                }
                else
                {
                    throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.INVALID_FORM_TYPE);
                }
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.INVALID_FORM_TYPE);
            }
        }

        public void Load()
        {
            Form form = new Form();
            form.FormStatusID = FormStatusConstants.ACTIVE;
            form.FormTypeID = this.View.FormTypeID;

            IList<Form> forms = ReportUtil.GetFormsList(form, this.View.Roles, this.View.SortField, this.View.SortDirection);
            Int32 formsCount = forms.Count;

            this.View.Forms = forms;

            ResetIndex();
        }

        public void ResetIndex()
        {
            Int32 formsCount = this.View.Forms.Count;

            this.View.StartIndex = formsCount > 0 ? 1 : 0;
            this.View.EndIndex = formsCount > this.View.IncrementRange ? this.View.IncrementRange : formsCount;
            this.View.ShowPrev = false;
            this.View.ShowNext = formsCount > this.View.IncrementRange;
        }

        public void IncrementIndex()
        {
            Nullable<Int32> startIndex = this.View.StartIndex;

            this.View.StartIndex = startIndex + this.View.IncrementRange;

            Int32 formsCount = this.View.Forms.Count;

            this.View.EndIndex = formsCount > startIndex + (this.View.IncrementRange * 2) ? startIndex + (this.View.IncrementRange * 2) : formsCount;

            this.View.ShowPrev = true;
            this.View.ShowNext = formsCount > startIndex + (this.View.IncrementRange * 2);
        }

        public void DecrementIndex()
        {
            Nullable<Int32> startIndex = this.View.StartIndex;

            this.View.StartIndex = startIndex - this.View.IncrementRange;

            Int32 formsCount = this.View.Forms.Count;

            this.View.EndIndex = startIndex - 1;

            this.View.ShowPrev = startIndex - this.View.IncrementRange != 1;
            this.View.ShowNext = true;
        }
    }
}
