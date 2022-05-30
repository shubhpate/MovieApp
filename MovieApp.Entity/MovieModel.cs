using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //<=Model Validation
using System.ComponentModel.DataAnnotations.Schema; //sql const

namespace MovieApp.Entity
{
    public class MovieModel
    {
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }

       /* public MovieModel(int id, string name, int rating, string genre)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Genre = genre;
        }*/
    }
}
