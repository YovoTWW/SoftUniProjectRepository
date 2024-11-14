using System.ComponentModel.DataAnnotations;

namespace EuropeBJJ.Data.Models
{
    public class Tournament : Event
    {
        [Required]
        public string Link { get; set; } = null!;
    }
}
