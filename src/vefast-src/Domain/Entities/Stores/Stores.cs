using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Stores

{
    public class Stores : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid Company_id { get; set; }
    }
}
