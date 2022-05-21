using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Product : AuditedEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string? Image { get; set; }
    }
}