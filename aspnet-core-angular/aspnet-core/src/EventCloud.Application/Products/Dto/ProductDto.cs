using System;

namespace EventCloud.Products.Dto
{

    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Product))]
    public class ProductDto : FullAuditedEntityDto<Guid>
    {
        public const int MaxNameLength = 128;
        public const int MaxDescriptionLength = 2048;
        public const int MaxDescriptionEmall = 300;

        public string EAN { get; set; }
        public string NCM { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DescriptionEmall { get; set; }

        public DateTime Modified { get; set; }

        public decimal Price { get; set; }

        public decimal CostPrice { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Double Weight { get; set; }
        public Double Length { get; set; }
        public Double Width { get; set; }
        public Double Height { get; set; }
        public Double CubicWeight { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string Reference { get; set; }
        public string AdditionalMessage { get; set; }
        public string Warranty { get; set; }
        public DateTime Created { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Shortcut { get; set; }
        public int MinimumStock { get; set; }
        public int MinimumStockAlert { get; set; }
        public string IncludedItems { get; set; }
    }
}