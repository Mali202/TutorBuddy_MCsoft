using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy.Pages.Tutors
{
    public class DetailsModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;
        private readonly Use_Cases use_;

        public DetailsModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
            use_ = new Use_Cases(_context);
        }

        public Tutor Tutor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tutor = await _context.Tutors.FirstOrDefaultAsync(m => m.StudentNumber == id);

            if (Tutor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Tutor = await _context.Tutors.FirstOrDefaultAsync(m => m.StudentNumber == id);
            use_.approveTutor(Tutor);
            return RedirectToPage("./ApproveTutors");
        }
    }
}
