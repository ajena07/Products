using ProductsWebAPI.Model;

namespace ProductsWebAPI.DataBase.Repository
{
    public interface IRepository

    {
        Task<List<Product>> GetAllProducts();
        Task AddProducts(Product products);
        Task<Product> GetProductById(int id);
        Task UpdateProductsById(int id, Product products);
        Task DeleteProductById(int id);
        Task IncrementQuantityByProductId(int id, int quantity);
        Task DecrementQuantityByProductId(int id, int quantity);
    }
}
