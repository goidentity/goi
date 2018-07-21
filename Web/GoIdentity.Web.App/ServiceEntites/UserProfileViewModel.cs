using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoIdentity.Web.App.ServiceEntites
{
    public class UserProfileViewModel
    {
        public string DOB { get; set; }
        public string Area { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string RolesPlayed { get; set; }
        public string RolesInterested { get; set; }
        public int UserId { get; set; }
    }
}
