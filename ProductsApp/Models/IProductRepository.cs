using System.Collections.Generic;
using System.Web.Http;

namespace ProductsApp.Models
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        int PostProduct(string name, string category, int price);
        int PostProduct(Product product);
        int PutProduct(Product product);
        int DeleteProduct(int id);
    }
}
