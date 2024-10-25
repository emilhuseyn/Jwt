using App.API.Controllers.Commons;
using App.Business.DTOs.CategoryDTOs;
using App.Business.Services.InternalServices.Interfaces;
using AppTech.Business.Validators.CategoryValidator;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _CategoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = new GetByIdCategoryDTO() { Id = id };
            var validations = await new GetByIdCategoryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _CategoryService.GetByIdAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromForm] CreateCategoryDTO dto)
        {
            var validations = await new CreateCategoryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? StatusCode(201, await _CategoryService.AddAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var dto = new DeleteCategoryDTO() { Id = id };
            var validations = await new DeleteCategoryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _CategoryService.DeleteAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDTO dto)
        {
            var validations = await new UpdateCategoryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _CategoryService.UpdateAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }
    }
}
