using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Exceptions.Companies
{
    public class CompaniesNotFoundException : Exception
    {
        public CompaniesNotFoundException(string message)
            : base(message)
        {
        }
    }
}
