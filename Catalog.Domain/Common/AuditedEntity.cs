using Catalog.Domain.Common.Interfaces;

namespace Catalog.Domain.Common
{
    public abstract class AuditedEntity : AuditedEntity<int>
    { }

    public abstract class AuditedEntity<T> : IAuditedEntity
    {
        public T Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}