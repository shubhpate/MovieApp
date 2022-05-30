using MovieApp.Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using MovieApp.Data.DataConnection;
using MovieApp.Data.Repositories;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class Movie : IMovie
    {
        MovieDBContext _movieDBContext;

        public Movie(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string Delete(int id)
        {
            string mesg = "";
            var toDelete = _movieDBContext.movieModel.Find(id);
            if(toDelete!= null)
            {
                _movieDBContext.movieModel.Remove(toDelete);
                _movieDBContext.SaveChanges();
                mesg = "Deleted Successfully";
            }
            else
            {
                mesg = "Id not found";
            }
            return mesg;
        }

        public string Register(MovieModel movieModel)
        {
            string mesg = "";
            _movieDBContext.movieModel.Add(movieModel);
            _movieDBContext.SaveChanges();
            mesg = "New Movie Registered Successfully";
            return mesg;
        }

        public object GetMovies()
        {
            List<MovieModel> movieList = _movieDBContext.movieModel.ToList();
            return movieList;
        }

        public string Update(MovieModel movieModel)
        {
            throw new NotImplementedException();
        }
    }
}
