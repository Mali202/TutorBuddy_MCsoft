using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class Student
    {
        [Key]
        public int StudentNumber { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string LevelOfStudy { get; set; }

    }
}
