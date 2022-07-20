namespace vefast_src.Domain.Entities.Companies
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Companies : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")] 
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ServiceChargeValue { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string VatChargeValue { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Country { get; set; }
        [StringLength(255)]
        public string Message { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Currency { get; set; }
    }
}
