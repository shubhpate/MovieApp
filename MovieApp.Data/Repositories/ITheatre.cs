using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface ITheatre
    {
        string Register(TheatreModel theatreModel);
        string DeleteTheatre(int id);
        object SelectTheatres();
        string Update(TheatreModel u);
        TheatreModel GetTheatreById(int id);
    }
}
