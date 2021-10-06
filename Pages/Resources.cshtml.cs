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
    public class IndexModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;

        public IndexModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public IList<Resource> Resource { get;set; }

        public async Task OnGetAsync()
        {
            Resource = await _context.Resources.ToListAsync();
        }
    }
}
