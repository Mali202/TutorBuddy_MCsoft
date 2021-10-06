using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy.Data;
using TutorBuddy.Models;

namespace TutorBuddy.Pages.Resources
{
    public class IndexModel : PageModel
    {
        private readonly TutorBuddy.Data.TutorBuddyContext _context;

        public IndexModel(TutorBuddy.Data.TutorBuddyContext context)
        {
            _context = context;
        }

        public IList<Resource> Resource { get;set; }

        public async Task OnGetAsync()
        {
            Resource = await _context.Resource.ToListAsync();
        }
    }
}
