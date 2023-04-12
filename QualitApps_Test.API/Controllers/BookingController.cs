using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualitApps_Test.Models.Models;
using QualitApps_Test.Services.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualitApps_Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingService;
        public BookingController(IBookingRepository bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("GetAllBookings")]
        public ActionResult<ICollection<Booking>> GetBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("GetBooking/{id}")]
        public IActionResult GetBooking(Guid bookingId)
        {
            var booking = _bookingService.GetBookingById(bookingId);

            if (booking is null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost("CreateBooking")]
        //[Authorize(Policy = "AdminOnly")]
        public ActionResult<Booking> CreateBooking(Booking booking)
        {
            var existing = _bookingService.GetBookingById(booking.Id);
            if (existing != null)
            {
                return ResultJsonGenerator.Generate(Models.Enums.RequestStatus.Failed, "Duplicate entry", 500);
            }
            var newBooking = _bookingService.CreateBooking(booking);

            return Ok(newBooking);
        }

        [HttpPut("UpdatBooking/{id}")]
        public ActionResult<Booking> UpdateBooking(Booking booking)
        {
            var updatedBooking = _bookingService.UpdateBooking(booking);

            return CreatedAtAction("GetBooking", new { id = updatedBooking.Id }, updatedBooking);
        }

        [HttpDelete("DeleteBooking/{id}")]
        public ActionResult<JsonResult> DeleteUser(Guid id)
        {
            var result = _bookingService.RemoveBooking(id);

            if (result == 1)
            {
                return ResultJsonGenerator.Generate(Models.Enums.RequestStatus.Success, "Booking with ID {id} has been deleted.", 200);
            }
            else
            {
                return ResultJsonGenerator.Generate(Models.Enums.RequestStatus.Failed, "Failed to delete booking with ID {id}.", 500);

            }
        }

    }
}
