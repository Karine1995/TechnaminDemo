using BLL.Mappers;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnaminDemo.Controllers
{
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductOperations _productOperations;

        public ProductController(IProductOperations productOperations)
        {
            this._productOperations = productOperations;
        }
        /// <summary>
        ///Add new  Product  
        /// </summary>
        /// <param name="ProductForCreate"></param>
        /// <returns></returns>
        [HttpPost("AddProduct")]
        //[Authorize]
        public async Task<IActionResult> AddAsync(CreateProductInput product)
        {
            var Product = await _productOperations.Create(product);
            //await _cashService.ClearCacheAsync(ProductCacheKeys.ReadAllProducts);
            return Ok(Product);
        }
    }
}
