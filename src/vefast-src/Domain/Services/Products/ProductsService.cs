using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Products;
using vefast_src.Domain.Repositories.Products;
using vefast_src.DTO.Products;

namespace vefast_src.Domain.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IMapper mapper, IProductsRepository productsRepository)
        {
            this._mapper = mapper;
            this._productsRepository = productsRepository;
        }

        public IEnumerable<ProductsResponse> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductsResponse>>(_productsRepository.GetAll());
        }

        public async Task<ProductsResponse> CreateProductsAsync(ProductsRequest objRequest)
        {
            var products = _mapper.Map<Entities.Products.Products>(objRequest);
            _productsRepository.Add(products);

            try
            {
                await _productsRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<ProductsResponse>(products);
        }

        public async Task<ProductsResponse> GetProductsByIdAsync(Guid id)
        {
            var products = await _productsRepository.GetByIDAsync(id);
            if (products == null)
            {
                throw new ProductsNotFoundException("Producto no encontrado.");
            }

            return _mapper.Map<ProductsResponse>(products);
        }

        public async Task DeleteProductsById(Guid id)
        {
            var products = _productsRepository.GetByID(id);

            if (products == null)
            {
                throw new ProductsNotFoundException("Empresa no encontrada.");
            }

            _productsRepository.Delete(products);
            await _productsRepository.SaveAsync();
        }

        public async Task<ProductsResponse> EditProductsByIdAsync(Guid id, ProductsRequest objRequest)
        {
            var products = await _productsRepository.GetByIDAsync(id);

            if (products == null)
            {
                throw new ProductsNotFoundException("Empresa no encontrada.");
            }

            
            products.description = objRequest.description;
            products.availability = objRequest.availability;
            products.brand_id = objRequest.brand_id;
            products.category_id = objRequest.category_id;                     
            products.UpdateDate = DateTime.Now;

            _productsRepository.Update(products);
            await _productsRepository.SaveAsync();

            return _mapper.Map<ProductsResponse>(products);
        }

    }
}
