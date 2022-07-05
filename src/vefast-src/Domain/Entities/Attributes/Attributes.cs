namespace vefast_src.Domain.Entities.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using vefast_src.Domain.Entities.AttributeValues;

    public class Attributes : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        virtual public IEnumerable<AttributeValues> AttributeValues { get; set; }
    }
}
