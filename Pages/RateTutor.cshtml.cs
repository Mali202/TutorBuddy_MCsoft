using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft.Pages
{
    public class RateTutorModel : PageModel
    {
        private readonly TutorBuddy_MCsoftContext _context;
        private readonly Use_Cases use_;

        public RateTutorModel(TutorBuddy_MCsoftContext context)
        {
            _context = context;
            use_ = new Use_Cases(_context);
        }

        public Tutor tutor { get; set; }
        public Student student { get; set; }
        [BindProperty]
        public string stars { get; set; }
        [BindProperty]
        public string comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? ts, int? ss)
        {
            tutor = await _context.Tutors.FirstOrDefaultAsync(t => t.StudentNumber == ts);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? ts, int? ss)
        {
            tutor = await _context.Tutors.FirstOrDefaultAsync(t => t.StudentNumber == ts);
            student = await _context.Student.FirstOrDefaultAsync(s => s.StudentNumber == ss);
            double rating = stars != null ? double.Parse(stars) : 0;
            Review review = new() { Rating = rating, Comment = comment, Student = student, Tutor = tutor };
            use_.addReview(review);
            return RedirectToPage("./Index");
        }
    }
}
