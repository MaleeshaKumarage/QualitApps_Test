using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Services.Bookings
{
    public interface IBookingRepository
    {
        public List<Booking> GetAllBookings();
        public Booking GetBookingById(Guid bookingId);
        public Booking CreateBooking(Booking booking);
        public Booking UpdateBooking(Booking booking);
        public int RemoveBooking(Guid bookingId);
    }
}
