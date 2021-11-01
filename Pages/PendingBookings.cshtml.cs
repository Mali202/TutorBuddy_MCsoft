using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Areas.Identity.Data;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft.Pages
{
    public class PendingBookingsModel : PageModel
    {
        private readonly TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext _context;
        private readonly UserManager<TutorBuddy_MCsoftUser> _usermanager;

        public PendingBookingsModel(TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext context, UserManager<TutorBuddy_MCsoftUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        public List<IndividualBooking> IndividualBooking { get;set; }

        public async Task OnGetAsync(int? id, string sort)
        {
            TutorBuddy_MCsoftUser user = await _usermanager.GetUserAsync(User);
            IndividualBooking = await _context.IndividualBookings.Include(ib => ib.Session).ThenInclude(s => s.ModuleTutor.Module).Include(ib => ib.Student).Where(ib => ib.Session.ModuleTutor.Tutor.StudentNumber == id).ToListAsync();
            if (sort != null)
            {
                IndividualBooking = IndividualBooking.OrderBy(ib => ib.Session.SessionDate).ToList(); 
            }
        }
    }
}
