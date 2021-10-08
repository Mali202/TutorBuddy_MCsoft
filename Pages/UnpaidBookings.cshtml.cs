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
    public class UnpaidBookingsModel : PageModel
    {
        private readonly TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext _context;

        public UnpaidBookingsModel(TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public IList<IndividualBooking> IndividualBooking { get;set; }

        public async Task OnGetAsync()
        {
            IndividualBooking = await _context.IndividualBookings.Include(ib => ib.Student).Include(ib => ib.Session).ThenInclude(s => s.ModuleTutor).ThenInclude(mt => mt.Module).Where(ib => !ib.Paid).ToListAsync();
        }
    }
}
