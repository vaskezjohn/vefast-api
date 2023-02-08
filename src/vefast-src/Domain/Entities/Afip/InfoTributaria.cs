using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Afip
{
    public class InfoTributaria
    {
        public string Cuit { get; set; }
        public int PtoVta { get; set; }
        public int TipoComp { get; set; }
        public int Nro { get; set; }
    }
}
