using System;

namespace vefast_src.Domain.Exceptions.UserGroups
{
    public class UserGroupsNotFoundException : Exception
    {
        public UserGroupsNotFoundException(string message) : base(message)
        {
        }
    }
}
