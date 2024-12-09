namespace EuropeBJJ.Models.Profile
{
    public class ProfileViewModel
    {
        public int ProfileId { get; set; }
        public string FullName { get; set; } = null!;

        public string? Picture { get; set; }
    }
}
