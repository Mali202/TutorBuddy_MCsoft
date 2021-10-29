using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft.Pages.Tutors
{
    public class ApproveTutorsModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;

        public ApproveTutorsModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public IList<Tutor> Tutor { get;set; }

        public async Task OnGetAsync()
        {
            Tutor = await _context.Tutors.Where(t => !t.Approved).ToListAsync();
        }
    }
}
