using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class User : IUser
    {
        MovieDBContext _movieDBContext;

        public User(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string Delete(int id)
        {
            string mesg = "";
            var toDelete=_movieDBContext.userModel.Find(id);
            if (toDelete == null)
            {
                mesg = "Id not found in database";
            }
            _movieDBContext.userModel.Remove(toDelete);
            _movieDBContext.SaveChanges();
            mesg = "Deleted Successfully";
            return mesg;
        }

        public UserModel GetUserById(int id)
        {
            var result = _movieDBContext.userModel.Find(id);
            if (result == null)
            {
                Console.WriteLine("Id not present");
            }
            return result;
        }

        public UserModel Login(UserModel user)
        {
            UserModel userModel= null;
            var signup = _movieDBContext.userModel.Where(u => u.Email == user.Email && u.Password == user.Password).ToList();
            if (signup.Count > 0)
            {
                userModel = signup[0];
            }
            return userModel;
        }

        public string Register(UserModel userModel) 
        {
            string msg = "";
            _movieDBContext.userModel.Add(userModel);
            _movieDBContext.SaveChanges(); //insert into UserModel table
            msg = "Inserted Successfully";
            return msg;
        }

        public object SelectUsers()
        {
            //select *
            List<UserModel> userList= _movieDBContext.userModel.ToList();
            return userList;
        }

        public string Update(UserModel userModel)
        {
            string mesg = "";
            _movieDBContext.Update(userModel);
            _movieDBContext.SaveChanges();
            mesg = "Updated Details Successfully";
            return mesg;
        }
    }
}
