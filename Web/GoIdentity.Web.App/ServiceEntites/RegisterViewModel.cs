using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoIdentity.Web.App.ServiceEntites
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
    }
}
