using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBuddy_MCsoft.Areas.Identity.Data;

namespace TutorBuddy_MCsoft.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<TutorBuddy_MCsoftUser> _UserManager;
        private readonly SignInManager<TutorBuddy_MCsoftUser> _SignInManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<TutorBuddy_MCsoftUser> UserManager, SignInManager<TutorBuddy_MCsoftUser> SignInManager)
        {
            _logger = logger;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }

        public bool isTutor { get; set; }

        public async Task OnGetAsync()
        {
            TutorBuddy_MCsoftUser user = await _UserManager.GetUserAsync(User);
            isTutor = false;
            if (_SignInManager.IsSignedIn(User))
            {
                isTutor = user.Role == "tutor"; 
            }
        }
    }
}
