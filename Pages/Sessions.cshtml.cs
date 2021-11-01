using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft.Pages
{
    public class SessionsModel : PageModel
    {
        private readonly TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext _context;

        public SessionsModel(TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public IList<Session> Session { get;set; }
        public IList<IndividualBooking> bookings { get; set; }
        public int? studentNum { get; set; }

        public async Task OnGetAsync(int? ss, string sort)
        {
            studentNum = ss;
            bookings = await _context.IndividualBookings.Include(ib => ib.Session).ThenInclude(s => s.ModuleTutor).ThenInclude(mt => mt.Tutor).Where(ib => ib.Student.StudentNumber == ss).ToListAsync(); 
            Session = bookings.Select(ib => ib.Session).ToList();
            if(sort != null)
            {
                Session = Session.OrderBy(s => s.SessionDate).ToList();
            }
        }
    }
}
