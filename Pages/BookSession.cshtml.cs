using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutorBuddy_MCsoft.Models;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft;
using Microsoft.AspNetCore.Identity;
using TutorBuddy_MCsoft.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace TutorBuddy.Pages.Sessions
{
    public class CreateModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;
        private readonly Use_Cases use_;

        public CreateModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
            use_ = new Use_Cases(_context);
        }

        public List<SelectListItem> Options { get; set; }

        public async Task<IActionResult> OnGetAsync(int? ts, int? ss)
        {
            if (ts == null || ss == null)
            {
                return NotFound();
            }

            IList<ModulesTutored> modules = _context.ModulesTutored.Include(t => t.Tutor).Include(m => m.Module).Where(mt => mt.StudentNumber == ts).ToList();
            Options = modules.Select(mt =>
                                                new SelectListItem
                                                {
                                                    Value = mt.Module.ModuleID.ToString(),
                                                    Text = mt.Module.ModuleName
                                                }).ToList();

            tutor = await _context.Tutors.FirstOrDefaultAsync(t => t.StudentNumber == ts);
            return Page();
        }

        [BindProperty]
        public Session Session { get; set; }

        public Tutor tutor { get; set; }
        public ModulesTutored moduleTutor { get; set; }
        public Student student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? ts, int? ss)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            tutor = await _context.Tutors.FirstOrDefaultAsync(t => t.StudentNumber == ts);
            student = await _context.Student.FirstOrDefaultAsync(s => s.StudentNumber == ss);
            int id = int.Parse(Request.Form["modID"]);
            moduleTutor = _context.ModulesTutored.FirstOrDefault(mt => (mt.StudentNumber == tutor.StudentNumber) && (mt.ModuleID == id));
            Session.ModuleTutor = moduleTutor;
            IndividualBooking booking = new() { Paid = false, Session = Session, Student = student };
            use_.bookSessionIndividual(booking);
            return RedirectToPage("./Payment", new { id = booking.Session.SessionID });
        }
    }
}
