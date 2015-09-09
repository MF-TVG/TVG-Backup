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
    public class EXSUMFormPresenter : BasePresenter
    {
        /// <summary>
        /// The IEXSUMFormView for the EXSUMFormPresenter
        /// </summary>
        private new IEXSUMFormView View
        {
            get
            {
                return base.View as IEXSUMFormView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IEXSUMFormView
        /// </summary>
        /// <param name="view">The IEXSUMFormView</param>
        public EXSUMFormPresenter(IEXSUMFormView view)
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

                EXSUM exsum = FormDataUtil.LoadSpecificFormData<EXSUM>(formData);

                this.View.EXSUMDate = exsum.EXSUMDate;
                this.View.EXSUMTitle = exsum.EXSUMTitle;
                this.View.Issues = exsum.Issues;
                this.View.CurrentStatus = exsum.CurrentStatus;
                this.View.FutureStatus = exsum.FutureStatus;
                this.View.PointOfContact = exsum.PointOfContact;
                this.View.AdditionalInfo = exsum.AdditionalInfo;
            }
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                EXSUM exsum = FormDataUtil.LoadSpecificFormData<EXSUM>(formData);

                exsum.EXSUMDate = this.View.EXSUMDate;
                exsum.EXSUMTitle = this.View.EXSUMTitle;
                exsum.Issues = this.View.Issues;
                exsum.CurrentStatus = this.View.CurrentStatus;
                exsum.FutureStatus = this.View.FutureStatus;
                exsum.PointOfContact = this.View.PointOfContact;
                exsum.AdditionalInfo = this.View.AdditionalInfo;

                DataService.SaveFormData(formData, exsum);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, exsum);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void SaveDefault()
        {
            EXSUM exsum = new EXSUM();

            exsum.EXSUMDate = this.View.EXSUMDate;
            exsum.EXSUMTitle = this.View.EXSUMTitle;
            exsum.Issues = this.View.Issues;
            exsum.CurrentStatus = this.View.CurrentStatus;
            exsum.FutureStatus = this.View.FutureStatus;
            exsum.PointOfContact = this.View.PointOfContact;
            exsum.AdditionalInfo = this.View.AdditionalInfo;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, exsum);
        }
    }
}
