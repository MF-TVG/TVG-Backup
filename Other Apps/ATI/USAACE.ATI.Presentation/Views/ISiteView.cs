using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views
{
    public interface ISiteView : IBaseView
    {
        String IADesignation { set; }
    }
}