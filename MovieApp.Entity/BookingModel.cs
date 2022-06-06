using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Entity
{
    public class BookingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [ForeignKey("userModel")]
        public int UserId { get; set; }
        public UserModel userModel { get; set; }

        [ForeignKey("movieModel")]
        public int MovieId { get; set; }
        public MovieModel movieModel { get; set; }

        [ForeignKey("theatreModel")]
        public int TheatreId { get; set; }
        public TheatreModel theatreModel { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Seats { get; set; }

    }
}
