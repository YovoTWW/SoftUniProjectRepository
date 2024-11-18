using System.ComponentModel.DataAnnotations;
using static EuropeBJJ.Constants.ModelConstants;

namespace EuropeBJJ.Models
{
    public class AddSeminarViewModel
    {
        [MaxLength(MaxEventNameLength)]
        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        [MaxLength(MaxNameLength)]
        public string Country { get; set; } = null!;

        [MaxLength(MaxNameLength)]
        public string City { get; set; } = null!;

        public string Image { get; set; } = null!;

        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Organiser { get; set; } = null!;


        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Location { get; set; } = null!;

        public decimal? MembersPrice { get; set; }

        public decimal? NonMembersPrice { get; set; }

        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Teacher { get; set; } = null!;
    }
}
