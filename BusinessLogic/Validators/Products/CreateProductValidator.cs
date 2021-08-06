using BLL.Infastructure;
using Common.Helpers;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BLL.Validators.Products
{
    internal class CreateProductValidator : EntityValidator<Product>
    {
        public CreateProductValidator(TechnaminDemoDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task ValidateAsync(Product product)
        {
            if(await DbContext.Products.AnyAsync(p => p.Name == product.Name))
                ExceptionHelper.ThrowFaultException("Product name already exists!", StatusCodes.Status400BadRequest);
        }
    }
}
