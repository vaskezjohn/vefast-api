namespace vefast_src.Domain.Entities.StockDeposits
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Products;
    using vefast_src.Domain.Entities.Stores;
    public class StockDeposits : BaseEntity
    {
        [Required]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public Guid ID_Product { get; set; }
        public virtual Products Product { get; set; }

        [ForeignKey("Store")]
        public Guid ID_Store { get; set; }
        public virtual Stores Store { get; set; }
    }
}
