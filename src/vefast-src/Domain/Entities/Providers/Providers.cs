using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Providers
{
    using vefast_src.Domain.Entities.Provinces;
    using vefast_src.Domain.Entities.Countries;
    using vefast_src.Domain.Entities.IVACategories;
    using vefast_src.Domain.Entities.BookkeepingEntries;
    public class Providers : BaseEntity
    {
        [Required]
        public string CodVFS { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Required]
        [ForeignKey("Country")]
        public Guid ID_Country { get; set; }
        public Countries Country { get; set; }

        [Required]
        [ForeignKey("Province")]
        public Guid ID_Province { get; set; }
        public Provinces Province { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string PostalCode { get; set; }

        [Required]
        [ForeignKey("IVACategory")]
        public Guid ID_IVACategory { get; set; }
        public IVACategories IVACategory { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CUIT { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CellPhone { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Referrer { get; set; }

        [Column(TypeName = "int")]
        public int Discount { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(10000)")]
        public string Observations { get; set; }

        [Required]
        [ForeignKey("BookkeepingEntryDebit")]
        public Guid ID_ImputationDebit { get; set; }

        [Required]
        [ForeignKey("BookkeepingEntryCredit")]
        public Guid ID_ImputationCredit { get; set; }
        public virtual BookkeepingEntries BookkeepingEntryDebit { get; set; }
        public virtual BookkeepingEntries BookkeepingEntryCredit { get; set; }


    }
}
