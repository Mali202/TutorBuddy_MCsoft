
namespace TutorBuddy_MCsoft.Models
{
    public class Resource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }

        public Module Module { get; set; }
    }
}
