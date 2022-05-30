using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data.DataConnection
{
    public class MovieDBContext:DbContext //dbcontext: import ms.entityframework
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options): base(options)
        {

        }
        public DbSet<UserModel> userModel { get; set; }  //DbSet is given to create table

        public DbSet<MovieModel> movieModel { get; set; }

        public DbSet<TheatreModel> theatreModel { get; set; }


    }
}
