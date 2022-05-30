using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //<=Model Validation
using System.ComponentModel.DataAnnotations.Schema; //sql const

namespace MovieApp.Entity
{
    public class UserModel
    {   
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Contact { get; set; }

        /*public UserModel(int userId, string firstName, string lastName, string email, string password, int contact)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Contact = contact;
        }*/

    }
}
