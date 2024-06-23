using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSEventApp.Web.Models;

namespace TSEventApp.Web.Interfaces
{
    public interface IVenuePageService
    {
        Task<IList<VenueViewModel>> GetVenues();
        Task<VenueViewModel> ViewDetails(int venueId);
        Task<int> createVenue(VenueViewModel venueViewModel);
        int UpdateVenue(VenueViewModel venueViewModel);
        Task<IList<EventViewModel>> GetAllEventsByVenue(int venueId);
    }
}
