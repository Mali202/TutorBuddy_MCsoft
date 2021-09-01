using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class StudentGroupBooking
    {
        public int StudentNumber { get; set; }
        public Student Student { get; set; }

        public int BookingID { get; set; }
        public GroupBooking Booking { get; set; }
    }
}
