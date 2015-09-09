using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Entities;

namespace USAACE.ATI.Domain.Entities
{
    public partial class ActualHoursExtended
    {
        public Nullable<Boolean> MarkForDeletion { get; set; }
    }

    public partial class ClassExtended
    {
        public Nullable<DateTime> CalcReportDate { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<Boolean> POIMatch { get; set; }
        public Nullable<Boolean> IsSelected { get; set; }
        public String POIName { get; set; }
        public String ADPCode { get; set; }
    }

    public partial class CourseExtended
    {
        public String DisplayName { get; set; }
    }
}
