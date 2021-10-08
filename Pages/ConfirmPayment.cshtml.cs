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
    public class ConfirmPaymentModel : PageModel
    {
        private readonly TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext _context;
        private readonly Use_Cases use_;

        public ConfirmPaymentModel(TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext context)
        {
            _context = context;
            use_ = new Use_Cases(_context);
        }

        public IndividualBooking IndividualBooking { get; set; }
        public Session Session { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IndividualBooking = await _context.IndividualBookings.Include(ib => ib.Session).ThenInclude(s => s.ModuleTutor).ThenInclude(mt => mt.Tutor).FirstOrDefaultAsync(m => m.BookingID == id);
            Session = IndividualBooking.Session;

            if (IndividualBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> onPostAsync(int? id)
        {
            IndividualBooking = await _context.IndividualBookings.FirstOrDefaultAsync(m => m.BookingID == id);
            use_.makePaymentIndividual(IndividualBooking);
            return RedirectToPage("./UnpaidBookings");
        }
    }
}
