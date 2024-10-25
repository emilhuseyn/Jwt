using App.Core.Entities.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.GalleryDTOs
{
    public class GalleryDTO:BaseEntity
    {
        public string Image { get; set; }
    }
}
