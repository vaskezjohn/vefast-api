using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vefast_src.DTO.Products;

namespace vefast_src.Domain.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<ProductsResponse> GetAllProducts();
        Task<ProductsResponse> CreateProductsAsync(ProductsRequest objRequest);
        Task<ProductsResponse> GetProductsByIdAsync(Guid id);
        Task DeleteProductsById(Guid id);
        Task<ProductsResponse> EditProductsByIdAsync(Guid id, ProductsRequest objRequest);
    }
}
