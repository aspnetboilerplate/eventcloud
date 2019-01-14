using System;

namespace EventCloud.Products
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Dto;

    public interface IProductAppService : IAsyncCrudAppService<ProductDto, Guid, PagedResultRequestDto, CreateProductDto, ProductDto>
    {

    }
}