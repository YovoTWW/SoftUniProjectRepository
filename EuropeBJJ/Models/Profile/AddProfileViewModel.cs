using System.ComponentModel.DataAnnotations;
using static EuropeBJJ.Constants.ModelConstants;
using static EuropeBJJ.Constants.CountriesList;
using static EuropeBJJ.Constants.BeltLevelList;

namespace EuropeBJJ.Models.Profile
{
    public class AddProfileViewModel
    {
        [MinLength(MinNameLength, ErrorMessage = "Organiser Name cant be less than 5 characters long")]
        [MaxLength(MaxNameLength, ErrorMessage = "Organiser Name cant be more than 50 characters long")]
        public string FullName { get; set; } = null!;

        public string Country { get; set; } = null!;

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120 ")]
        public int Age { get; set; }

        public string Belt { get; set; } = null!;

        [MinLength(MinNameLength, ErrorMessage = "Team Name cant be less than 5 characters long")]
        [MaxLength(MaxNameLength, ErrorMessage = "Team Name cant be more than 50 characters long")]
        public string? Team { get; set; }

        [MaxLength(MaxDescriptionLength, ErrorMessage = "About text cant be more than 250 characters long")]
        public string? AboutText { get; set; }

        public string? Picture { get; set; }

        public bool Exists { get; set; }

        public List<string> Countries = ListOfCountries;

        public List<string> Belts = BeltLevels;
    }
}
