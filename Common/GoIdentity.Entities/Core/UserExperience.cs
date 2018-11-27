using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserExperience", Schema = "Core")]
    public class UserExperience : Entity
    {
        [Key]
        public int UserExperienceId { get; set; }
        public int UserId { get; set; }

        public string OrganizationName { get; set; }
        public string Designation { get; set; }
        public string Roles { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string ReasonForChange { get; set; }

        public string PersonalURL { get; set; }
        public string PersonalUrlKeyWords { get; set; }

        public string ListingURL { get; set; }
        public string ListingUrlKeyWords { get; set; }
    }
}
