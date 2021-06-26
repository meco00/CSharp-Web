using MyWebServer.Controllers;
using MyWebServer.Results;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Services;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public ActionResult All()
        {
            var trips = this.data.Trips
                .Select(t => new TripListingViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = t.Seats - t.UserTrips.Count()
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public ActionResult Add() => this.View();

        [HttpPost]
        [Authorize]
        public ActionResult Add(TripAddFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            var isDateValid = DateTime
             .TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var departureTime);

            if (!isDateValid)
            {
                modelErrors.Add($"DepartureTime '{model.DepartureTime}' is not valid . It must be in format 'dd.MM.yyyy HH:mm'.");
            }

            if (modelErrors.Any())
            {
                return Redirect("/Trips/Add");

                //return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Seats = model.Seats,
                DepartureTime = departureTime,
                ImagePath = model.ImagePath,
                Description = model.Description

            };

            data.Trips.Add(trip);

            data.SaveChanges();

            return Redirect("/Trips/All");

        }

        [Authorize]
        public ActionResult Details(string tripId)
        {
            var trip = this.data.Trips.FirstOrDefault(x => x.Id == tripId);

            if (trip == null)
            {
                return NotFound();
            }

            var tripDto = new TripDetailsViewModel()
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                Seats = trip.Seats,
                Image = trip.ImagePath,
                DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = trip.Description


            };

            return this.View(tripDto);

        }

        [Authorize]
        public ActionResult AddUserToTrip(string tripId)
        {
            var trip = this.data.Trips.FirstOrDefault(x => x.Id == tripId);

            if (trip == null || trip.Seats == trip.UserTrips.Count() || trip.UserTrips.Any(x => x.UserId == this.User.Id) )
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id
            };

            trip.UserTrips.Add(userTrip);

            

            data.SaveChanges();

            return Redirect("/Trips/All");
        }



    }
}
