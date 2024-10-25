using App.API.Controllers.Commons;
using App.Business.DTOs.TranslationDTOs;
using App.Business.Services.InternalServices.Interfaces;
using App.Business.Validators.TranslationValidator;
using App.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class ProductTranslationController : BaseController
    {
        private readonly IProductTranslationService _productTranslationService;

        public ProductTranslationController(IProductTranslationService productTranslationService)
        {
            _productTranslationService = productTranslationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _productTranslationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = new GetByIdTranslationDTO { Id = id };
            var validations = await new GetByIdTranslationDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _productTranslationService.GetByIdAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromForm] CreateTranslationDTO<Product> dto)
        {
            var validations = await new CreateTranslationDTOValidator<Product>().ValidateAsync(dto);

            return validations.IsValid ? StatusCode(201, await _productTranslationService.AddAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateTranslationDTO<Product> dto)
        {
            var validations = await new UpdateTranslationDTOValidator<Product>().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _productTranslationService.UpdateAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var dto = new DeleteTranslationDTO { Id = id };
            var validations = await new DeleteTranslationDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _productTranslationService.DeleteAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }
    }
}