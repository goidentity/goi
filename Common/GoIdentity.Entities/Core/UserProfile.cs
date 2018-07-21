using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserProfile", Schema = "Core")]
    public class UserProfile : Entity
    {
        [Key]
        public int UserProfileId { get; set; }

        public string DOB { get; set; }
        public string Area { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }

        public string RolesPlayed { get; set; }
        public string RolesInterested { get; set; }

        public int UserId { get; set; }

        //public ICollection<BusinessProfile> BusinessProfile {get; set; }        
    }
}
