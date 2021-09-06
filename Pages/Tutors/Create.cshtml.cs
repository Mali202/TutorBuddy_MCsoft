using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutorBuddy_MCsoft;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy.Pages.Tutors
{
    public class CreateModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;
        private readonly Use_Cases use_Cases;

        public CreateModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
            use_Cases = new Use_Cases(_context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tutor Tutor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Tutors.Add(Tutor);
            //await _context.SaveChangesAsync();
            use_Cases.Addtutor(Tutor);

            return RedirectToPage("./Index");
        }
    }
}
