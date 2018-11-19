using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserEducation", Schema = "Core")]
    public class UserEducation : Entity
    {
        [Key]
        public int UserEducationId { get; set; }
        public int UserId { get; set; }

        public string DegreeType { get; set; }
        public string Title { get; set; }
        public string UniversityOrBoard { get; set; }
        public string InstitutionOrBoard { get; set; }
        public string YearOfPass { get; set; }
        public string Specialization { get; set; }
    }
}
