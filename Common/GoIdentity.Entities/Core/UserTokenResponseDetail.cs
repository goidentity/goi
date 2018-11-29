using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserTokenResponseDetail", Schema = "Scores")]
    public class UserTokenResponseDetail : Entity
    {
        [Key]
        public int UserTokenResponseDetailId { get; set; }
        public int UserTokenResponseId { get; set; }

        public DateTime ProcessedDate { get; set; }
        public string TokenLink { get; set; }
        public int? Count { get; set; }
        public string Description { get; set; }

        public string AnalyzeEntities { get; set; }
        public string AnalyzeEntitiesTokens { get; set; }
        public double? AnalyzeEntitiesScore { get; set; }
        public double? AnalyzeEntitiesMagnitude { get; set; }

        public string AnalyzeEntitySentiment { get; set; }
        public string AnalyzeEntitySentimentTokens { get; set; }
        public double? AnalyzeEntitySentimentScore { get; set; }
        public double? AnalyzeEntitySentimentMagnitude { get; set; }

        public string AnalyzeSyntax { get; set; }
        public string AnalyzeSyntaxTokens { get; set; }

        public string ClassifyText { get; set; }
        public string ClassifyTextTokens { get; set; }

    }
}
