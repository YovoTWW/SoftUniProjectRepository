using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EuropeBJJ.Constants.ModelConstants;

namespace EuropeBJJ.Data.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        [MaxLength(MaxNameLength)]
        public string FullName { get; set; } = null!;

        public string Country { get; set; } = null!;

        public int Age { get; set; } 

        public string Belt { get; set; } = null!;

        public string? Team { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string? AboutText { get; set; } 

        public string? Picture { get; set; }

        public List<EventProfile> EventsAttending { get; set; } = new List<EventProfile>();

        public string? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public IdentityUser Account { get; set; }

        public bool IsDeleted {  get; set; }

    }
}
