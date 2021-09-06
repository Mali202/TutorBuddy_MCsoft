using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBuddy_MCsoft.Data;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft
{
    public class Use_Cases
    {
        private readonly TutorBuddy_MCsoftContext _context;
        public Use_Cases(TutorBuddy_MCsoftContext context)
        {
            _context = context;
        }
        //approved and rating are not set by ui
       
    }
}
