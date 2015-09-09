using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface IAwardsSheetView : IFormControlView
    {
        String Name { get; set; }

        String Organization { get; set; }

        Nullable<DateTime> PresentationDate { get; set; }

        String DutyPosition { get; set; }

        String PreviousAward { get; set; }

        IList<AwardLevel> PreviousAwards { set; }

        Nullable<Boolean> SoldierFlagged { get; set; }

        String StationTime { get; set; }

        Boolean ShowSoldierFlaggedReason { set; }

        String SoldierFlaggedReason { get; set; }

        String AwardReason { get; set; }

        IList<AwardReason> AwardReasons { set; }

        String AwardLevel { get; set; }

        IList<AwardLevel> AwardLevels { set; }

        Nullable<Int16> Height { get; set; }

        Nullable<Int16> Weight { get; set; }

        Nullable<Byte> Age { get; set; }

        Nullable<Byte> BodyFatAuth { get; set; }

        Nullable<Byte> BodyFatHas { get; set; }

        Nullable<Boolean> BodyFatGo { get; set; }

        Nullable<DateTime> APFTDate { get; set; }

        Nullable<Boolean> APFTPass { get; set; }

        Nullable<Boolean> Profile { get; set; }

        Nullable<Byte> TotalServiceYears { get; set; }

        String KeyPositions { get; set; }

        String CurrentPositions { get; set; }

        String CurrentAwards { get; set; }

        String LeaderComments { get; set; }

        String SeniorNCOComments { get; set; }

        Nullable<DateTime> UnitSignDate { get; set; }

        String UnitComments { get; set; }
    }
}
