using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Entities.Core
{
    public class UserScore
    {
        [Key]
        public int Id { get; set; }
        public int ICMapId { get; set; }
        public decimal Score { get; set; }
    }
}
