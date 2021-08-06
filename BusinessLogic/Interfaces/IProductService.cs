using BLL.Infrastructure;
using Common.Models.Inputs.Products;
using Common.Models.Outputs;
using DTOs;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService : IService
    {
        Task<ProductDTO> CreateAsync(CreateProductInput createProductInput);

        Task<GetProductOutput> GetByIdAsync(int id);

        Task<ProductDTO> DeleteAsync(int id);

        Task<ProductDTO> UpdateAsync(UpdateProductInput updateProductInput);
    }
}
