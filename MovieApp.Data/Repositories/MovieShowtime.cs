using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class MovieShowtime : IMovieShowtime
    {
        MovieDBContext _movieDBContext;
        public MovieShowtime(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public string DeleteMovieShowtime(int id)
        {
            string mesg = "";
            var toDelete = _movieDBContext.movieShowtimeModel.Find(id);
            if (toDelete == null)
            {
                return mesg = "Id not found";
            }
            _movieDBContext.movieShowtimeModel.Remove(toDelete);
            _movieDBContext.SaveChanges();
            mesg = "Deleted Successfully";
            return mesg;
        }

        public List<MovieShowtimeModel> GetAllMovieShowtime()
        {
            List<MovieShowtimeModel> list = _movieDBContext.movieShowtimeModel.ToList();
            return list;
        }

        public MovieShowtimeModel GetMovieShowimeById(int id)
        {
            return _movieDBContext.movieShowtimeModel.Find(id);
        }

        public List<MovieShowtimeModel> GetShowtimeForSpecificMovieAndTheatre(int movieId)
        {
            var specificShowtime= _movieDBContext.movieShowtimeModel.Where(m => m.MovieId == movieId).ToList();
            return specificShowtime;
        }

        public string Register(MovieShowtimeModel movieShowTimeModel)
        {
            string mesg = "";
            _movieDBContext.movieShowtimeModel.Add(movieShowTimeModel);
            _movieDBContext.SaveChanges();
            mesg = "Registered Successfully";
            return mesg;
        }

        public string UpdateMovieShowtime(MovieShowtimeModel movieShowTimeModel)
        {
            string mesg = "";
            _movieDBContext.Entry(movieShowTimeModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _movieDBContext.SaveChanges();
            mesg = "Updated successfully";
            return mesg;
        }
    }
}
