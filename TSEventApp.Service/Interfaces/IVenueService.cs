using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSEventApp.Application.Models;

namespace TSEventApp.Application.Interfaces
{
    public interface IVenueService
    {
        Task<IList<VenueModel>> GetVenues();
        Task<VenueModel> ViewDetails(int venueId);
        Task<int> createVenue(VenueModel venueViewModel);
        int UpdateVenue(VenueModel venueViewModel);
        Task<IList<EventModel>> GetAllEventsByVenue(int venueId);

    }
}
