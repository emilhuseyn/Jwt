using App.Business.DTOs.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.ProductDTOs
{
    public class CreateProductDTO:IAuditedEntityDTO
    {
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }
        public double Price { get; set; }
    }
}
