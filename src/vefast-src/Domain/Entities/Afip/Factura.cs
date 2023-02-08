using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Afip
{
    public class Factura
    {
        public InfoTributaria InfoTributaria { get; set; }
        public InfoFactura InfoFactura { get; set; }
        public List<Concepto> Conceptos { get; set; }
        public Impuestos Impuestos { get; set; }

        public Factura()
        {
            this.InfoTributaria = new InfoTributaria();
            this.InfoFactura = new InfoFactura();
            this.Conceptos = new List<Concepto>();
            this.Impuestos = new Impuestos();
        }
    }
}
