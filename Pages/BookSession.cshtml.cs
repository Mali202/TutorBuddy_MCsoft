using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutorBuddy_MCsoft.Models;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft;
using Microsoft.AspNetCore.Identity;
using TutorBuddy_MCsoft.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace TutorBuddy.Pages.Sessions
{
    public class CreateModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;
        private readonly Use_Cases use_;

        public CreateModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
            use_ = new Use_Cases(_context);
        }

        public async Task<IActionResult> OnGetAsync(int? ts, int? ss)
        {
            if (ts == null || ss == null)
            {
                return NotFound();
            }
            moduleTutor = await _context.ModulesTutored.FirstOrDefaultAsync(t => t.StudentNumber == ts);
            student = await _context.Student.FirstOrDefaultAsync(s => s.StudentNumber == ss);
            return Page();
        }

        [BindProperty]
        public Session Session { get; set; }

        public ModulesTutored moduleTutor { get; set; }
        public Student student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IndividualBooking booking = new() { Paid = false, Session = Session, Student = student };
            use_.bookSessionIndividual(booking);
            return RedirectToPage("./Index");
        }
    }
}
