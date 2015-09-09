using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Controls.FormControls.FileControl;
using USAACE.eStaffing.Presentation.Views.Controls.FormControls.FileControl;
using USAACE.eStaffing.Web.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.FormControls.FileControl
{
    public partial class FileControl : FormControl, IFileControlView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private FileControlPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public FileControlPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new FileControlPresenter(this);
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
        
        /// <summary>
        /// Event occurring on Page Load, registers post back controls that cannot be done asynchronously
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnSaveAttachment);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when an item is bound to the Files repeater, it gets information about the file and displays the file name and URL or status
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void dlFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is FormAttachment)
                {
                    FormAttachment attachment = e.Item.DataItem as FormAttachment;

                    String newFileName = attachment.ExtendedProperties.NewFileName;

                    (e.Item.FindControl("lnkFile") as HyperLink).Text = !String.IsNullOrEmpty(newFileName) ? newFileName : attachment.FileName;
                    (e.Item.FindControl("lnkFile") as HyperLink).NavigateUrl = attachment.FormAttachmentID > 0 && String.IsNullOrEmpty(newFileName) ?
                        NavigateUtil.GetFormAttachmentUrl(attachment) : null;
                    (e.Item.FindControl("ltrFileStatus") as Literal).Text = attachment.ExtendedProperties.FileStatus;
                    (e.Item.FindControl("lnkSaveFile") as HyperLink).Visible = attachment.FormAttachmentID > 0;
                    (e.Item.FindControl("lnkSaveFile") as HyperLink).NavigateUrl = attachment.FormAttachmentID > 0 ? NavigateUtil.GetFormAttachmentLink(attachment) : null;
                    (e.Item.FindControl("imbRenameFile") as ImageButton).CommandArgument = attachment.FormAttachmentID.ToString();
                    (e.Item.FindControl("imbDeleteFile") as ImageButton).CommandArgument = attachment.FormAttachmentID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when the Add Attachment button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnAddAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                mpAddAttachment.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when the Upload button is clicked, it checks the file and then adds it to the list or displays an alert otherwise
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnSaveAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile file = fuFile.PostedFile;

                if (file != null && !String.IsNullOrEmpty(file.FileName))
                {
                    this.PostedFileName = file.FileName;
                    this.PostedFileContentType = file.ContentType;

                    Byte[] result = new Byte[file.ContentLength];
                    file.InputStream.Read(result, 0, file.ContentLength);

                    this.PostedFileContent = result;

                    Presenter.AddAttachment();
                }

                mpAddAttachment.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when the Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCancelAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                mpAddAttachment.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when a file's Rename button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void imbRenameFile_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedAttachmentID = e.CommandArgument.ToNullable<Int32>();
                Presenter.LoadAttachment();
                mpRenameAttachment.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveRenameAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.RenameAttachment();
                mpRenameAttachment.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelRenameAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                mpRenameAttachment.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event occurring when a file's Delete button is clicked, it marks the file for deletion if already saved, removes it if not saved
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void imbDeleteFile_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedAttachmentID = e.CommandArgument.ToNullable<Int32>();
                mpDeleteAttachmentConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteAttachmentConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteAttachment();
                mpDeleteAttachmentConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteAttachmentCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteAttachmentConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public Nullable<Int32> ReviewStatusID
        {
            get
            {
                return this.ViewState["ReviewStatusID"].ToNullable<Int32>();
            }
            internal set
            {
                this.ViewState["ReviewStatusID"] = value;
            }
        }

        public IList<FormAttachment> Attachments
        {
            get
            {
                return this.ViewState["Attachments"] as IList<FormAttachment>;
            }
            set
            {
                this.ViewState["Attachments"] = value;

                dlFiles.DataSource = value.Where(x => x.ExtendedProperties.MarkForDeletion != true);
                dlFiles.DataBind();
            }
        }

        public Nullable<Int32> SelectedAttachmentID
        {
            get
            {
                return this.ViewState["SelectedAttachmentID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedAttachmentID"] = value;
            }
        }

        public String PostedFileName
        {
            get
            {
                return this.ViewState["PostedFileName"] as String;
            }
            set
            {
                this.ViewState["PostedFileName"] = value;
            }
        }

        public String PostedFileContentType
        {
            get
            {
                return this.ViewState["PostedFileContentType"] as String;
            }
            set
            {
                this.ViewState["PostedFileContentType"] = value;
            }
        }

        public Byte[] PostedFileContent
        {
            get
            {
                return this.ViewState["PostedFileContent"] as Byte[];
            }
            set
            {
                this.ViewState["PostedFileContent"] = value;
            }
        }

        public String OldFileName
        {
            set
            {
                ltrRenameOldFileName.Text = value;
            }
        }

        public String NewFileName
        {
            get
            {
                return txtRenameNewFileName.Text;
            }
            set
            {
                txtRenameNewFileName.Text = value;
            }
        }

        internal override void SetEnabledState(bool enabled)
        {
            foreach (RepeaterItem item in dlFiles.Items)
            {
                (item.FindControl("imbRenameFile") as ImageButton).Visible = enabled;
                (item.FindControl("imbDeleteFile") as ImageButton).Visible = enabled;
            }

            btnAddAttachment.Visible = enabled;
        }
    }
}