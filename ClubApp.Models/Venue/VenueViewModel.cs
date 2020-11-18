using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models.Venue
{
    public class VenueViewModel
    {
        public Guid VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenuePhone { get; set; }
        public string VenueLocation { get; set; }
        public string VenueLongitude { get; set; }
        public string VenueLatitude { get; set; }
    }
}
