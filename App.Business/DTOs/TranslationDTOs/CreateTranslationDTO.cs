using App.Core.Entities.Commons;
using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.TranslationDTOs
{
    public class CreateTranslationDTO<T> where T : BaseEntity
    {
        public int EntityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ELanguage Language { get; set; }
    }
}
