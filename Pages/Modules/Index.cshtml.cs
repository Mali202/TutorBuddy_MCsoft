using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notyf;

        public IndexModel(TutorBuddy_MCsoftContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        public List<Module> Module { get;set; }

        public async Task OnGetAsync(string sort)
        {
            Module = await _context.Modules.ToListAsync();

            if(sort != null)
            {
                IList<Session> sessions = await _context.Sessions.Include(s => s.ModuleTutor).ToListAsync();
                //IComparer<Module> comparer = new i
                Module = Module.OrderByDescending(m => sessions.Count(s => s.ModuleTutor.ModuleID.Equals(m.ModuleID))).ToList();
                //Module.Sort((m1, m2) 
                //    => sessions.Count(s => s.ModuleTutor.Module.ModuleCode.Equals(m1.ModuleCode)) - sessions.Count(s => s.ModuleTutor.Module.ModuleCode.Equals(m2.ModuleCode)));
            }
            
        }
    }
}
