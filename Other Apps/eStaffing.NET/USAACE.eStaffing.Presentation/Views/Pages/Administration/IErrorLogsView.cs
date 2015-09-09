using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface IErrorLogsView : IBaseView
    {
        IList<ErrorLog> ErrorLogList { get; set; }

        Nullable<Int32> SelectedErrorLogID { get; }

        Nullable<DateTime> ErrorDate { set; }

        String ErrorUser { set; }

        String ErrorType { set; }

        String ErrorUrl { set; }

        String ErrorMessage { set; }

        String ErrorStackTrace { set; }

        IList<Group> Roles { get; }
    }
}
