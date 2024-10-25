using App.API.Controllers.Commons;
using App.Business.DTOs.SettingDTOs;
using App.Business.Services.InternalServices.Interfaces;
using AppTech.Business.Validators.SettingValidator;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class SettingController : BaseController
    {
        private readonly ISettingService _SettingService;

        public SettingController(ISettingService SettingService)
        {
            _SettingService = SettingService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _SettingService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = new GetByIdSettingDTO() { Id = id };
            var validations = await new GetByIdSettingDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _SettingService.GetByIdAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromForm] CreateSettingDTO dto)
        {
            var validations = await new CreateSettingDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? StatusCode(201, await _SettingService.AddAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSetting(int id)
        {
            var dto = new DeleteSettingDTO() { Id = id };
            var validations = await new DeleteSettingDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _SettingService.DeleteAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSetting([FromForm] UpdateSettingDTO dto)
        {
            var validations = await new UpdateSettingDTOValidator().ValidateAsync(dto);

            return validations.IsValid ? Ok(await _SettingService.UpdateAsync(dto)) :
                BadRequest(new { Errors = validations.Errors.Select(e => e.ErrorMessage).ToList() });
        }

    }

}
