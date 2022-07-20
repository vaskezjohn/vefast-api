using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Users
{
    public record AuthenticateRequest
    (
        string UserName,
        string Password
    );
}
