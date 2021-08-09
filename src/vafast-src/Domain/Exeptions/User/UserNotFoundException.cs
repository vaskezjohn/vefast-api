using System;

namespace vafast_src.Domain.Exeptions.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
