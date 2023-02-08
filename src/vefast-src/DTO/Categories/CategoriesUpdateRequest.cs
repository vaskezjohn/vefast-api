using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Categories
{
    public class CategoriesUpdateRequest
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid ID_ParentCategory { get; set; }
    }
}
