using App.Business.DTOs.SettingDTOs;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities;
using App.DAL.Handlers.Interfaces;
using App.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class SettingService : ISettingService
    {
        protected readonly ISettingRepository _settingRepository;
        protected readonly ISettingHandler _settingHandler;
        protected readonly IMapper _mapper;

        public SettingService(ISettingRepository settingRepository, IMapper mapper, IConfiguration configuration, ISettingHandler settingHandler)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
            _settingHandler = settingHandler;
        }

        public async Task<IEnumerable<SettingDTO>> GetAllAsync()
        {
            var entities = (await _settingRepository.GetAllAsync(x => !x.IsDeleted))
                .Select(e => new SettingDTO
                {
                    Id = e.Id,
                    Key = e.Key,
                    Value = e.Value
                });

            return entities;
        }

        public async Task<SettingDTO> GetByIdAsync(GetByIdSettingDTO dto)
        {
            var entity = _settingHandler.HandleEntityAsync(
                await _settingRepository.GetByIdAsync(x => x.Id == dto.Id));

            return new SettingDTO
            {
                Id = entity.Id,
                Key = entity.Key,
                Value = entity.Value
            };
        }

        public async Task<SettingDTO> AddAsync(CreateSettingDTO dto)
        {
            var entity = await _settingRepository.AddAsync(_mapper.Map<Setting>(dto));

            return new SettingDTO
            {
                Id = entity.Id,
                Key = entity.Key,
                Value = entity.Value
            };
        }

        public async Task<SettingDTO> DeleteAsync(DeleteSettingDTO dto)
        {
            var entity = await _settingRepository.DeleteAsync(
                _settingHandler.HandleEntityAsync(
                    await _settingRepository.GetByIdAsync(x => x.Id == dto.Id)));

            return new SettingDTO
            {
                Id = entity.Id,
                Key = entity.Key,
                Value = entity.Value
            };
        }

        public async Task<SettingDTO> UpdateAsync(UpdateSettingDTO dto)
        {
            var entity = await _settingRepository.UpdateAsync(
                _mapper.Map(dto,
                _settingHandler.HandleEntityAsync(
                    await _settingRepository.GetByIdAsync(x => x.Id == dto.Id))));

            return new SettingDTO
            {
                Id = entity.Id,
                Key = entity.Key,
                Value = entity.Value
            };
        }
    }
}
