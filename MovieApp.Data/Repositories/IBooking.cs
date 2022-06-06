using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IBooking
    {
        public string BookingRegister(BookingModel bookingModel);
        public List<BookingModel> GetAllBookings();
        public string DeleteBookingById(int BookingId);
        public string UpdateBooking(BookingModel bookingModel);
        public BookingModel GetBookingDetailById(int BookingId);
    }
}
