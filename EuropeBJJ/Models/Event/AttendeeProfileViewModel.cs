namespace EuropeBJJ.Models.Event
{
    public class AttendeeProfileViewModel
    {
        public int ProfileId { get; set; }
        public string FullName { get; set; } = null!;

        public string? Picture { get; set; }
    }
}
