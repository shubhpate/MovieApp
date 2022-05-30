using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iUser;

        public UserService(IUser iUser)
        {
            _iUser = iUser;
        }

        public string Register(UserModel userModel)
        {
            return _iUser.Register(userModel);
        }

        public object SelectUsers()
        {
            return _iUser.SelectUsers();
        }

        public string Delete(int id)
        {
            return _iUser.Delete(id);
        }

        public string Update(UserModel userModel)
        {
            return _iUser.Update(userModel);
        }

        public UserModel GetById(int id)
        {
            return _iUser.GetUserById(id);
        }
    }
}
