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
    public class ConfirmBookingModel : PageModel
    {
        private readonly TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext _context;

        public ConfirmBookingModel(TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public Session Session { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Session = await _context.Sessions.FirstOrDefaultAsync(m => m.SessionID == id);

            if (Session == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
