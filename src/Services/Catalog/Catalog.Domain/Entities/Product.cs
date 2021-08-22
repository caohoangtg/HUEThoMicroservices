using Catalog.Domain.Common;
using System;

namespace Catalog.Domain.Entities
{
    public class Product: EntityBase
    {
        public string Name { get; private set; }

        public string Category { get; private set; }

        public string Summary { get; private set; }

        public string Description { get; private set; }

        public string ImageFile { get; private set; }

        //[Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; private set; }

        public Product(string name, string category, string summary, string description, string imageFile, decimal price) : base()
        {
            Name = name;
            Category = category;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}
