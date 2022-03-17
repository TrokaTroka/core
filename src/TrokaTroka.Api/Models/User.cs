using System.Collections.Generic;

namespace TrokaTroka.Api.Models
{
    public class User : EntityBase
    {
        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string ImageName { get; private set; }
        public string ImagePath { get; private set; }


        public List<Rating> Ratings { get; set; }
        public List<Book> Books{ get; set; }

        public User()
        { }
    }
}