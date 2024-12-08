using System.ComponentModel.DataAnnotations;

namespace EuropeBJJ.Data.Models
{
    public class Sponsor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public string Link { get; set; } = null!;

        public bool IsRemoved { get; set; }
    }
}
