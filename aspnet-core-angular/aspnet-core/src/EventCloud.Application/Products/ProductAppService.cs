using System;

namespace EventCloud.Products
{
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Dto;

public class ProductAppService : AsyncCrudAppService<Product, ProductDto, Guid, PagedResultRequestDto, CreateProductDto, ProductDto>, IProductAppService
{
private IRepository<Product, Guid> _productRepository;

public ProductAppService(IRepository<Product, Guid> productRepository) : base(productRepository)
{
_productRepository = productRepository;
}
}
}