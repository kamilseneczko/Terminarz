using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Celebration
    {
        public int ID { get; set; }
        public string TypeOfCelebration { get; set; }
        public string Name { get; set; }
        public DateTime CelebrationDate { get; set; }
        
        public virtual ApplicationUser User { get; set; }
    }
}