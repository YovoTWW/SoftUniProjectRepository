using System.ComponentModel.DataAnnotations;

namespace EuropeBJJ.Models
{
    public class ProfileViewModel
    {       
        public string FullName { get; set; } = null!;

        public string Country { get; set; } = null!;
        
        public int Age { get; set; }

        public string Belt { get; set; } = null!;

        public string? Team { get; set; }
      
        public string? AboutText { get; set; }
    }
}
