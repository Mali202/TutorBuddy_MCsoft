using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Areas.Identity.Data;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy.Pages.Tutors
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class IndexModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;
        private readonly UserManager<TutorBuddy_MCsoftUser> _UserManager;
        public TutorBuddy_MCsoftUser _user;

        public IndexModel(TutorBuddy_MCsoftContext context, UserManager<TutorBuddy_MCsoftUser> UserManager)
        {
            _context = context;
            _UserManager = UserManager;
        }

        public IList<Tutor> Tutor { get;set; }
        public IList<Module> modules { get; set; }

        public async Task OnGetAsync()
        {
            Tutor = await _context.Tutors.Include(t => t.ModulesTutored).ThenInclude(m => m.Module).ToListAsync();
            _user = await _UserManager.GetUserAsync(User);
        }
    }
}
