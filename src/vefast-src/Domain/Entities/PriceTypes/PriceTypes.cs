using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.PriceTypes
{
    public class PriceTypes : BaseEntity
    {
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
        public bool Default { get;set;}
    }
}
