using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuropeBJJ.Data.Models
{
    public class OrganizedEventAccount
    {
        [Required]
        public int OrganizedEventId { get; set; }

        [ForeignKey(nameof(OrganizedEventId))]
        public OrganizedEvent OrganizedEvent { get; set; } = null!;

        [Required]
        public string AccountId { get; set; } = null!;

        [ForeignKey(nameof(AccountId))]
        public IdentityUser Account { get; set; } = null!;
    }
}
