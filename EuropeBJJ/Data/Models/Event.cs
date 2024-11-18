using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EuropeBJJ.Constants.ModelConstants;

namespace EuropeBJJ.Data.Models
{
    public class Event
    {
        public Event ()
        {
            //this.Id = Guid.NewGuid ();
            this.Discriminator = GetType().Name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxEventNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        public string? Image { get; set; }

        public string Discriminator { get; } = null!;

        public string? Link { get; set; }

        public string? Organiser { get; set; }

        public string? Location { get; set; }

        public decimal? MembersPrice { get; set; }

        public decimal? NonMembersPrice { get; set; }


        [MaxLength(MaxDescriptionLength)]
        public string? Description { get; set; } = null!;
     
        public string? AccountId { get; set; }

        
        [ForeignKey(nameof(AccountId))]
        public IdentityUser Account { get; set; }

        public bool IsRemoved { get; set; }
        public string? Teacher { get; set; }
    }
}
