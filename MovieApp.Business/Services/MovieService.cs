using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class MovieService
    {
        IMovie _movie;

        public MovieService(IMovie movie)
        {
            _movie = movie;
        }

        public string Register(MovieModel movieModel)
        {
            return _movie.Register(movieModel);
        }

        public object GetMovies()
        {
            return _movie.GetMovies();
        }

        public string Delete(int id)
        {
            return _movie.Delete(id);
        }

        public string Update(MovieModel movieModel)
        {
            return _movie.Update(movieModel);
        }
    }
}
