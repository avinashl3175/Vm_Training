using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ClientsList
    {
        public ClientsList(string firstname, string lastname, DateTime dob, string email)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Dob = dob;
            this.Email = email;
        }

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime Dob { set; get; }

    }
}