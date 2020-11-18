using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Models.Venue;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Venue
{
    public class VenueModel : LogicBase, IVenueModel
    {
        public VenueModel(DatabaseContext db, IMapper mapper, IConfiguration config) : base(db, mapper, config)
        {

        }
        public async Task<VenueViewModel> AddVenueDetails(VenueDetailsModel venue)
        {
            if(venue.VenueLocation!=null)
            {
                VenueDetails saveVenue = _mapper.Map<VenueDetails>(venue);
                await _db.VenueDetails.AddAsync(saveVenue);
                await _db.SaveChangesAsync();
                return new VenueViewModel { VenueLocation = saveVenue.VenueLocation };
            }
            else
            {
                throw new ConsoleCommonException("AddVenue Failed");
            }
        }
    }
}
