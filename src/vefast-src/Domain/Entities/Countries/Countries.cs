using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Countries
{
    public class Countries : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }
    }
}
