using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }

        [DataType(DataType.Date)]
        public DateTime SessionDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public int AmountOfPeople { get; set; }
        public ModulesTutored ModuleTutor { get; set; }
    }
}
