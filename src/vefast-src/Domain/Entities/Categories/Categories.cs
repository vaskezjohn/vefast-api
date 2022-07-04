﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Categories
{
    using System.Collections.Generic;
    using vefast_src.Domain.Entities.Products;
    public class Categories : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }

    }
}
