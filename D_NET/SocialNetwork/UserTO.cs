using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork
{
    public class UserTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public UserTO()
        {

        }

        public UserTO( int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}