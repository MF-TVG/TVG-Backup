using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Controls.FormControls.FileControl
{
    public interface IFileControlView : IFormControlView
    {
        Nullable<Int32> ReviewStatusID { get; }

        IList<FormAttachment> Attachments { get; set; }

        Nullable<Int32> SelectedAttachmentID { get; }

        String PostedFileName { get; }

        String PostedFileContentType { get; }

        Byte[] PostedFileContent { get; }

        String OldFileName { set; }

        String NewFileName { get; set; }
    }
}
