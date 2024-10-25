using App.Business.DTOs.TranslationDTOs;
using App.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface ITranslationService<T> where T : BaseEntity
    {
        Task<IQueryable<TranslationDTO<T>>> GetAllAsync();
        Task<TranslationDTO<T>> GetByIdAsync(GetByIdTranslationDTO dto);
        Task<TranslationDTO<T>> AddAsync(CreateTranslationDTO<T> dto);
        Task<TranslationDTO<T>> UpdateAsync(UpdateTranslationDTO<T> dto);
        Task<TranslationDTO<T>> DeleteAsync(DeleteTranslationDTO dto);
    }
}
