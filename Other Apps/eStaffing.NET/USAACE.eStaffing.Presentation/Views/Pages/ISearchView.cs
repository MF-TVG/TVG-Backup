using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages
{
    public interface ISearchView : IBaseView
    {
        String SearchTerm { get; }

        IList<Form> Forms { set; }

        IList<Group> Roles { get; }
    }
}
