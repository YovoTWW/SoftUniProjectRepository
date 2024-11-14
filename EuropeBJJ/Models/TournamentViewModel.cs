﻿namespace EuropeBJJ.Models
{
    public class TournamentViewModel
    {
        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Image {  get; set; } = null!;

        public string? Link { get; set; }
    }
}