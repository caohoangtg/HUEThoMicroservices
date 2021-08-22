using System;

namespace Catalog.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string LastModifiedBy { get; private set; }
        public DateTime? LastModifiedDate { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedBy = "HoangTC";
            CreatedDate = DateTime.UtcNow;
        }

        public void UpdateLastModified(string lastModifiedBy, DateTime? lastModifiedDate)
        {
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
        }
    }
}
