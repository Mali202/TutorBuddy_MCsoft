using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }

        public Student Student { get; set; }
        public Tutor Tutor { get; set; }
    }
}
