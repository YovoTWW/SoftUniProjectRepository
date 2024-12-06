using System.ComponentModel.DataAnnotations;
using static EuropeBJJ.Constants.ModelConstants;

namespace EuropeBJJ.Models
{
    public class AddSeminarViewModel
    {


        [MaxLength(MaxEventNameLength, ErrorMessage = "Event Name cant be more than 100 characters long")]
        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        //[MaxLength(MaxNameLength, ErrorMessage = "Country Name cant be more than 50 characters long")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Country name can only include latin letters")]
        public string Country { get; set; } = null!;

        [MaxLength(MaxNameLength)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City name can only include latin letters")]
        public string City { get; set; } = null!;

        public string? Image { get; set; }

        [MinLength(MinNameLength, ErrorMessage = "Organiser Name cant be less than 5 characters long")]
        [MaxLength(MaxNameLength, ErrorMessage = "Organiser Name cant be more than 50 characters long")]
        public string Organiser { get; set; } = null!;


        [MinLength(MinNameLength, ErrorMessage = "Location Name cant be less than 5 characters long")]
        [MaxLength(MaxNameLength, ErrorMessage = "Location Name cant be more than 50 characters long")]
        public string Location { get; set; } = null!;

        [Range(0.00, double.MaxValue, ErrorMessage = "Price cant be less than 0")]
        public decimal? MembersPrice { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = "Price cant be less than 0")]
        public decimal? NonMembersPrice { get; set; }

        [MinLength(MinDescriptionLength, ErrorMessage = "Description text cant be less than 10 characters long")]
        [MaxLength(MaxDescriptionLength, ErrorMessage = "Description text cant be more than 250 characters long")]
        public string Description { get; set; } = null!;

        [MinLength(MinNameLength, ErrorMessage = "Teacher Name cant be less than 5 characters long")]
        [MaxLength(MaxNameLength, ErrorMessage = "Teacher Name cant be more than 50 characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Teacher Name can only include latin letters")]
        public string Teacher { get; set; } = null!;
    }
}
