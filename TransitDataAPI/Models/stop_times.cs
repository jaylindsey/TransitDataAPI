//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransitDataAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class stop_times
    {
        public string trip_id { get; set; }
        public string arrival_time { get; set; }
        public string departure_time { get; set; }
        public int stop_id { get; set; }
        public Nullable<int> stop_sequence { get; set; }
        public Nullable<int> pickup_type { get; set; }
        public Nullable<int> drop_off_type { get; set; }
    }
}
