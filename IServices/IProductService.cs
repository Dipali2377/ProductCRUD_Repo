using ProductCRUD.Models;

namespace ProductCRUD.IServices
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);        
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);        
        Task<bool> DeleteProductAsync(int id);
        
    }
}
