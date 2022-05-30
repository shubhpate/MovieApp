using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Entity
{
    public class TheatreModel
    {
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
