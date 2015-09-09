using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Controls.FormControls.FileControl;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.FormControls.FileControl
{
    public class FileControlPresenter : BasePresenter
    {
        /// <summary>
        /// The IFileControlView for the FileControlPresenter
        /// </summary>
        private new IFileControlView View
        {
            get
            {
                return base.View as IFileControlView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IFileControlView
        /// </summary>
        /// <param name="view">The IFileControlView</param>
        public FileControlPresenter(IFileControlView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (this.View.FormID.HasValue)
            {
                FormAttachment attachment = new FormAttachment();
                attachment.FormID = this.View.FormID;
                attachment.ReviewStatusID = this.View.ReviewStatusID;

                IList<FormAttachment> attachments = DataService.ListFormAttachments(attachment).OrderBy(x => x.FileName).ToList();

                this.View.Attachments = this.View.ReviewStatusID.HasValue ? attachments : attachments.Where(x => x.ReviewStatusID == null).ToList();
            }
            else
            {
                this.View.Attachments = new List<FormAttachment>();
            }
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                foreach (FormAttachment attachment in this.View.Attachments)
                {
                    if (attachment.FormAttachmentID < 0)
                    {
                        attachment.FormAttachmentID = null;
                    }

                    if (attachment.ExtendedProperties.MarkForDeletion != true && attachment.FormAttachmentID.HasValue == false)
                    {
                        DataService.SaveFormAttachment(attachment);

                        FormAttachmentData dataToSave = new FormAttachmentData();
                        dataToSave.FormAttachmentID = attachment.FormAttachmentID;
                        dataToSave.FileContent = attachment.ExtendedProperties.FileContent;

                        dataToSave = DataService.SaveFormAttachmentData(dataToSave);
                    }
                    else if (attachment.ExtendedProperties.MarkForDeletion == true && attachment.FormAttachmentID.HasValue)
                    {
                        DataService.DeleteFormAttachment(attachment);
                    }
                    else if (!String.IsNullOrEmpty(attachment.ExtendedProperties.NewFileName))
                    {
                        attachment.FileName = attachment.ExtendedProperties.NewFileName;

                        DataService.SaveFormAttachment(attachment);
                    }
                }
            }

            Load();
        }

        public void AddAttachment()
        {
            String fullPath = this.View.PostedFileName;
            Byte[] fileContent = this.View.PostedFileContent;
            String fileContentType = this.View.PostedFileContentType;

            String fileName = FileUtil.GetFileName(fullPath);

            if (FileUtil.FileValid(fileName))
            {
                IList<FormAttachment> attachments = this.View.Attachments;

                Int32 newId = -1 * attachments.Count(x => x.FormAttachmentID < 0) - 1;

                FormAttachment attachment = new FormAttachment();

                Int32 i = 0;

                while (attachments.Any(x => x.FileName == fileName))
                {
                    String newFileName = FileUtil.GetFileName(fullPath);

                    fileName = newFileName.Insert(newFileName.LastIndexOf("."), "_" + i.ToString());

                    i += 1;
                }

                attachment.FormAttachmentID = newId;
                attachment.FormID = this.View.FormID;
                attachment.ReviewStatusID = this.View.ReviewStatusID;
                attachment.FileName = fileName;
                attachment.FileSize = fileContent.Length;
                attachment.ContentType = fileContentType;
                attachment.CreationDate = DateTime.Now;
                attachment.LastModifiedDate = DateTime.Now;
                attachment.ExtendedProperties.FileStatus = "(Not Yet Saved)";
                attachment.ExtendedProperties.FileContent = fileContent;

                attachments.Add(attachment);

                this.View.Attachments = attachments;
            }
            else
            {
                throw new USAACEException(ExceptionType.Recoverable, MessageConstants.INVALID_FILE_NAME_TYPE);
            }
        }

        public void DeleteAttachment()
        {
            if (this.View.SelectedAttachmentID.HasValue)
            {
                IList<FormAttachment> attachments = this.View.Attachments;

                attachments.FirstOrDefault(x => x.FormAttachmentID == this.View.SelectedAttachmentID).ExtendedProperties.MarkForDeletion = true;

                this.View.Attachments = attachments;
            }
        }

        public void LoadAttachment()
        {
            if (this.View.SelectedAttachmentID.HasValue)
            {
                IList<FormAttachment> attachments = this.View.Attachments;

                FormAttachment attachment = attachments.FirstOrDefault(x => x.FormAttachmentID == this.View.SelectedAttachmentID);

                this.View.OldFileName = attachment.FileName;
                this.View.NewFileName = !String.IsNullOrEmpty(attachment.ExtendedProperties.NewFileName) ? attachment.ExtendedProperties.NewFileName : attachment.FileName;
            }
        }

        public void RenameAttachment()
        {
            if (this.View.SelectedAttachmentID.HasValue)
            {
                if (FileUtil.FileValid(this.View.NewFileName))
                {
                    IList<FormAttachment> attachments = this.View.Attachments;

                    FormAttachment attachment = attachments.FirstOrDefault(x => x.FormAttachmentID == this.View.SelectedAttachmentID);

                    if (attachment.FileName != this.View.NewFileName)
                    {
                        if (attachment.FormAttachmentID > 0)
                        {
                            attachment.ExtendedProperties.NewFileName = this.View.NewFileName;
                            attachment.ExtendedProperties.FileStatus = "(Rename Pending)";
                        }
                        else
                        {
                            attachment.FileName = this.View.NewFileName;
                        }

                        this.View.Attachments = attachments;
                    }
                }
                else
                {
                    throw new USAACEException(ExceptionType.Recoverable, MessageConstants.INVALID_FILE_NAME_TYPE);
                }
            }
        }
    }
}
