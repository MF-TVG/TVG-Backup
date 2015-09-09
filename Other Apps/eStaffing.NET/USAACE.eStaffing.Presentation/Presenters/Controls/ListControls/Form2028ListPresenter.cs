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
using USAACE.eStaffing.Presentation.Views.Controls.ListControls;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.ListControls
{
    public class Form2028ListPresenter : BasePresenter
    {
        /// <summary>
        /// The IForm2028ListView for the Form2028ListPresenter
        /// </summary>
        private new IForm2028ListView View
        {
            get
            {
                return base.View as IForm2028ListView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IForm2028ListView
        /// </summary>
        /// <param name="view">The IForm2028ListView</param>
        public Form2028ListPresenter(IForm2028ListView view)
        {
            base.View = view;
        }

        public void Load()
        {
            IList<Form> forms = this.View.Forms;

            IList<Nullable<Int32>> formIds = new List<Nullable<Int32>>();

            IList<Form> displayForms = new List<Form>();

            Int32 startIndex = this.View.StartIndex.GetValueOrDefault(1) - 1;

            if (startIndex >= 0)
            {
                for (Int32 i = startIndex; i < startIndex + this.View.IncrementRange && i < forms.Count; i++)
                {
                    Form form = forms[i];

                    formIds.Add(form.FormID);
                }

                FormData formData = new FormData();
                formData.SearchProperties.FormIDIsIn = formIds;

                IDictionary<Nullable<Int32>, FormData> formDatas = DataService.ListFormDataByForm(formData);

                for (Int32 i = startIndex; i < startIndex + this.View.IncrementRange && i < forms.Count; i++)
                {
                    Form form = forms[i];

                    if (formDatas.ContainsKey(form.FormID))
                    {
                        form.ExtendedProperties.FormData = FormDataUtil.LoadSpecificFormData<Form2028>(formDatas[form.FormID]);

                        displayForms.Add(form);
                    }

                }
            }

            this.View.Forms = displayForms;
        }
    }
}
