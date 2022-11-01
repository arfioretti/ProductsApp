

using ProductsApp.Models;
using System.Data.Entity;

namespace ProductsApp.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base()
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}