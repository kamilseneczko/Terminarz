using System;
using System.Collections.Generic;


namespace ContosoUniversity.Models
{
    public class Activity 
    {
        public int ID { get; set; }
        public string ActivityName { get; set; }
        public DateTime ActivityDate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}