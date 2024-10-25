using App.Business.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.ContactUsDTOs
{
    public class UpdateContactUsDTO:BaseEntityDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string Message { get; set; }
    }
}
