using System;

namespace vefast_src.Domain.Exceptions.Users
{
    public class UsersNotFoundException : EntityException
    {
        public UsersNotFoundException(string message)
            : base(message)
        {
        }
    }
}
