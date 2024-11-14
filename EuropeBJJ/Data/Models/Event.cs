using System.ComponentModel.DataAnnotations;
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
    }
}
