using App.API.Controllers.Commons;
using App.Business.DTOs.TranslationDTOs;
using App.Business.Services.InternalServices.Interfaces;
using App.Business.Validators.TranslationValidator;
using App.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class CategoryTranslationController : BaseController
    {
        private readonly ICategoryTranslationService _categoryTranslationService;

        public CategoryTranslationController(ICategoryTranslationService categoryTranslationService)
        {
            _categoryTranslationService = categoryTranslationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _categoryTranslationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = new GetByIdTranslationDTO { Id = id };
            var validations = await new GetByIdTranslationDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _categoryTranslationService.GetByIdAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromForm] CreateTranslationDTO<Category> dto)
        {
            var validations = await new CreateTranslationDTOValidator<Category>().ValidateAsync(dto);

            return validations.IsValid ? StatusCode(201, await _categoryTranslationService.AddAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateTranslationDTO<Category> dto)
        {
            var validations = await new UpdateTranslationDTOValidator<Category>().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _categoryTranslationService.UpdateAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var dto = new DeleteTranslationDTO { Id = id };
            var validations = await new DeleteTranslationDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _categoryTranslationService.DeleteAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }
    }

}
