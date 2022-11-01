using ProductsApp.Data;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    [RoutePrefix("api/v1/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("teste")]
        // Get api/v1/products/teste
        public IHttpActionResult GetTeste()
        {
            return Ok("alo ari");
        }

        [HttpGet]
        [Route("")]
        // Get api/v1/products
        public IHttpActionResult GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        // Get api/v1/products/5
        public IHttpActionResult GetProductsById(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("{name:alpha},{category:alpha},{price:int}")]
        // POST api/v1/products?name=ari&category=vip&price=442
        public IHttpActionResult PostProduct(string name, string category, int price)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _productRepository.PostProduct(name, category, price);

            return Ok();
        }

        [HttpPost]
        [Route("")]
        // POST api/v1/products
        public IHttpActionResult PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _productRepository.PostProduct(product);

            return Ok();
        }

        [HttpPut]
        [Route("")]
        // PUT api/v1/products
        public IHttpActionResult PutProduct([FromBody]Product product)
        {
            int ret;

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            ret = _productRepository.PutProduct(product);

            if (ret == 1) return NotFound(); 

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        // DELETE api/v1/products/5
        public IHttpActionResult DeleteProduct(int id)
        {
            int ret;

            if (id <= 0)
                return BadRequest("Not a valid student id");

            ret = _productRepository.DeleteProduct(id);

            if (ret == 1) return NotFound();

            return Ok();
        }
    }
}