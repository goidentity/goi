using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trBusinessProfile", Schema = "Core")]
    public class BusinessProfile : Entity
    {
        [Key]
        public int BusinessProfileId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public short YearOfEstablishment { get; set; }
        public int ComponySize { get; set; }
        public string Role { get; set; }
    }
}
