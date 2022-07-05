using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Exceptions.ProductTypes
{
    public class ProductTypesNotFoundException : Exception
    {
        public ProductTypesNotFoundException(string message)
            : base(message)
        {
        }
    }
}
