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
using USAACE.eStaffing.Business.Workflow;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Presentation.Presenters.Pages
{
    public class FileDownloadPresenter : BasePresenter
    {
        /// <summary>
        /// The IFileDownloadView for the FileDownloadPresenter
        /// </summary>
        private new IFileDownloadView View
        {
            get
            {
                return base.View as IFileDownloadView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ISearchView
        /// </summary>
        /// <param name="view">The ISearchView</param>
        public FileDownloadPresenter(IFileDownloadView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (this.View.AttachmentID.HasValue)
            {
                FormAttachment attachment = new FormAttachment { FormAttachmentID = this.View.AttachmentID };
                attachment = DataService.LoadFormAttachment(attachment);

                Form form = new Form { FormID = attachment.FormID };
                form = DataService.LoadForm(form);

                FormType formType = new FormType { FormTypeID = form.FormTypeID };

                ReviewStatus status = new ReviewStatus { FormID = form.FormID };
                IList<ReviewStatus> reviewStatuses = DataService.ListReviewStatuses(status);

                IList<OrganizationGroup> userOrganizationGroups = DataService.ListOrganizationGroupsForGroups(this.View.Roles);

                if (PermissionUtil.CheckFormViewPermission(form, formType, reviewStatuses, this.View.Roles, userOrganizationGroups))
                {
                    FormAttachmentData data = new FormAttachmentData { FormAttachmentID = attachment.FormAttachmentID };
                    data = DataService.LoadFormAttachmentData(data);

                    data.ExtendedProperties.FileName = attachment.FileName;
                    data.ExtendedProperties.FileSize = attachment.FileSize.GetValueOrDefault(0);

                    this.View.FileData = data;
                }
                else
                {
                    throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_VIEW_FORM);
                }
            }
            else
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_VIEW_FORM);
            }
        }
    }
}
