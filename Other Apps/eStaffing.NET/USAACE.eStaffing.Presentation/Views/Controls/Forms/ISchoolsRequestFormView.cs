using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface ISchoolsRequestFormView : IFormControlView
    {
        String Title { get; set; }

        String SelectedRequestType { get; set; }

        IList<SchoolsRequestType> RequestTypes { set; }

        IList<SchoolsRequestCheckItem> SelectedChecklistItems { get; set; }

        IList<SchoolsChecklistItem> ChecklistOptions { set; }

        String Who { get; set; }

        Nullable<Int16> APFTScore { get; set; }

        Nullable<Boolean> APFTPass { get; set; }

        Nullable<Byte> BodyFatPercent { get; set; }

        String SSDLevel { get; set; }

        String What { get; set; }

        String When { get; set; }

        String Where { get; set; }

        String Remarks { get; set; }
    }
}