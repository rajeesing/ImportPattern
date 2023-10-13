using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models.Product
{
    [Table("Product")]
    public class ProductModel : IModel
    {
        public ProductModel()
        {
            Items = new HashSet<ItemModel>();
        }
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<ItemModel> Items { get; set; }
    }

    public class ItemModel
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductId { get; set; }
        public virtual List<ProductImageModel> ImageUrls { get; set; }
    }

    public class ProductImageModel
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public bool IsDefault { get; set; }
        public int ItemId { get; set; }
    }
}
