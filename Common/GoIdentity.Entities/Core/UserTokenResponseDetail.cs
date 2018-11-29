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
        public string ResponseDataFileName { get; set; }
        public string NlpEntitiesFileName { get; set; }
        public string NlpEntities { get; set; }
        public string NlpSentimentFileName { get; set; }
        public string NlpSentiment { get; set; }
        public string NlpSyntaxFileName { get; set; }
        public string NlpSyntax { get; set; }
        public string NlpClassifyFileName { get; set; }
        public string NlpClassify { get; set; }
    }
}
