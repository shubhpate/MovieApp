using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class TheatreService
    {
        ITheatre _itheatre;

        public TheatreService(ITheatre theatre)
        {
            _itheatre = theatre;
        }

        public string Register(TheatreModel theatreModel)
        {
            return _itheatre.Register(theatreModel);
        }

        public object SelectTheatres()
        {
            return _itheatre.SelectTheatres();
        }

        public string DeleteTheatre(int id)
        {
            return _itheatre.DeleteTheatre(id);
        }

        public string UpdateTheatre(TheatreModel theatreModel)
        {
            return _itheatre.Update(theatreModel);
        }

        public TheatreModel GetById(int id)
        {
            return _itheatre.GetTheatreById(id);
        }
    }
}
