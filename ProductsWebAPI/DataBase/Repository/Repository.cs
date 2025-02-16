using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Controllers;
using ProductsWebAPI.Model;

namespace ProductsWebAPI.DataBase.Repository
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        private readonly ProductContext _context;
        public Repository(ILogger<Repository> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task AddProducts(Product products)
        {
            products.CreateDateTime = DateTime.UtcNow;
            products.UpdateDateTime = DateTime.UtcNow;
            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateProductsById(int id, Product products)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.ProductType = products.ProductType;
                product.Quantity = products.Quantity;
                product.ProductClassification = products.ProductClassification;
                products.UpdateDateTime = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }


        public async Task IncrementQuantityByProductId(int id, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.Quantity = product.Quantity + quantity;
                product.UpdateDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DecrementQuantityByProductId(int id, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                if ((product.Quantity - quantity) < 0)
                {
                    throw new Exception("Not Enough Product Quantity Available in Stock");
                }

                product.Quantity = product.Quantity - quantity;
                product.UpdateDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
