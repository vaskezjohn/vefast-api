using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Attributes
{
    using vefast_src.Domain.Entities.AttributeValue;
    public class Attributes : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid AttributeValueID { get; set; }

        virtual public AttributeValue AttributeValue { get; set; }
    }
}
