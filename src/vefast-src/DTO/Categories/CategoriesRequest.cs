﻿using System;
namespace vefast_src.DTO.Categories
{
    public class CategoriesRequest
    {
        public string Name { get; set; }
        public Guid ID_ParentCategory { get; set; }
    }
}
