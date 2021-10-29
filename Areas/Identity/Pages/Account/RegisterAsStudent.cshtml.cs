using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TutorBuddy_MCsoft.Areas.Identity.Data;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models; 

namespace TutorBuddy_MCsoft.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel1 : PageModel
    {
        private readonly SignInManager<TutorBuddy_MCsoftUser> _signInManager;
        private readonly UserManager<TutorBuddy_MCsoftUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly TutorBuddy_MCsoftContext _context;

        public RegisterModel1(
            UserManager<TutorBuddy_MCsoftUser> userManager,
            SignInManager<TutorBuddy_MCsoftUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            TutorBuddy_MCsoftContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "The email address is required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Student number")]
            public int studentNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "UserName")]
            public string username { get; set; }

        }

        public List<SelectListItem> Options { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Options = new List<SelectListItem>
            {
                new SelectListItem { Text = "1st Year", Value = "1" },
                new SelectListItem { Text = "2nd Year", Value = "2" },
                new SelectListItem { Text = "3rd Year", Value = "3" }
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new TutorBuddy_MCsoftUser { UserName = Input.Email, Email = Input.Email, StudentNumber = Input.studentNumber, Role = "student"};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    Student student = new() { StudentNumber = Input.studentNumber, UserName = Input.username, EmailAddress = Input.Email, LevelOfStudy = Request.Form["level"]};
                    _context.Student.Add(student);
                    _context.SaveChanges();
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
