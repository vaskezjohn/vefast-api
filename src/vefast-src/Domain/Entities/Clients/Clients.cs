namespace vefast_src.Domain.Entities.Clients
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using vefast_src.Domain.Entities.Provinces;
    using vefast_src.Domain.Entities.Countries;
    using vefast_src.Domain.Entities.IVACategories;
    using vefast_src.Domain.Entities.Prices;

    public class Clients : BaseEntity
    {
        [Required]
        public string CodVFS { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string BusinessName { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }

        [Required]
        [ForeignKey("Province")]
        public Guid ID_Province { get; set; }
        public Provinces Province { get; set; }

        [Required]
        [ForeignKey("Country")]
        public Guid ID_Country { get; set; }
        public Countries Country { get; set; }       

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string PostalCode { get; set; }

        [Required]
        [ForeignKey("IVACategory")]
        public Guid ID_IVACategory { get; set; }
        public IVACategories IVACategory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string CUIT { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CellPhone { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }

        [Required]
        [ForeignKey("Price")]
        public Guid ID_Price { get; set; }
        public Prices Price { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public double CreditLimit { get; set; }

        [Column(TypeName = "int")]
        public int Discount { get; set; }

        [Column(TypeName = "nvarchar(10000)")]
        public string Observations { get; set; }
    }
}
