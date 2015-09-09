using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class TaskingForm : FormControl, ITaskingFormView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private TaskingFormPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public TaskingFormPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new TaskingFormPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
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

        public String TaskNumber
        {
            get
            {
                return txtTaskNumber.Text;
            }
            set
            {
                txtTaskNumber.Text = value;
            }
        }

        public String ECCNumber
        {
            get
            {
                return txtECCNumber.Text;
            }
            set
            {
                txtECCNumber.Text = value;
            }
        }

        public IList<TaskingType> TaskingTypes
        {
            set
            {
                ddlTaskType.Items.Clear();

                ddlTaskType.Items.Add(String.Empty);

                foreach (TaskingType type in value)
                {
                    ddlTaskType.Items.Add(new ListItem(type.TaskingTypeName, type.TaskingTypeName));
                }
            }
        }

        public String SelectedTaskingType
        {
            get
            {
                return ddlTaskType.SelectedValue;
            }
            set
            {
                ddlTaskType.SelectedValue = value;
            }
        }

        public IList<TaskingSource> TaskingSources
        {
            set
            {
                ddlSource.Items.Clear();

                ddlSource.Items.Add(String.Empty);

                foreach (TaskingSource source in value)
                {
                    ddlSource.Items.Add(new ListItem(source.TaskingSourceName, source.TaskingSourceName));
                }
            }
        }

        public String SelectedTaskingSource
        {
            get
            {
                return ddlSource.SelectedValue;
            }
            set
            {
                ddlSource.SelectedValue = value;
            }
        }

        public String SourcePOC
        {
            get
            {
                return hteSourcePOC.Text;
            }
            set
            {
                hteSourcePOC.Text = value;
            }
        }

        public String Subject
        {
            get
            {
                return hteSubject.Text;
            }
            set
            {
                hteSubject.Text = value;
            }
        }

        public String ActionOfficer
        {
            get
            {
                return txtActionOfficer.Text;
            }
            set
            {
                txtActionOfficer.Text = value;
            }
        }

        public String PhoneNumber
        {
            get
            {
                return txtPhone.Text;
            }
            set
            {
                txtPhone.Text = value;
            }
        }

        public String OfficeSymbol
        {
            get
            {
                return txtOfficeSymbol.Text;
            }
            set
            {
                txtOfficeSymbol.Text = value;
            }
        }

        public Nullable<DateTime> SuspenseDate
        {
            get
            {
                return dcSuspense.SelectedDate;
            }
            set
            {
                dcSuspense.SelectedDate = value;
            }
        }

        public Nullable<DateTime> TaskingDate
        {
            get
            {
                return dcDateTasked.SelectedDate;
            }
            set
            {
                dcDateTasked.SelectedDate = value;
            }
        }

        public String SelectedTaskingDocumentType
        {
            get
            {
                return ddlDocumentType.SelectedValue;
            }
            set
            {
                ddlDocumentType.SelectedValue = value;
            }
        }

        public IList<TaskingDocumentType> TaskingDocumentTypes
        {
            set
            {
                ddlDocumentType.Items.Clear();

                ddlDocumentType.Items.Add(String.Empty);

                foreach (TaskingDocumentType type in value)
                {
                    ddlDocumentType.Items.Add(new ListItem(type.TaskingDocumentTypeName, type.TaskingDocumentTypeName));
                }
            }
        }

        public String SelectedTaskingActionType
        {
            get
            {
                return ddlActionRequired.SelectedValue;
            }
            set
            {
                ddlActionRequired.SelectedValue = value;
            }
        }

        public IList<TaskingActionType> TaskingActionTypes
        {
            set
            {
                ddlActionRequired.Items.Clear();

                ddlActionRequired.Items.Add(String.Empty);

                foreach (TaskingActionType type in value)
                {
                    ddlActionRequired.Items.Add(new ListItem(type.TaskingActionTypeName, type.TaskingActionTypeName));
                }
            }
        }

        public String SelectedTaskingSecurityLevel
        {
            get
            {
                return ddlSecurityLevel.SelectedValue;
            }
            set
            {
                ddlSecurityLevel.SelectedValue = value;
            }
        }

        public IList<TaskingSecurityLevel> TaskingSecurityLevels
        {
            set
            {
                ddlSecurityLevel.Items.Clear();

                ddlSecurityLevel.Items.Add(String.Empty);

                foreach (TaskingSecurityLevel level in value)
                {
                    ddlSecurityLevel.Items.Add(new ListItem(level.TaskingSecurityLevelName, level.TaskingSecurityLevelName));
                }
            }
        }

        public String SelectedTaskingLocation
        {
            get
            {
                return ddlTaskerLocation.SelectedValue;
            }
            set
            {
                ddlTaskerLocation.SelectedValue = value;
            }
        }

        public IList<TaskingLocation> TaskingLocations
        {
            set
            {
                ddlTaskerLocation.Items.Clear();

                ddlTaskerLocation.Items.Add(String.Empty);

                foreach (TaskingLocation location in value)
                {
                    ddlTaskerLocation.Items.Add(new ListItem(location.TaskingLocationName, location.TaskingLocationName));
                }
            }
        }

        public String SelectedTaskerLocation
        {
            get
            {
                return ddlTaskerLocation.SelectedValue;
            }
            set
            {
                ddlTaskerLocation.SelectedValue = value;
            }
        }

        public String WhereWhenWhatWhyHow
        {
            get
            {
                return hte5W.Text;
            }
            set
            {
                hte5W.Text = value;
            }
        }

        public String CoordinatingInstructions
        {
            get
            {
                return hteCoordinateInstructions.Text;
            }
            set
            {
                hteCoordinateInstructions.Text = value;
            }
        }

        public String TaskPOC
        {
            get
            {
                return htePOC.Text;
            }
            set
            {
                htePOC.Text = value;
            }
        }

        public String TaskNotes
        {
            get
            {
                return hteComments.Text;
            }
            set
            {
                hteComments.Text = value;
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtTaskNumber.Enabled = enabled;
            txtECCNumber.Enabled = enabled;
            ddlTaskType.Enabled = enabled;
            ddlSource.Enabled = enabled;
            hteSourcePOC.Enabled = enabled;
            hteSubject.Enabled = enabled;
            txtActionOfficer.Enabled = enabled;
            txtPhone.Enabled = enabled;
            txtOfficeSymbol.Enabled = enabled;
            dcSuspense.Enabled = enabled;
            dcDateTasked.Enabled = enabled;

            ddlDocumentType.Enabled = enabled;
            ddlActionRequired.Enabled = enabled;
            ddlSecurityLevel.Enabled = enabled;
            ddlTaskerLocation.Enabled = enabled;
            hte5W.Enabled = enabled;
            hteCoordinateInstructions.Enabled = enabled;
            htePOC.Enabled = enabled;
            hteComments.Enabled = enabled;
        }
    }
}