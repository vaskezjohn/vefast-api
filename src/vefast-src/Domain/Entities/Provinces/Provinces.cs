using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Provinces
{
    public class Provinces : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }
    }
}
