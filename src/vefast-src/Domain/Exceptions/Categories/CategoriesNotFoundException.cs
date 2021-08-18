using System;
namespace vefast_src.Domain.Exceptions.Categories
{
    public class CategoriesNotFoundException : Exception
    {
        public CategoriesNotFoundException(string message) : base (message)
        {
        }
    }
}
