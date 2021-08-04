using BLL.Common;
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Services;
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
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// Add product  
        /// </summary>
        /// <param name="createProductInput"></param>
        /// <returns></returns>
        [HttpPost("AddProduct")]
        //[Authorize]
        public async Task<IActionResult> AddProductAsync(CreateProductInput createProductInput)
        {
            var product = await _productService.CreateAsync(createProductInput);
            //await _cashService.ClearCacheAsync(ProductCacheKeys.ReadAllProducts);
            return Ok("Product has been successfully created");
        }

        /// <summary>
        /// Delete product  
        /// </summary>
        /// <param name="deleteProductInput"></param>
        /// <returns></returns>
        [HttpPost("DeleteProduct")]
        //[Authorize]
        public async Task<IActionResult> DeleteProductAsync(DeleteProductInput deleteProductInput)
        {
            var product = await _productService.DeleteAsync(deleteProductInput);
            //await _cashService.ClearCacheAsync(ProductCacheKeys.ReadAllProducts);
            return Ok("Product has been successfully deleted");
        }

        /// <summary>
        /// Update product  
        /// </summary>
        /// <param name="updateProductInput"></param>
        /// <returns></returns>
        [HttpPost("UpdateProduct")]
        //[Authorize]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductInput updateProductInput)
        {
            var product = await _productService.UpdateAsync(updateProductInput);
            //await _cashService.ClearCacheAsync(ProductCacheKeys.ReadAllProducts);
            return Ok("Product has been successfully updated");
        }
    }
}
