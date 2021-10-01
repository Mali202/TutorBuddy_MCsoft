using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy.Pages.Resources
{
    public class DetailsModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;

        public DetailsModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public Resource Resource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resource = await _context.Resources.FirstOrDefaultAsync(m => m.ID == id);

            if (Resource == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
