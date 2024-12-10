using System.ComponentModel.DataAnnotations;

namespace EuropeBJJ.Models.Profile
{
    public class ProfileDetailedViewModel
    {
        public int ProfileId { get; set; }

        public string FullName { get; set; } = null!;

        public string Country { get; set; } = null!;

        public int Age { get; set; }

        public string Belt { get; set; } = null!;

        public string? Team { get; set; }

        public string? AboutText { get; set; }

        public string? Picture {  get; set; }

        public string? AccountId { get; set; }

        public string? Creator { get; set; }
    }
}
