using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class BookingService
    {
        IBooking _iBooking;

        public BookingService(IBooking booking)
        {
            _iBooking = booking;
        }
        public string BookingRegister(BookingModel bookingModel)
        {
            return _iBooking.BookingRegister(bookingModel);
        }

        public List<BookingModel> GetAllBookings()
        {
            return _iBooking.GetAllBookings();
        }
    }
}
