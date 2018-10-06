using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoIdentity.Web.App.ServiceEntites
{
    public class UserProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DisplayName { get; set; }
        public string DOB { get; set; }
        public int MobileNumber { get; set; }
        public int AlternateNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string Company { get; set; }
        public string RolesPlayed { get; set; }
        public string RolesInterested { get; set; }
        public int UserId { get; set; }
    }
}
