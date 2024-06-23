using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TSEventApp.Core.Entities;
using TSEventApp.Core.IRepository;
using TSEventApp.Infrastructure.Repository.Base;
using TSWebApp.Infrastructure.Data;

namespace TSEventApp.Infrastructure.Repository
{
    public class VenueRepository : Repository<Venue>, IVenueRepository
    {
        private readonly EventContext _eventContext;
        public VenueRepository(EventContext venueContext) : base(venueContext)
        {
            this._eventContext = venueContext;
        }

        public async Task<int> createVenue(Venue _venue)
        {
            var newVenue = new Venue()
            {
                Name = _venue.Name,
                Description = _venue.Description,
                Location = _venue.Location,
                ManagerName = _venue.ManagerName,
                ManagerPhoneNumber = _venue.ManagerPhoneNumber,
                MaxCapacity = _venue.MaxCapacity,
            };
            await _eventContext.Venues.AddAsync(newVenue);
            await _eventContext.SaveChangesAsync();
            return newVenue.Id;
        }

        public async Task<IList<Event>> GetAllEventsByVenue(int venueId)
        {
            var result = await(from e in _eventContext.Venues
                               join c in _eventContext.Events on
                               e.Id equals c.VenueId
                               where c.VenueId == venueId
                               orderby c.Date
                               select new Event()
                               {
                                   VenueId = venueId,
                                   Date = c.Date

                               }).ToListAsync();
            return result;
        }

        public async Task<IList<Venue>> GetVenues()
        {
           return await _eventContext.Venues.OrderBy(x=>x.MaxCapacity).ToListAsync();
        }

        public int UpdateVenue(Venue _venue)
        {
            _eventContext.Venues.Update(_venue);
            _eventContext.SaveChanges();
            return _venue.Id;
        }

        public async Task<Venue> ViewDetails(int venueId)
        {
           return await _eventContext.Venues.FindAsync(venueId);
        }
    }
}

