using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static EuropeBJJ.Constants.ModelConstants;

namespace EuropeBJJ.Data.Models
{
    public class Seminar : Event
    {
        [Required]
        public string Organiser { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        public decimal? MembersPrice { get; set; }

        public decimal? NonMembersPrice { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string AccountId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AccountId))]
        public IdentityUser Account { get; set; } = null!;

        public bool IsRemoved { get; set; }
        public string Teacher { get; set; } = null!;
    }
}
