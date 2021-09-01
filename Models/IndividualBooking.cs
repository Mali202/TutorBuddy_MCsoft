using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class IndividualBooking
    {
        [Key]
        public int BookingID { get; set; }
        public bool Paid { get; set; }
        public Session Session { get; set; }
        public Student Student { get; set; }
    }
}
