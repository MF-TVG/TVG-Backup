using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Business.Constants;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Presenters.Pages;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Web.Enum;
using USAACE.Common;

namespace USAACE.ATI.Web.Pages
{
    public partial class ProgramDev : BasePage, IProgramDevView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ProgramDevPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ProgramDevPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ProgramDevPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Loads the control
        /// </summary>
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the program text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbProgramName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadProgram();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Program button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateProgram_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Program");

                if (Page.IsValid)
                {
                    Presenter.Save();
                    this.ShowNotice(MessageConstants.PROGRAM_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Program button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteProgram_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteProgram.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Program Confirm button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteProgramConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Delete();
                this.ShowNotice(MessageConstants.PROGRAM_DELETE_SUCCESS, NoticeType.Information);
                mpDeleteProgram.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Program Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteProgramCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteProgram.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy Program button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCreateProgramCopy_Click(object sender, EventArgs e)
        {
            try
            {
                mpCopyProgram.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy Program Confirm button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCopyProgramConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("CopyProgram");

                if (Page.IsValid)
                {
                    Presenter.CopyProgram();
                    mpCopyProgram.Hide();
                    this.ShowNotice(MessageConstants.PROGRAM_COPY_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy Program Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCopyProgramCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpCopyProgram.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// The list of programs
        /// </summary>
        public IList<Program> Programs
        {
            set
            {
                cmbProgramName.Items.Clear();

                cmbProgramName.Items.Add(new ListItem("-- New Program --", String.Empty));

                foreach (Program program in value)
                {
                    cmbProgramName.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToString()));
                }

                cmbProgramName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        public Nullable<Int32> ProgramID
        {
            get
            {
                return cmbProgramName.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbProgramName.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the program name
        /// </summary>
        public String ProgramName
        {
            get
            {
                return txtProgramName.Text;
            }
            set
            {
                txtProgramName.Text = value;
            }
        }

        /// <summary>
        /// The value for the program description
        /// </summary>
        public String ProgramDescription
        {
            get
            {
                return hteProgramDescription.Text;
            }
            set
            {
                hteProgramDescription.Text = value;
            }
        }

        /// <summary>
        /// The value for the fiscal year
        /// </summary>
        public Nullable<Int16> FiscalYear
        {
            get
            {
                return ncFiscalYear.Value.ToNullable<Int16>();
            }
            set
            {
                ncFiscalYear.Value = value;
            }
        }

        /// <summary>
        /// The value for the program's locked status
        /// </summary>
        public Nullable<Boolean> Locked
        {
            get
            {
                return chkLocked.Checked;
            }
            set
            {
                chkLocked.Checked = value == true;
            }
        }

        /// <summary>
        /// The calculated value for if this is a new program
        /// </summary>
        public Boolean IsNewProgram
        {
            set
            {
                btnDeleteProgram.Visible = !value;
                btnCreateProgramCopy.Visible = !value;
            }
        }

        /// <summary>
        /// The value of the copied program name
        /// </summary>
        public String CopyProgramName
        {
            get
            {
                return txtCopyProgramName.Text;
            }
            set
            {
                txtCopyProgramName.Text = value;
            }
        }
    }
}