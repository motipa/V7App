using ClubApp.Models.Venue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Venue
{
    public interface IVenueModel
    {
        Task<VenueViewModel> AddVenueDetails(VenueDetailsModel venue);
    }
}
