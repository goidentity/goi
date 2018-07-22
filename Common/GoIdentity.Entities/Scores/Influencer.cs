using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Scores
{
    [Table(name: "trInfluencer", Schema = "Scores")]
    public class Influencer : Entity
    {
        [Key]
        public InfluencerType InfluencerId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string ApiKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }

        public bool IsActive { get; set; }
    }

    public enum InfluencerType : short
    {

    }
}
