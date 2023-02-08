using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Afip
{
    public class Concepto
    {
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public double Importe { get; set; }
    }
}
