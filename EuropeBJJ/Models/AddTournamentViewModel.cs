using System.ComponentModel.DataAnnotations;
using static EuropeBJJ.Constants.ModelConstants;
using static EuropeBJJ.Constants.CountriesList;

namespace EuropeBJJ.Models
{
    using EuropeBJJ.Constants;
    public class AddTournamentViewModel
    {
        [MaxLength(MaxEventNameLength, ErrorMessage = "Event Name cant be more than 100 characters long")]
        public string Name { get; set; } = null!;

        //[MaxLength(MaxNameLength, ErrorMessage = "Country Name cant be more than 50 characters long")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Country name can only include latin letters")]
        
        public string Country { get; set; } = null!;

        [MaxLength(MaxNameLength)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City name can only include latin letters")]
        public string City { get; set; } = null!;

        public string? Image { get; set; }

        public string Link { get; set; } = null!;

        public string Date { get; set; } = null!;

        public List<string> Countries = ListOfCountries;
    }
}
