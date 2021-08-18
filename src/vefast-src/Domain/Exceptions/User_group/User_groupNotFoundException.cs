using System;
namespace vefast_src.Domain.Exceptions.User_group
{
    public class User_groupNotFoundException : Exception
    {
        public User_groupNotFoundException(string message) : base(message)
        {
        }
    }
}
