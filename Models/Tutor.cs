using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class Tutor
    {
        [Key]
        public int StudentNumber { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool Approved { get; set; }
        public double Fee { get; set; }
        public double AvgRating { get; set; }

        public IList<ModulesTutored> ModulesTutored { get; set; }
    }
}
