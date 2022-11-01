using ProductsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductsApp.Models
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            var ctx = new ProductContext();
            products = ctx.Products.Where(k => k.Id > 0).ToList();

            return products;
        }

        public Product GetProductById(int id)
        {
            var ctx = new ProductContext();
            var product = ctx.Products.FirstOrDefault((p) => p.Id == id);

            return product;
        }

        public int PostProduct(string name, string category, int price)
        {
            int ret = 1;

            using (var ctx = new ProductContext())
            {
                ctx.Products.Add(new Product()
                {
                    Name = name,
                    Category = category,
                    Price = price
                });

                ctx.SaveChanges();

                ret = 0;
            }

            return ret; // deu ruim
        }

        public int PostProduct([FromBody]Product product)
        {
            int ret = 1;

            using (var ctx = new ProductContext())
            {
                ctx.Products.Add(new Product()
                {
                    Name = product.Name,
                    Category = product.Category,
                    Price = product.Price
                });

                ctx.SaveChanges();

                ret = 0;
            }

            return ret; // deu ruim
        }

        public int PutProduct([FromBody]Product product)
        {
            int ret = 1; // deu ruim

            using (var ctx = new ProductContext())
            {
                var existingProduct = ctx.Products.Where(s => s.Id == product.Id)
                                                        .FirstOrDefault<Product>();

                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Category = product.Category;
                    existingProduct.Price = product.Price;

                    ctx.SaveChanges();

                    ret = 0;
                }
            }

            return ret;
        }
        public int DeleteProduct(int id)
        {
            int ret = 1;

            using (var ctx = new ProductContext())
            {
                var product = ctx.Products
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                if (product == null) return ret;

                ctx.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();

                ret = 0;
            }

            return ret;
        }

    }
}