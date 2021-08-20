using System;
namespace vefast_src.Domain.Exceptions.UserGroup
{
    public class UserGroupNotFoundException : Exception
    {
        public UserGroupNotFoundException(string message) : base(message)
        {
        }
    }
}
