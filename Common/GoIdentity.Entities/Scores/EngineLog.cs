using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Scores
{
    [Table(name: "trEngineLog", Schema = "Scores")]
    public class EngineLog : Entity
    {
        [Key]
        public int Id { get; set; }
        public int UserInfluencerAuthId { get; set; }
        public int UserId { get; set; }
        public ConnectorType InfluencerId { get; set; }

        public string PullStatus { get; set; }
        public string Remarks { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
