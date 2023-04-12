using QualitApps_Test.DataAccess;
using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Services.Bookings
{
    public class BookingService : IBookingRepository
    {
        private readonly AppDbContext _context;
        public BookingService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public Booking CreateBooking(Booking booking)
        {
            var createdBooking = _context.Bookings.Add(booking);
            _context.SaveChanges();
            return createdBooking.Entity;
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(Guid bookingId)
        {
            if (bookingId == Guid.Empty)
            {
                return null;
            }
            var booking = _context.Bookings.Find(bookingId);
            return booking;
        }

        public int RemoveBooking(Guid bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);

            if (booking == null)
            {
                return 0;
            }
            _context.Bookings.Remove(booking);
            return _context.SaveChanges();
        }

        public Booking UpdateBooking(Booking booking)
        {
            var appoinment = _context.Bookings.Find(booking.Id);
            var updatedBooking = _context.Bookings.Update(appoinment);
            _context.SaveChanges();
            return updatedBooking.Entity;
        }
    }
}
