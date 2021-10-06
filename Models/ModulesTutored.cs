using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class ModulesTutored
    {
        public int StudentNumber { get; set; }
        public Tutor Tutor { get; set; }

        public int ModuleID { get; set; }
        public Module Module { get; set; }
    }
}
