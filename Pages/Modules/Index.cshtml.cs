using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy.Pages.Modules
{
    public class IndexModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;

        public IndexModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }

        public List<Module> Module { get;set; }

        public async Task OnGetAsync(string sort)
        {
            Module = await _context.Modules.ToListAsync();

            if(sort != null)
            {
                IList<Session> sessions = await _context.Sessions.ToListAsync();
                foreach (Module item in Module)
                {
                    int count = sessions.Count(s => s.ModuleTutor.ModuleID == item.ModuleID);
                }
            }
            
        }
    }
}
