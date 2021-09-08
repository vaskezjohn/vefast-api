using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.DTO.TipoProducto
{
    using vefast_src.Domain.Entities.Products;
    public class TipoProductoRequest
    {
        public string tipoProduct { get; set; }
        public bool active { get; set; }
        [ForeignKey("Products")]
        public Guid ProductsID { get; set; }
        public virtual Products Products { get; set; }
    }
}
