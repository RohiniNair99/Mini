//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackItDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityPrticipantMap
    {
        public int APId { get; set; }
        public string ActivityStatus { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
        public string GithubLink { get; set; }
        public Nullable<int> PartiId { get; set; }
        public Nullable<int> ActivityId { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
