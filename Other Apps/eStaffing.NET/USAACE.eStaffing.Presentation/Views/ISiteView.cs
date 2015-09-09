using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views
{
    public interface ISiteView : IBaseView
    {
        IList<FormType> FormTypes { set; }

        String IADesignation { set; }
    }
}