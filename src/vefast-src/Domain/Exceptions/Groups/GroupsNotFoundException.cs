using System;
namespace vefast_src.Domain.Exceptions.Groups
{
    public class GroupsNotFoundException : Exception
    {
        public GroupsNotFoundException(string message) : base(message)
        {
        }
    }
}
