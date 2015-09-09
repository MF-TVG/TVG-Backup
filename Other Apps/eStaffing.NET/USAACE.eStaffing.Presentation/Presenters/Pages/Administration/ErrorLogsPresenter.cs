using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common;
using USAACE.Common.Exceptions;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Presentation.Views.Pages.Administration;

namespace USAACE.eStaffing.Presentation.Presenters.Pages.Administration
{
    public class ErrorLogsPresenter : BasePresenter
    {
        /// <summary>
        /// The IErrorLogsView for the ErrorLogsPresenter
        /// </summary>
        private new IErrorLogsView View
        {
            get
            {
                return base.View as IErrorLogsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ISystemView
        /// </summary>
        /// <param name="view">The ISystemView</param>
        public ErrorLogsPresenter(IErrorLogsView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (!PermissionUtil.CheckAdminPermission(this.View.Roles))
            {
                throw new USAACEException(ExceptionType.Unrecoverable, MessageConstants.NOT_ALLOWED_ADMIN);
            }
            else
            {
                this.View.ErrorLogList = DataService.ListErrorLogs().OrderByDescending(x => x.ErrorDate).ToList();
            }
        }

        public void LoadErrorLog()
        {
            if (this.View.SelectedErrorLogID.HasValue)
            {
                ErrorLog log = this.View.ErrorLogList.FirstOrDefault(x => x.ErrorLogID == this.View.SelectedErrorLogID);

                this.View.ErrorDate = log.ErrorDate;
                this.View.ErrorUser = log.UserName;
                this.View.ErrorType = log.ErrorType;
                this.View.ErrorUrl = log.Location;
                this.View.ErrorMessage = log.Message;
                this.View.ErrorStackTrace = log.StackTrace;
            }
        }
    }
}
