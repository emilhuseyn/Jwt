using App.Business.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAllAsync();
        public Task<ProductDTO> GetByIdAsync(GetByIdProductDTO dto);
        public Task<ProductDTO> AddAsync(CreateProductDTO dto);
        public Task<ProductDTO> UpdateAsync(UpdateProductDTO dto);
        public Task<ProductDTO> DeleteAsync(DeleteProductDTO dto);
    }
}
