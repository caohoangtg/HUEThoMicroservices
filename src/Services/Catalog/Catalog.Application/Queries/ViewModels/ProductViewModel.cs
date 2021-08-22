using System;

namespace Catalog.Application.Queries
{
    public class ProductViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Category { get; private set; }

        public string Summary { get; private set; }

        public string Description { get; private set; }

        public string ImageFile { get; private set; }

        public decimal Price { get; private set; }

        public string CreatedBy { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public string LastModifiedBy { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }
    }
}
