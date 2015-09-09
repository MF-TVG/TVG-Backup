using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views
{
    public interface IBasePageView : IBaseView
    {
        IPrincipal CurrentUser { get; }

        String DisplayName { get; set; }

        Exception LastError { get; }

        String CurrentLocation { get; }
    }
}