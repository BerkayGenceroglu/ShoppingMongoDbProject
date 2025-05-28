using MongoDbShopping.DTOs.ProductDTOs;

namespace MongoDbShopping.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductDto> GetProductByIdAsync(string id);
    }
}
