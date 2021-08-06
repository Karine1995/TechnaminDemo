﻿using BLL.Interfaces;
using Common.Models.Inputs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnaminDemo.Filters;

namespace TechnaminDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [Autorization]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Add product  
        /// </summary>
        /// <param name="createProductInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductInput createProductInput)
        {
            await _productService.CreateAsync(createProductInput);

            return Ok("Product has been successfully created");
        }

        /// <summary>
        /// Delete product  
        /// </summary>
        /// <param name="deleteProductInput"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteAsync(id);

            return Ok("Product has been successfully deleted");
        }

        /// <summary>
        /// Update product  
        /// </summary>
        /// <param name="updateProductInput"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductInput updateProductInput)
        {
            await _productService.UpdateAsync(updateProductInput);

            return Ok("Product has been successfully updated");
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();

            return Ok(result);
        }
    }
}
