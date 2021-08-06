using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Validators.Products;
using Common.Helpers;
using Common.Models.Inputs.Products;
using Common.Models.Outputs;
using DAL;
using DAL.Entities;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            var validator = new CreateProductValidator(DbContext);
            await validator.ValidateAsync(product);

            await DbContext.Products.AddAsync(product);
            await DbContext.SaveChangesAsync();

            return product.MapTo<ProductDTO>();
        }

        public async Task<GetProductOutput> GetByIdAsync(int id)
            => await DbContext.Products.AsNoTracking()
            .Select(p => new GetProductOutput
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Available = p.Available,
                Description = p.Description,
                CreationDate = p.CreationDate
            }).Where(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<ProductDTO> DeleteAsync(int id)
        {
            var product = await DbContext.Products.FirstOrDefaultAsync(a => a.Id == id);

            if (product == default)
                ExceptionHelper.ThrowFaultException("Product not found!", StatusCodes.Status400BadRequest);

            DbContext.Products.Remove(product);
            await DbContext.SaveChangesAsync();

            return product.MapTo<ProductDTO>();
        }

        public async Task<ProductDTO> UpdateAsync(UpdateProductInput updateProductInput)
        {
            var product = await DbContext.Products.FirstOrDefaultAsync(a => a.Id == updateProductInput.Id);

            if (product == default)
                ExceptionHelper.ThrowFaultException("Product not found!", StatusCodes.Status400BadRequest);

            product.Price = updateProductInput.Price;
            product.Available = updateProductInput.Available;
            product.Description = updateProductInput.Description;

            await DbContext.SaveChangesAsync();

            return product.MapTo<ProductDTO>();
        }

        public async Task<List<GetProductOutput>> GetAllAsync()
        =>  await DbContext.Products.AsNoTracking()
            .Select(p => new GetProductOutput
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Available = p.Available
            }).ToListAsync();
       
    }
}