using App.Business.DTOs.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.GalleryDTOs
{
    public class CreateGalleryDTO : IAuditedEntityDTO
    {
        public IFormFile Image { get; set; }
    }
}
