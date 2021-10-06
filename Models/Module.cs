using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class Module
    {
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }

        public IList<ModulesTutored> ModulesTutored { get; set; }
    }
}
