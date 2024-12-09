using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EuropeBJJ.Data.Models
{
    public class EventProfile
    {
        [Required]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        [Required]
        public int ProfileId { get; set; }

        [ForeignKey(nameof(ProfileId))]
        public Profile Profile { get; set; } = null!;
    }
}
