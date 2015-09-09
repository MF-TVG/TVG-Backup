using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface IEvaluationReportView : IFormControlView
    {
        String ActionOfficer { get; set; }

        String Ratee { get; set; }

        Nullable<DateTime> ThruDate { get; set; }

        String Rater { get; set; }

        String IntermediateRater { get; set; }

        String SeniorRater { get; set; }

        String Reviewer { get; set; }

        String SubmissionReason { get; set; }

        Nullable<Boolean> SupportForm { get; set; }

        Nullable<Boolean> CivilianForm { get; set; }

        Nullable<Boolean> PTCard { get; set; }

        Nullable<Boolean> RecommendedComments { get; set; }

        String Remarks { get; set; }

        Nullable<DateTime> LossDate { get; set; }
    }
}
