using App.Business.DTOs.SettingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface ISettingService
    {
        public Task<IEnumerable<SettingDTO>> GetAllAsync();
        public Task<SettingDTO> GetByIdAsync(GetByIdSettingDTO dto);
        public Task<SettingDTO> AddAsync(CreateSettingDTO dto);
        public Task<SettingDTO> UpdateAsync(UpdateSettingDTO dto);
        public Task<SettingDTO> DeleteAsync(DeleteSettingDTO dto);
    }
}
