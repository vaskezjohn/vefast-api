using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.Afip
{
    public interface IAfipService
    {
        Task GeneratEInvoice();
    }
}
