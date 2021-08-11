using System;

namespace vafast_src.Domain.Exceptions.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
