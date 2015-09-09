using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Presentation.Views.Pages.Administration
{
    public interface ILookupSettingsView : IBaseView
    {
        IList<FormType> FormTypeList { set; }

        Nullable<Int32> FormTypeID { get; }

        IList<Organization> OrganizationList { set; }

        Nullable<Int32> OrganizationID { get; }

        IList<FormTypeLookup> FormTypeLookupList { set; }

        String SelectedFormTypeLookup { get; }

        Nullable<Int32> FormTypeLookupID { get; set; }

        String LookupDataType { get; set; }

        DataTable LookupValues { get; set; }

        Nullable<Int32> SelectedLookupValue { get; set; }

        IDictionary<String, Object> LookupValueRow { get; set; }

        IList<Group> Roles { get; }
    }
}
