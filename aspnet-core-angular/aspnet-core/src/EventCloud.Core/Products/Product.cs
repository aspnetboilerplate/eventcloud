using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Products
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppProduct")]
    public class Product : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;
        public const int MaxDescriptionLength = 2048;
        public const int MaxDescriptionEmall = 300;

        public string EAN { get; set; }
        public string NCM { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [StringLength(MaxDescriptionEmall)]
        public string DescriptionEmall { get; set; }

        public DateTime Modified { get; set; }

        [Required]
        [Range(0, 9999999999999.9999, ErrorMessage = "Valor inválido")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 9999999999999.9999, ErrorMessage = "Valor inválido")]
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