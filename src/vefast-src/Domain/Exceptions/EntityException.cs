using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Exceptions
{
    public class EntityException : Exception
    {
        public virtual string Code { get; set; }
        public virtual string Field { get; set; }

        public EntityException(string businessMessage)
             : base(businessMessage)
        {
        }
    }
}
