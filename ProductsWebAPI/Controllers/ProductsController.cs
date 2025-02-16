using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductsWebAPI.Common;
using ProductsWebAPI.DataBase.Repository;
using ProductsWebAPI.Model;
using System.Net;

namespace ProductsWebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IRepository _repository;

        public ProductsController(ILogger<ProductsController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _repository.GetAllProducts();

                if (products == null || !products.Any())
                {
                    return NoContent();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("products/{id}")]
        public async Task<IActionResult> GetProductByid([FromRoute]int id)
        {
            try
            {
                if (!id.ToString().Length.Equals(6))
                {
                    return BadRequest("Invalid Id. The Id should be a 6 digit Number");
                }
                var productResult = await _repository.GetProductById(id);
                if (productResult == null)
                {
                    return NoContent();
                }
                return Ok(productResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> CreateProducts([FromBody] Product products)
        {
            try
            {
                // Assign product id
                //products.Id = Utilities.();
                await _repository.AddProducts(products);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("products/{id}")]
        public async Task<IActionResult> DeleteProductByid([FromRoute]int id)
        {
            try
            {
                if (!id.ToString().Length.Equals(6))
                {
                    return BadRequest("Invalid Id. The Id should be a 6 digit Number");
                }

                await _repository.DeleteProductById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("products/{id}")]
        public async Task<IActionResult> UpdateProductByid([FromRoute]int id, [FromBody] Product product)
        {
            try
            {
                if (!id.ToString().Length.Equals(6))
                {
                    return BadRequest("Invalid Id. The Id should be a 6 digit Number");
                }
                await _repository.UpdateProductsById(id, product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("products/add-to-stock/{id}/{quantity}")]
        public async Task<IActionResult> IncrementStockByProductid([FromRoute]int id, [FromRoute]int quantity)
        {
            try
            {
                if (!id.ToString().Length.Equals(6))
                {
                    return BadRequest("Invalid Id. The Id should be a 6 digit Number");
                }

                if (quantity <= 0)
                {
                    return BadRequest("Invalid Quantity. Quantity should be greater than 0");
                }
                await _repository.IncrementQuantityByProductId(id, quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("products/decrement-stock/{id}/{quantity}")]
        public async Task<IActionResult> DecrementStockByProductid([FromRoute]int id, [FromRoute]int quantity)
        {
            try
            {
                if (!id.ToString().Length.Equals(6))
                {
                    return BadRequest("Invalid Id. The Id should be a 6 digit Number");
                }

                if (quantity <= 0)
                {
                    return BadRequest("Invalid Quantity. Quantity should be greater than 0");
                }
                await _repository.DecrementQuantityByProductId(id, quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

