using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSEventApp.Web.Models;
using TSEventApp.Infrastructure.Repository;
using TSEventApp.Core.Entities;
using TSEventApp.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TSEventApp.Web.Services;

namespace TSWebApp.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenuePageService _venuePageService;

        public VenueController(IVenuePageService venuePageService)
        {
            this._venuePageService = venuePageService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ViewVenueDetails(int? id)
        {
            var details = await _venuePageService.ViewDetails(id.Value);
            var ans = await _venuePageService.GetAllEventsByVenue(id.Value);
            details.Events = ans;
            if (details == null)
            {
                return RedirectToAction("GetVenues");
            }
            return View(details);
        }
        [Authorize]
        public ViewResult CreateVenue(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateVenue(VenueViewModel venueViewModel)
        {
            //_eventRepository.CreateEvent(bookEventModel);
            if (ModelState.IsValid)
            {
                var result = await _venuePageService.createVenue(venueViewModel);
                if (result > 0)
                {
                    return RedirectToAction(nameof(CreateVenue), new { isSuccess = true, bookId = result });
                }
            }

            return View();
        }
        [Authorize]
        public async Task<IActionResult> UpdateVenue(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GetVenues");
            }
            var ans = await _venuePageService.ViewDetails(id.Value); ;

            if (ans == null)
            {
                return RedirectToAction("GetVenues");
            }

            return View(ans);
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateVenue(VenueViewModel venueViewModel)
        {
            var _id = _venuePageService.UpdateVenue(venueViewModel);

            if (_id > 0)
            {
                return RedirectToAction("ListVenues");
            }
            return View();
        }

        public async Task<IActionResult> GetAllEventsByVenue(int _id)
        {
            var ans = await _venuePageService.GetAllEventsByVenue(_id);
            if (ans == null)
            {
                return RedirectToAction("ViewVenueDetails", new { id = _id });
            }
            return View(ans);
        }
        public async Task<IActionResult> ListVenues()
        {
            var ans = await _venuePageService.GetVenues();
            return View(ans);
        }
    }
}
