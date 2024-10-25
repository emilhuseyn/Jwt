using App.Business.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllAsync();
        public Task<CategoryDTO> GetByIdAsync(GetByIdCategoryDTO dto);
        public Task<CategoryDTO> AddAsync(CreateCategoryDTO dto);
        public Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO dto);
        public Task<CategoryDTO> DeleteAsync(DeleteCategoryDTO dto);
    }
}
