using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft.Pages
{
    public class CreateresourceModel : PageModel
    {
        private readonly TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext _context;
        private readonly INotyfService _notyf;

        public CreateresourceModel(TutorBuddy_MCsoft.Data.TutorBuddy_MCsoftContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        public List<SelectListItem> Options { get; set; }

        public IActionResult OnGet()
        {
            Options = _context.Modules.Select(m =>
                                                    new SelectListItem
                                                    {
                                                        Value = m.ModuleID.ToString(),
                                                        Text = m.ModuleName
                                                    }).ToList();
            return Page();
        }

        [BindProperty]
        public Resource Resource { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = int.Parse(Request.Form["modID"]);
            Module module = _context.Modules.FirstOrDefault(m => m.ModuleID == id);
            Resource.Module = module;
            _context.Resources.Add(Resource);
            await _context.SaveChangesAsync();
            _notyf.Success("Files Uploaded");
            return RedirectToPage("/Index");
        }
    }
}
