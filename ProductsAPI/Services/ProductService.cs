using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Data.Entities;
using ProductsAPI.Repository;
using ProductsAPI.Services.Dto;
using System.Runtime.CompilerServices;

namespace ProductsAPI.Services
{
    public interface IProductService {
        Task<ProductDto?> GetByIdAsync(int id);
        Task<List<ProductListDto>> GetAllAsyc(Pagination pagination);
        Task<ProductDto> SaveAsync(ProductDto product);
        Task<bool> RemoveAsync(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private IMapper _mapper;    
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper; 
        }

        public async Task<List<ProductListDto>> GetAllAsyc(Pagination pagination)
        {
           return _mapper.Map<List<ProductListDto>>(await _productRepository.GetAllAsyc(pagination));
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetByIdAsync(id));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _productRepository.RemoveAsync(id);
        }

        public async Task<ProductDto> SaveAsync(ProductDto productDto)
        {
            var mappedEntity = _mapper.Map<Product>(productDto);
            return _mapper.Map<ProductDto>(await _productRepository.SaveAsync(mappedEntity));
        }
    }
}
