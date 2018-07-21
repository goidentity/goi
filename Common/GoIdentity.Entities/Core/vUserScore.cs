using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    public class vUserScore
    {
        public int IndustryId { get; set; }
        public string Industry { get; set; }
        public decimal IndustryWeightage { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public decimal Score { get; set; }
        public decimal LastScore { get; set; }
        public string ScoreType { get; set; }
    }
}
