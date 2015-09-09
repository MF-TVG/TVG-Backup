using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class AMOForm : FormControl, IAMOFormView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private AMOFormPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public AMOFormPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new AMOFormPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            Presenter.Load();
        }

        protected override void SaveForm()
        {
            Presenter.Save();
        }

        protected override void SaveDefault()
        {
            Presenter.SaveDefault();
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            
        }
    }
}