using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserScore", Schema = "Core")]
    public class UserScore
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public string ScoreType { get; set; }

        public int? ICMapId { get; set; }
        public decimal Score { get; set; }
        public decimal ChangeScore { get; set; }

        public DateTime CreatedOn { get; set; }
        //public Guid GroupId { get; set; }
    }
}
