using GoIdentity.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Scores
{
    [Table(name: "trUserInfluencerAuth", Schema = "Scores")]
    public class UserInfluencerAuth : Entity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public ConnectorType InfluencerId { get; set; }
        public string UserName { get; set; }
        public string Secret { get; set; }
        public string Secret1 { get; set; }
        public string Secret2 { get; set; }
        public string Secret3 { get; set; }

        public string Other1 { get; set; }
        public string Other2 { get; set; }

        public DateTime? LastRefreshedDate { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}
