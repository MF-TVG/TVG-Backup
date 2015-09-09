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
    public class TransmittalSheetListPresenter : BasePresenter
    {
        /// <summary>
        /// The ITransmittalSheetListView for the TransmittalSheetListPresenter
        /// </summary>
        private new ITransmittalSheetListView View
        {
            get
            {
                return base.View as ITransmittalSheetListView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ITransmittalSheetListView
        /// </summary>
        /// <param name="view">The ITransmittalSheetListView</param>
        public TransmittalSheetListPresenter(ITransmittalSheetListView view)
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
                        form.ExtendedProperties.FormData = FormDataUtil.LoadSpecificFormData<Transmittal>(formDatas[form.FormID]);

                        displayForms.Add(form);
                    }

                }
            }

            this.View.Forms = displayForms;
        }
    }
}
