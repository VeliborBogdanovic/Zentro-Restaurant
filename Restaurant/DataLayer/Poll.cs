//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poll
    {
        public Poll()
        {
            this.poll_answer = new HashSet<poll_answer>();
        }
    
        public int Id { get; set; }
        public string question { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual ICollection<poll_answer> poll_answer { get; set; }
    }
}
