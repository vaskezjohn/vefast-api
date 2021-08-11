using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vafast_src.Domain.Exceptions.Products
{
    public class ProductsNotFoundException : Exception
    {
        public ProductsNotFoundException(string message)
              : base(message)
        {
        }
    }
}
