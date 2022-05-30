using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IMovie
    {
        string Register(MovieModel userModel);
        string Delete(int id);
        object GetMovies();
        string Update(MovieModel u);
    }
}
