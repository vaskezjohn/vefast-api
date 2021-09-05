using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Exceptions.TipoProducto
{
    public class TipoProductoNotFoundException : Exception
    {
        public TipoProductoNotFoundException(string message)
            :base(message)
        {
        }
    }
}
