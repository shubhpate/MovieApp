using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class Booking : IBooking
    {
        MovieDBContext _movieDBContext;
        public Booking(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string BookingRegister(BookingModel bookingModel)
        {
            string mesg = "";
            _movieDBContext.bookingModel.Add(bookingModel);
            _movieDBContext.SaveChanges();
            mesg = "Booking done Successfully";
            return mesg;
        }

        public string DeleteBookingById(int BookingId)
        {
            string mesg = "";
            var toDelete = _movieDBContext.bookingModel.Find(BookingId);
            if (toDelete == null)
            {
                return mesg = "BookingID not found";
            }
            _movieDBContext.bookingModel.Remove(toDelete);
            _movieDBContext.SaveChanges();
            mesg = "Booking Deleted Successfully";
            return mesg;
        }

        public List<BookingModel> GetAllBookings()
        {
            return _movieDBContext.bookingModel.ToList();
        }

        public BookingModel GetBookingDetailById(int BookingId)
        {
            var result = _movieDBContext.bookingModel.Find(BookingId);
            if (result == null)
            {
                Console.WriteLine("ID not found");
            }
            return result;
        }

        public string UpdateBooking(BookingModel bookingModel)
        {
            string mesg = "";
            _movieDBContext.Update(bookingModel);
            _movieDBContext.SaveChanges();
            mesg = "Booking Details Updated Successfully";
            return mesg;
        }
    }
}
