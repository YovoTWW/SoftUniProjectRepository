namespace EuropeBJJ.Models.Event
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Image { get; set; }

        public string? Organiser { get; set; }

        public string? Location { get; set; }

        public decimal MembersPrice { get; set; }

        public decimal NonMembersPrice { get; set; }

        public string? Description { get; set; }

        public string? Teacher { get; set; }

        public string? Link { get; set; }

        public bool IsPinned { get; set; }

        public string? Creator { get; set; }

        public string EventType { get; set; } = null!;

        public bool UserProfileExists { get; set; }

        public bool IsAttending { get; set; }
    }
}
