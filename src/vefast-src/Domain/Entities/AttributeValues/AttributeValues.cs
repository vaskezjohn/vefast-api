﻿namespace vefast_src.Domain.Entities.AttributeValues
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.AttributeValuesProductTypes;

    public class AttributeValues : BaseEntity
    {
        public string Value { get; set; }

        [ForeignKey("Attribute")]
        public Guid ID_Attribute { get; set; }
        public virtual Attribute Attribute { get; set; }
    }
}
