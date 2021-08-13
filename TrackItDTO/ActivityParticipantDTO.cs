using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItDTO
{
    public class ActivityParticipantDTO
    {
        public int APId { get; set; }
        public string ActivityStatus { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
        public string GithubLink { get; set; }
        public Nullable<int> PartiId { get; set; }
        public Nullable<int> ActivityId { get; set; }
    }
}
