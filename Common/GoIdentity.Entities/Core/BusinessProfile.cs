using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trBusinessProfile", Schema = "Core")]
    public class BusinessProfile : Entity
    {
        [Key]
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Role { get; set; }
    }
}
