using System;
using System.Collections.Generic;
using System.Text;

namespace GoIdentity.Entities.Scores
{
    public class GoogleData
    {
        public string Link { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

        public string AnalyzeEntities { get; set; }
        public string AnalyzeEntitiesTokens { get; set; }
        public double AnalyzeEntitiesScore { get; set; }
        public double AnalyzeEntitiesMagnitude { get; set; }

        public string AnalyzeEntitySentiment { get; set; }
        public string AnalyzeEntitySentimentTokens { get; set; }
        public double AnalyzeEntitySentimentScore { get; set; }
        public double AnalyzeEntitySentimentMagnitude { get; set; }

        public string AnalyzeSyntax { get; set; }
        public string AnalyzeSyntaxTokens { get; set; }        

        public string ClassifyText { get; set; }
        public string ClassifyTextTokens { get; set; }        


        public override string ToString()
        {
            return this.Link;
        }
    }
}
