using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TutorBuddy_MCsoft.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TutorBuddy_MCsoftUser class
    public class TutorBuddy_MCsoftUser : IdentityUser
    {
        [PersonalData]
        public int StudentNumber { get; set; }
        public string Role { get; set; }
    }
}
