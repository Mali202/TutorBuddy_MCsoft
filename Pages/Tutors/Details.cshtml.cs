using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notyf;

        public DetailsModel(TutorBuddy_MCsoftContext context, INotyfService notyf)
        {
            _context = context;
            use_ = new Use_Cases(_context);
            _notyf = notyf;
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
            _notyf.Success("Tutor Approved");
            return RedirectToPage("/Admin/ApproveTutors");
        }
    }
}
