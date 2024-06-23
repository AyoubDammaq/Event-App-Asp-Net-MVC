using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSEventApp.Application.Interfaces;
using TSEventApp.Application.Mapper;
using TSEventApp.Application.Models;
using TSEventApp.Core.Entities;
using TSEventApp.Core.IRepository;

namespace TSEventApp.Application.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _venueRepository;
        public VenueService(IVenueRepository venueRepository)
        {
            this._venueRepository = venueRepository;
        }

        public async Task<int> createVenue(VenueModel venueViewModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Venue>(venueViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");
            return await _venueRepository.createVenue(mapped);

        }

        public async Task<IList<EventModel>> GetAllEventsByVenue(int venueId)
        {
            var eventList = await _venueRepository.GetAllEventsByVenue(venueId);
            var mapped = ObjectMapper.Mapper.Map<IList<EventModel>>(eventList);
            return mapped;
        }

        public async Task<IList<VenueModel>> GetVenues()
        {
            var veneusList = await _venueRepository.GetVenues();
            var mapped = ObjectMapper.Mapper.Map<IList<VenueModel>>(veneusList);
            return mapped;
        }

        public int UpdateVenue(VenueModel venueViewModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Venue>(venueViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            return _venueRepository.UpdateVenue(mapped);
        }

        public async Task<VenueModel> ViewDetails(int venueId)
        {
            var _venue = await _venueRepository.ViewDetails(venueId);
            var mapped = ObjectMapper.Mapper.Map<VenueModel>(_venue);
            return mapped;
        }
    }
}
