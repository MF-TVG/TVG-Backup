using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class SchoolsRequestForm : FormControl, ISchoolsRequestFormView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private SchoolsRequestFormPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public SchoolsRequestFormPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new SchoolsRequestFormPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            rblAPFTPass.BindBooleanListControl("Pass", "Fail");

            Presenter.LoadLookups();
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

        protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.LoadChecklist();
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtTitle.Enabled = enabled;
            ddlRequestType.Enabled = enabled;
            cklChecklistItems.Enabled = enabled;
            hteWho.Enabled = enabled;
            txtAPFTScore.Enabled = enabled;
            rblAPFTPass.Enabled = enabled;
            txtAPFTBodyFat.Enabled = enabled;
            txtArmySSDLevel.Enabled = enabled;
            hteWhat.Enabled = enabled;
            hteWhen.Enabled = enabled;
            hteWhere.Enabled = enabled;
            hteRemarks.Enabled = enabled;
        }

        public String Title
        {
            get
            {
                return txtTitle.Text;
            }
            set
            {
                txtTitle.Text = value;
            }
        }

        public String SelectedRequestType
        {
            get
            {
                return ddlRequestType.SelectedValue;
            }
            set
            {
                ddlRequestType.SelectedValue = value;
            }
        }

        public IList<SchoolsRequestType> RequestTypes
        {
            set
            {
                ddlRequestType.Items.Clear();

                ddlRequestType.Items.Add("-- Select Request Type --");

                foreach (SchoolsRequestType requestType in value)
                {
                    ddlRequestType.Items.Add(new ListItem(requestType.RequestTypeName, requestType.RequestTypeName));
                }
            }
        }

        public IList<SchoolsRequestCheckItem> SelectedChecklistItems
        {
            get
            {
                return cklChecklistItems.GetSelectedItems().Select(x => new SchoolsRequestCheckItem { ChecklistItem = x.Value }).ToList();
            }
            set
            {
                foreach (ListItem checkItem in cklChecklistItems.Items)
                {
                    checkItem.Selected = value != null && value.Any(x => x.ChecklistItem == checkItem.Value);
                }
            }
        }

        public IList<SchoolsChecklistItem> ChecklistOptions
        {
            set
            {
                cklChecklistItems.Items.Clear();

                foreach (SchoolsChecklistItem checklistOption in value)
                {
                    cklChecklistItems.Items.Add(new ListItem(checklistOption.ChecklistItemName, checklistOption.ChecklistItemName));
                }
            }
        }

        public String Who
        {
            get
            {
                return hteWho.Text;
            }
            set
            {
                hteWho.Text = value;
            }
        }

        public Nullable<Int16> APFTScore
        {
            get
            {
                return txtAPFTScore.Text.ToNullable<Int16>();
            }
            set
            {
                txtAPFTScore.Text = value.ToStringSafe();
            }
        }

        public Nullable<Boolean> APFTPass
        {
            get
            {
                return rblAPFTPass.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblAPFTPass.SelectedValue = value.ToStringSafe();
            }
        }

        public Nullable<Byte> BodyFatPercent
        {
            get
            {
                return txtAPFTBodyFat.Text.ToNullable<Byte>();
            }
            set
            {
                txtAPFTBodyFat.Text = value.ToStringSafe();
            }
        }

        public String SSDLevel
        {
            get
            {
                return txtArmySSDLevel.Text;
            }
            set
            {
                txtArmySSDLevel.Text = value;
            }
        }

        public String What
        {
            get
            {
                return hteWhat.Text;
            }
            set
            {
                hteWhat.Text = value;
            }
        }

        public String When
        {
            get
            {
                return hteWhen.Text;
            }
            set
            {
                hteWhen.Text = value;
            }
        }

        public String Where
        {
            get
            {
                return hteWhere.Text;
            }
            set
            {
                hteWhere.Text = value;
            }
        }

        public String Remarks
        {
            get
            {
                return hteRemarks.Text;
            }
            set
            {
                hteRemarks.Text = value;
            }
        }
    }
}