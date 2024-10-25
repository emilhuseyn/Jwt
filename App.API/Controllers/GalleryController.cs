using App.API.Controllers.Commons;
using App.Business.DTOs.GalleryDTOs;
using App.Business.Services.InternalServices.Interfaces;
using AppTech.Business.Validators.GalleryValidator;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class GalleryController : BaseController
    {
        private readonly IGalleryService _GalleryService;

        public GalleryController(IGalleryService GalleryService)
        {
            _GalleryService = GalleryService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _GalleryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = new GetByIdGalleryDTO() { Id = id };
            var validations = await new GetByIdGalleryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _GalleryService.GetByIdAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromForm] CreateGalleryDTO dto)
        {
            var validations = await new CreateGalleryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? StatusCode(201, await _GalleryService.AddAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var dto = new DeleteGalleryDTO() { Id = id };
            var validations = await new DeleteGalleryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _GalleryService.DeleteAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGallery([FromForm] UpdateGalleryDTO dto)
        {
            var validations = await new UpdateGalleryDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _GalleryService.UpdateAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

    }

}
