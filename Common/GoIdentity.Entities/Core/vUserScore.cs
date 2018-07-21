using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "vUserScore", Schema = "Core")]
    public class vUserScore
    {
        [Key]
        public int IndustryId { get; set; }
        public string Industry { get; set; }
        public decimal IndustryWeightage { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public decimal Score { get; set; }
    }
}
