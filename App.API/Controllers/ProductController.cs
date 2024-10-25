using App.API.Controllers.Commons;
using App.Business.DTOs.ProductDTOs;
using App.Business.Services.InternalServices.Interfaces;
using AppTech.Business.Validators.ProductValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _ProductService.GetAllAsync());
        }

        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = new GetByIdProductDTO() { Id = id };
            var validations = await new GetByIdProductDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _ProductService.GetByIdAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromForm] CreateProductDTO dto)
        {
            var validations = await new CreateProductDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? StatusCode(201, await _ProductService.AddAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var dto = new DeleteProductDTO() { Id = id };
            var validations = await new DeleteProductDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _ProductService.DeleteAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDTO dto)
        {
            var validations = await new UpdateProductDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _ProductService.UpdateAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

    }

}
