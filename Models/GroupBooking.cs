using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class GroupBooking
    {
        [Key]
        public int BookingID { get; set; }
        public bool Paid { get; set; }
        public Session Session { get; set; }
        string test;

        public IList<StudentGroupBooking> Students { get; set; }
    }
}
