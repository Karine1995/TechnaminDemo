
using BLL.Infrastructure;
using DAL.Entities;
using DTOs;
using System.Threading.Tasks;
using BLL.Common;

namespace BLL.Interfaces
{
    public interface IProductService : IService
    {
        Task<ProductDTO> CreateAsync(CreateProductInput createProductInput);

        Product GetByIdAsync(int id);

        Task<ProductDTO> DeleteAsync(DeleteProductInput deleteProductInput);
    }
}
