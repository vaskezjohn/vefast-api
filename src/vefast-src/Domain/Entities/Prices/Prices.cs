using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Prices
{
    using vefast_src.Domain.Entities.PriceTypes;
    using vefast_src.Domain.Entities.Products;
    public class Prices : BaseEntity
    {

        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }
        public double Utility { get; set; }

        [Required]
        [ForeignKey("PriceType")]
        public Guid ID_PriceType { get; set; }
        public virtual PriceTypes PriceType { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid ID_Product { get; set; }
        public virtual Products Product { get; set; }



    }
}
 