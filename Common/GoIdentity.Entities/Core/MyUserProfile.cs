using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trMyUserProfile", Schema = "Core")]
    public class MyUserProfile : Entity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }


        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender{ get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }


        public DateTime DOB { get; set; }

        public string PlaceOfBirth { get; set; }

        public string CurrentCity { get; set; }

        public string HomeTown { get; set; }
        public string MartialStatus { get; set; }


        public string AadharCard { get; set; }

        //public ICollection<BusinessProfile> BusinessProfile {get; set; } 
    }
}
