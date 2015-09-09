using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Controls
{
    public interface IFormControlView : IBaseView
    {
        Nullable<Int32> FormID { get; }

        Nullable<Int32> FormTypeID { get; }

        String FormLink { get; }

        String CurrentUserName { get; }

        Nullable<Int32> SubmitGroupID { get; }

        Nullable<Int32> SubmitOrganizationID { get; }

        IList<Group> Roles { get; }
    }
}
