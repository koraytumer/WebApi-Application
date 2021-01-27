using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Business.Abstract;
using SampleApplication.Entities.Entities;
using SampleApplication.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.WebApi.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var products = _productService.GetList();
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productService.Get(x => x.ProductId == productId);
                if (product == null)
                {
                    return NotFound($"There is no product with Id={productId}");
                }
                return Ok(product);
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post(ProductModel model)
        {
            try
            {
                var entity = new Product()
                {
                    CategoryId = model.CategoryId,
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock
                };
                _productService.Add(entity);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(ProductModel model)
        {
            try
            {
                var entity = new Product()
                {
                    ProductId = model.ProductId,
                    CategoryId = model.CategoryId,
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock
                };
                _productService.Update(entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productService.Delete(new Product { ProductId = productId });
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
    }
}
