namespace vefast_src.Domain.Entities.Companies
{
    using System.ComponentModel.DataAnnotations;

    public class Companies : BaseEntity
    {
        [StringLength(255)]
        public string CompanyName { get; set; }
        [StringLength(255)]
        public string ServiceChargeValue { get; set; }
        [StringLength(255)]
        public string VatChargeValue { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Country { get; set; }
        [StringLength(255)]
        public string Message { get; set; }
        [StringLength(255)]
        public string Currency { get; set; }
    }
}
