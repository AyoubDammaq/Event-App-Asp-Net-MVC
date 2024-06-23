using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSEventApp.Application.Interfaces;
using TSEventApp.Application.Models;
using TSEventApp.Application.Services;
using TSEventApp.Core.Entities;
using TSEventApp.Web.Interfaces;
using TSEventApp.Web.Models;

namespace TSEventApp.Web.Services
{
    public class VenueRepositorye : IVenuePageService
    {
        private readonly IVenueService _venueService;
        private readonly IMapper _mapper;
        private readonly ILogger<VenueRepositorye> _logger;

        public VenueRepositorye(IVenueService venueService, IMapper mapper, ILogger<VenueRepositorye> logger)
        {
            this._venueService = venueService ?? throw new ArgumentNullException(nameof(venueService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> createVenue(VenueViewModel venueViewModel)
        {
            var mapped = _mapper.Map<VenueModel>(venueViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");
            return await _venueService.createVenue(mapped);
        }

        public async Task<IList<EventViewModel>> GetAllEventsByVenue(int venueId)
        {
            var eventList = await _venueService.GetAllEventsByVenue(venueId);
            var mapped = _mapper.Map<IList<EventViewModel>>(eventList);
            return mapped;
        }

        public async Task<IList<VenueViewModel>> GetVenues()
        {
            var list = await _venueService.GetVenues();
            var mapped = _mapper.Map<List<VenueViewModel>>(list);
            return mapped;
        }

        public int UpdateVenue(VenueViewModel venueViewModel)
        {

            var mapped = _mapper.Map<VenueModel>(venueViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            return _venueService.UpdateVenue(mapped);
        }

        public async Task<VenueViewModel> ViewDetails(int venueId)
        {
            var _event = await _venueService.ViewDetails(venueId);
            var mapped = _mapper.Map<VenueViewModel>(_event);
            return mapped;
        }
    }
}
