namespace EuropeBJJ.Models
{
    public class SeminarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Image { get; set; } 

        public string Location { get; set; } = null!;

        public string Teacher { get; set; } = null!;

    }
}
