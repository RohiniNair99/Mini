using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItDTO
{
    public class ActivityDTO
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string GitSubmission { get; set; }
        public Nullable<int> CGId { get; set; }
        public Nullable<int> FacultyId { get; set; }
    }
}
