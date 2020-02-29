using System;
using System.Collections.Generic;
using System.Text;

namespace TeamTest.Models.Entities
{
    public class Product: EntityBase
    {
        /// <summary>
        /// Product’s name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product’s description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Product Brand identifier
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// Product Brand information
        /// </summary>
        public Brand Brand { get; set; }
        /// <summary>
        /// Image of the product
        /// </summary>
        public byte[] Photo { get; set; }
        /// <summary>
        /// Product’s price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Number of items in stock
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Product Categories
        /// </summary>
        public virtual ICollection<ProductsCategories> ProductsCategories { get; set; }
    }
}
