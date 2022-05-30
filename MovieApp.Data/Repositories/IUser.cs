using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IUser
    {
        string Register(UserModel userModel);
        UserModel Login(UserModel u);
        string Delete(int id);
        object SelectUsers();
        string Update(UserModel u);
        UserModel GetUserById(int id);
    }
}
