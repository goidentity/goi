using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUserTokenResponse", Schema ="Scores")]
    public class UserTokenResponse : Entity
    {
        [Key]
        public int UserTokenResponseId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
