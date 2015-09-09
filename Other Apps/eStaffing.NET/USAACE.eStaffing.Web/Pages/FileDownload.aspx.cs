using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Presenters.Pages;
using USAACE.eStaffing.Presentation.Views.Pages;

namespace USAACE.eStaffing.Web.Pages
{
    public partial class FileDownload : BasePage, IFileDownloadView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private FileDownloadPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public FileDownloadPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new FileDownloadPresenter(this);
                }

                return _presenter;
            }
        }

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

        public Nullable<Int32> AttachmentID
        {
            get
            {
                return Request.QueryString["AttachmentID"].ToNullable<Int32>();
            }
        }

        public FormAttachmentData FileData
        {
            set
            {
                String fileName = value.ExtendedProperties.FileName;

                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName));

                Response.BinaryWrite(value.FileContent);
                Response.Flush();
                Response.End();
            }
        }
    }
}