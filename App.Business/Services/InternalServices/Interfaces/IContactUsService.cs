using App.Business.DTOs.ContactUsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface IContactUsService
    {
        public Task<IEnumerable<ContactUsDTO>> GetAllAsync();
        public Task<ContactUsDTO> GetByIdAsync(GetByIdContactUsDTO dto);
        public Task<ContactUsDTO> AddAsync(CreateContactUsDTO dto);
        public Task<ContactUsDTO> UpdateAsync(UpdateContactUsDTO dto);
        public Task<ContactUsDTO> DeleteAsync(DeleteContactUsDTO dto);
    }
}
