using System;

namespace GoIdentity.Entities.Scores
{
    public class EngineLogResponse
    {
        public int UserId { get; set; }
        public short InfluencerId { get; set; }
        public string PullStatus { get; set; }
        public string Response { get; set; }
        public string Remarks { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
