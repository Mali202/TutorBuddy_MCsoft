using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender _emailSender;

        public IndexModel(IEmailSender emailSender, ILogger<IndexModel> logger, UserManager<TutorBuddy_MCsoftUser> UserManager, SignInManager<TutorBuddy_MCsoftUser> SignInManager)
        {
            _logger = logger;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _emailSender = emailSender;
        }

        public string role { get; set; }
        public int sNum { get; set; }

        public async Task OnGetAsync()
        {
            await _emailSender.SendEmailAsync("chloe.welgemoed1999@gmail.com","Confirm", $"Please confirm your account by <a href=''>clicking here</a>.");
            TutorBuddy_MCsoftUser user = await _UserManager.GetUserAsync(User);
            
            role = "student";
            if (_SignInManager.IsSignedIn(User))
            {
                sNum = user.StudentNumber;
                role = user.Role; 
            }
        }
    }
}
