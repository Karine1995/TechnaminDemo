using BLL.Common;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Mappers;
using DAL;
using DAL.Entities;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : Service, IProductService
    {
        public ProductService(TechnaminDemoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProductDTO> CreateAsync(CreateProductInput createProductInput)
        {
            var product = createProductInput.MapTo<Product>();
            //var validator = new CreateProductValidator(DbContext);
            //await validator.ValidateAsync(Product);

            await DbContext.Products.AddAsync(product);
            await DbContext.SaveChangesAsync();

            return product.MapTo<ProductDTO>();
        }

        public Product GetByIdAsync(int id)
        {
            var Product = DbContext.Products.Where(m => m.Id == id)
                                            .Include(m => m.Assignments)
                                            .FirstOrDefault();
            return Product;
        }

        public async Task<ProductDTO> DeleteAsync(DeleteProductInput deleteProductInput)
        {
            var Product = deleteProductInput.MapTo<Product>();
            var validator = new DeleteProductValidator(DbContext);
            await validator.ValidateAsync(Product);

            DbContext.Products.Remove(Product);
            await DbContext.SaveChangesAsync();

            return Product.MapTo<ProductDTO>();
        }
    }
}