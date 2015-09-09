using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class EXSUMForm : FormControl, IEXSUMFormView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private EXSUMFormPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public EXSUMFormPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new EXSUMFormPresenter(this);
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
            dcEXSUMDate.Enabled = enabled;
            txtEXSUMTitle.Enabled = enabled;

            hteIssues.Enabled = enabled;
            hteCurrentStatus.Enabled = enabled;
            hteFutureStatus.Enabled = enabled;
            htePointOfContact.Enabled = enabled;
            hteAdditionalInformation.Enabled = enabled;
        }

        public Nullable<DateTime> EXSUMDate
        {
            get
            {
                return dcEXSUMDate.SelectedDate;
            }
            set
            {
                dcEXSUMDate.SelectedDate = value;
            }
        }

        public String EXSUMTitle
        {
            get
            {
                return txtEXSUMTitle.Text;
            }
            set
            {
                txtEXSUMTitle.Text = value;
            }
        }

        public String Issues
        {
            get
            {
                return hteIssues.Text;
            }
            set
            {
                hteIssues.Text = value;
            }
        }

        public String CurrentStatus
        {
            get
            {
                return hteCurrentStatus.Text;
            }
            set
            {
                hteCurrentStatus.Text = value;
            }
        }

        public String FutureStatus
        {
            get
            {
                return hteFutureStatus.Text;
            }
            set
            {
                hteFutureStatus.Text = value;
            }
        }

        public String PointOfContact
        {
            get
            {
                return htePointOfContact.Text;
            }
            set
            {
                htePointOfContact.Text = value;
            }
        }

        public String AdditionalInfo
        {
            get
            {
                return hteAdditionalInformation.Text;
            }
            set
            {
                hteAdditionalInformation.Text = value;
            }
        }
    }
}