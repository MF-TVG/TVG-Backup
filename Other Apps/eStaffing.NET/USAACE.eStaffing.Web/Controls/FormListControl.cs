using System;
using System.Collections.Generic;
using System.Web.UI;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Controls;
using USAACE.eStaffing.Web.Pages;

namespace USAACE.eStaffing.Web.Controls
{
    public abstract class FormListControl : UserControl, IFormListControlView
    {
        internal FormList FormPage
        {
            get
            {
                return this.Page as FormList;
            }
        }

        public IList<Form> Forms
        {
            get
            {
                return FormPage.Forms;
            }
            set
            {
                
            }
        }

        public Nullable<Int32> StartIndex
        {
            get
            {
                return FormPage.StartIndex;
            }
        }

        public Int32 IncrementRange
        {
            get
            {
                return FormPage.IncrementRange;
            }
        }

        internal abstract void LoadList();

        protected void HandleException(Exception ex)
        {
            FormPage.HandleException(ex);
        }
    }
}