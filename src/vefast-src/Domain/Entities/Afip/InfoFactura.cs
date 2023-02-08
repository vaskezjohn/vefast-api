using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Afip
{
    public class InfoFactura
    {
        public DateTime Fecha { get; set; }
        public DateTime FechaVto { get; set; }
        public string Id { get; set; }
        public string MonedaId { get; set; }
        public double MonedaCotizacion { get; set; }
        public string Observaciones { get; set; }
        public string Resultado { get; set; }
        public double ImporteTotal { get; set; }
        public double ImporteOperacionesExentas { get; set; }
        public double ImporteOperacionesExcluidas { get; set; }
    }
}
