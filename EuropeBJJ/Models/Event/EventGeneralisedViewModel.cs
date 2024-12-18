﻿using static EuropeBJJ.Constants.CountriesList;

namespace EuropeBJJ.Models.Event
{
    public class EventGeneralisedViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Image { get; set; }

        public string EventType { get; set; } = null!;
    }
}
