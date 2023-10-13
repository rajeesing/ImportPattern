using ImportPattern.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Persistence.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set; }
        public DbSet<ItemModel> Item { get; set; }
        public DbSet<ProductImageModel> ProductImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        }
    }
}
