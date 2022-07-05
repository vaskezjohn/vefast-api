namespace vefast_src.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual Users.Users UpdateUser { get; set; }
        public virtual Users.Users InsertUser { get; set; }
        public Guid GetID()
        {
            return ID;
        }

    }
}
