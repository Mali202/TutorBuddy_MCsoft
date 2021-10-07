using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorBuddy_MCsoft.Models
{
    public class BankDetails
    {
        public int ID { get; set; }
        public string HolderName { get; set; }
        public string BankName { get; set; }
        public int AccNumber { get; set; }
        public int Ref { get; set; }
    }
}
