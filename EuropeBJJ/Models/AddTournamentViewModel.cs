using System.ComponentModel.DataAnnotations;
using static EuropeBJJ.Constants.ModelConstants;

namespace EuropeBJJ.Models
{
    public class AddTournamentViewModel
    {
        [MaxLength(MaxEventNameLength)]
        public string Name { get; set; } = null!;

        [MaxLength(MaxNameLength)]
        public string Country { get; set; } = null!;

        [MaxLength(MaxNameLength)]
        public string City { get; set; } = null!;

        public string? Image { get; set; }

        public string Link { get; set; } = null!;

        public string Date { get; set; } = null!;
    }
}
