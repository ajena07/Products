using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProductsWebAPI.Controllers;
using ProductsWebAPI.DataBase.Repository;
using ProductsWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProductsWebAPI.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IRepository> _mockRepository;
        private readonly Mock<ILogger<ProductsController>> _mockLogger;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockRepository = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<ProductsController>>();
            _controller = new ProductsController(_mockLogger.Object, _mockRepository.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 123456, ProductDescription = "Test Product" } };
            _mockRepository.Setup(repo => repo.GetAllProducts()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetProducts_ReturnsNoContent_WhenNoProductsFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAllProducts()).ReturnsAsync(new List<Product>());

            // Act
            var result = await _controller.GetProducts();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetProductById_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var product = new Product { Id = 123456, ProductDescription = "Test Product" };
            _mockRepository.Setup(repo => repo.GetProductById(123456)).ReturnsAsync(product);

            // Act
            var result = await _controller.GetProductByid(123456);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(123456, returnValue.Id);
        }

        [Fact]
        public async Task GetProductById_ReturnsBadRequest_WhenInvalidId()
        {
            // Act
            var result = await _controller.GetProductByid(123);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid Id. The Id should be a 6 digit Number", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateProducts_ReturnsOkResult()
        {
            // Arrange
            var product = new Product { Id = 123456, ProductDescription = "Test Product" };

            // Act
            var result = await _controller.CreateProducts(product);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteProductById_ReturnsOkResult()
        {
            // Act
            var result = await _controller.DeleteProductByid(123456);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProductById_ReturnsOkResult()
        {
            // Arrange
            var product = new Product { Id = 123456, ProductDescription = "Updated Product" };

            // Act
            var result = await _controller.UpdateProductByid(123456, product);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task IncrementStockByProductId_ReturnsOkResult()
        {
            // Act
            var result = await _controller.IncrementStockByProductid(123456, 10);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DecrementStockByProductId_ReturnsOkResult()
        {
            // Act
            var result = await _controller.DecrementStockByProductid(123456, 10);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
