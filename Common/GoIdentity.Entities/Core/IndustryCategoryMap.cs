using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Entities.Core
{
    public class IndustryCategoryMap
    {
        [Key]
        public int Id { get; set; }
        public int IndustryId { get; set; }
        public int CategoryId { get; set; }
        public decimal Score { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
