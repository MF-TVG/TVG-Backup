using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface ITransmittalSheetView : IFormControlView
    {
        Nullable<Boolean> IsTaskerResponse { get; set; }

        Boolean ShowTaskerNumber { set; }

        String TaskerNumber { get; set; }

        String Subject { get; set; }

        String ActionOfficer { get; set; }

        String OfficeSymbol { get; set; }

        String PhoneNumber { get; set; }

        Nullable<DateTime> SuspenseDate { get; set; }

        Nullable<DateTime> FormDate { get; set; }

        Nullable<Boolean> Signature { get; set; }

        Nullable<Boolean> Approval { get; set; }

        Nullable<Boolean> Information { get; set; }

        Nullable<Boolean> ReadAhead { get; set; }

        Nullable<Boolean> Other { get; set; }

        Boolean ShowOtherText { set; }

        String OtherText { get; set; }

        String Recommendation { get; set; }

        Nullable<Boolean> RecommendationCSM { get; set; }

        Nullable<Boolean> RecommendationCPG { get; set; }

        Nullable<Boolean> RecommendationDCOS { get; set; }

        Nullable<Boolean> RecommendationDCG { get; set; }

        Nullable<Boolean> RecommendationCG { get; set; }

        String Discussion { get; set; }

        Nullable<Boolean> KeyAreaFunding { get; set; }

        Nullable<Boolean> KeyAreaPolicy { get; set; }

        Nullable<Boolean> KeyAreaEquipment { get; set; }

        Nullable<Boolean> KeyAreaLegal { get; set; }

        Nullable<Boolean> KeyAreaTraining { get; set; }

        Nullable<Boolean> KeyAreaPersonnel { get; set; }

        Nullable<Boolean> KeyAreaCongressional { get; set; }

        Nullable<Boolean> KeyAreaStrategy { get; set; }

        Nullable<Boolean> KeyAreaOther { get; set; }

        Boolean ShowKeyAreaOtherText { set; }

        String KeyAreaOtherText { get; set; }

        String PrincipalComments { get; set; }

        IList<TransmittalCoord> Coordinations { get; set; }

        Nullable<Int32> SelectedCoordID { get; set; }

        Nullable<Boolean> CoordResponse { get; set; }

        String CoordAgency { get; set; }

        String CoordName { get; set; }

        String CoordPhone { get; set; }

        Nullable<DateTime> CoordDate { get; set; }

        String CoordRemarks { get; set; }
    }
}
