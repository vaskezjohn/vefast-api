using System;
namespace vefast_src.Domain.Exceptions.Stores
{
    public class StoresNotFoundException : Exception
    {
        public StoresNotFoundException(string message) :base(message)
        {
        }
    }
}
