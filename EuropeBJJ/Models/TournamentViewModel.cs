namespace EuropeBJJ.Models
{
    public class TournamentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Image {  get; set; } 

        public string? Link { get; set; }

        public bool IsPinned { get; set; }

        public string? Creator {  get; set; }
    }
}
