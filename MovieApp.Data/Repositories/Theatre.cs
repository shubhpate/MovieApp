using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class Theatre : ITheatre
    {
        MovieDBContext _movieDBContext;

        public Theatre(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string DeleteTheatre(int id)
        {
            string mesg = "";
            var toDelete = _movieDBContext.theatreModel.Find(id);
            if (toDelete == null)
            {
                mesg = "Id not found in database";
            }
            _movieDBContext.theatreModel.Remove(toDelete);
            _movieDBContext.SaveChanges();
            mesg = "Deleted Successfully";
            return mesg;
        }

        public TheatreModel GetTheatreById(int id)
        {
            var result = _movieDBContext.theatreModel.Find(id);
            if (result == null)
            {
                Console.WriteLine("Id not present");
            }
            return result;
        }

        public string Register(TheatreModel theatreModel)
        {
            string msg = "";
            _movieDBContext.theatreModel.Add(theatreModel);
            _movieDBContext.SaveChanges(); //insert into UserModel table
            msg = "Inserted Successfully";
            return msg;
        }

        public object SelectTheatres()
        {
            List<TheatreModel> theatreList = _movieDBContext.theatreModel.ToList();
            return theatreList;
        }

        public string Update(TheatreModel theatreModel)
        {
            string mesg = "";
            _movieDBContext.Update(theatreModel);
            _movieDBContext.SaveChanges();
            mesg = "Updated Details Successfully";
            return mesg;
        }
    }
}
