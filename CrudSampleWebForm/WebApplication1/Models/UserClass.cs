using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserClass : BaseClass
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string AccountType { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}