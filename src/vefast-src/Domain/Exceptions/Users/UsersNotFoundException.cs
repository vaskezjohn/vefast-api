using System;

namespace vefast_src.Domain.Exceptions.Users
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(string message)
            : base(message)
        {
        }
    }
}
