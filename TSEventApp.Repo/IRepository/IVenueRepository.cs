using System.Collections.Generic;
using System.Threading.Tasks;
using TSEventApp.Core.Entities;
using TSEventApp.Core.IRepository.Base;

namespace TSEventApp.Core.IRepository
{
    public interface IVenueRepository : IRepository<Venue>
    {
        Task<IList<Venue>> GetVenues();
        Task<Venue> ViewDetails(int venueId);
        Task<int> createVenue(Venue venueViewModel);
        int UpdateVenue(Venue venueViewModel);
        Task<IList<Event>> GetAllEventsByVenue(int venueId);
    }
}
