using App.Business.DTOs.GalleryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface IGalleryService
    {
        public Task<IEnumerable<GalleryDTO>> GetAllAsync();
        public Task<GalleryDTO> GetByIdAsync(GetByIdGalleryDTO dto);
        public Task<GalleryDTO> AddAsync(CreateGalleryDTO dto);
        public Task<GalleryDTO> UpdateAsync(UpdateGalleryDTO dto);
        public Task<GalleryDTO> DeleteAsync(DeleteGalleryDTO dto);
    }
}