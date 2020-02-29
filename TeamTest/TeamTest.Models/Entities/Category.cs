using System;
using System.Collections.Generic;
using System.Text;

namespace TeamTest.Models.Entities
{
    public class Category: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductsCategories> ProductsCategories { get; set; }
    }
}
