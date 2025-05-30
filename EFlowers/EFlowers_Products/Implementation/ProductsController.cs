﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFlowers_Products.Implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var produtosDto = await _productService.GetProducts();
            if (produtosDto == null)
            {
                return NotFound("Products not found");
            }
            return Ok(produtosDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var produtoDto = await _productService.GetProductById(id);
            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }
            return Ok(produtoDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data Invalid");

            await _productService.AddProduct(produtoDto);

            return new CreatedAtRouteResult("GetProduct",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] ProductDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data invalid");

            await _productService.UpdateProduct(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var produtoDto = await _productService.GetProductById(id);

            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }

            await _productService.RemoveProduct(id);

            return Ok(produtoDto);
        }
    }
}
