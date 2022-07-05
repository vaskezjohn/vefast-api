namespace vefast_src.Domain.Entities.Stores
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Companies;

    public class Stores : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        [ForeignKey("Companies")]
        public Guid ID_Company { get; set; }
        public virtual Companies Company { get; set; }
    }
}
