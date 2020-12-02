using AutoMapper;
using ClubApp.Common.Exceptions;
using ClubApp.Data;
using ClubApp.Data.Entities;
using ClubApp.Logic.Common;
using ClubApp.Models.Common;
using ClubApp.Models.Venue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<VenueViewModel>> GetVenue()
        {
            var venue = _db.VenueDetails.ToList();
            return _mapper.Map<List<VenueViewModel>>(venue);           
        }

        //public async Task<IEnumerable<LookupModel<Guid>>> GetVenueAll()
        //{
        //    var venue = _db.VenueDetails.AsNoTracking();
        //    return _mapper.Map<IEnumerable<LookupModel<Guid>>>(await venue.ToArrayAsync());
        //} 
        public async Task<List<PickModel>> GetVenueAll()
        {
            var venue = _db.VenueDetails.ToList();
            return _mapper.Map<List<PickModel>>(venue);
        }
    }
}
