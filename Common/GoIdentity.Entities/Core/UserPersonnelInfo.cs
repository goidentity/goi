using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserPersonnelInfo", Schema = "Core")]
    public class UserPersonnelInfo : Entity
    {
        [Key]
        public int UserPersonnelInfoId { get; set; }
        public int UserId { get; set; }

        public DateTime? DoB { get; set; }
        public string Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CityOfLiving { get; set; }

        public string CityOfWork { get; set; }
        public string MaritalStatus { get; set; }
        public string BirthOfOrigin { get; set; }
        public string Nationality { get; set; }
        public string Citizenship { get; set; }
        public string PRStatus { get; set; }

        public string PrimaryIndustryOfWork { get; set; }
        public string SecondaryIndustryOfWork { get; set; }

        public string PrimaryIndustryOfBusiness { get; set; }
        public string SecondaryIndustryOfBusiness { get; set; }

        public string FutureRole { get; set; }
        public string FutureIndustryOfWork { get; set; }
        public string FutureIndustryOfBusiness { get; set; }
    }
}
