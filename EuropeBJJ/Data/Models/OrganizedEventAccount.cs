using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuropeBJJ.Data.Models
{
    public class EventAccount
    {
        [Required]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        [Required]
        public string AccountId { get; set; } = null!;

        [ForeignKey(nameof(AccountId))]
        public IdentityUser Account { get; set; } = null!;
    }
}
