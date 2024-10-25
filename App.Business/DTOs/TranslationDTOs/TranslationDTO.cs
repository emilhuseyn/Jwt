using App.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.TranslationDTOs
{
    public class TranslationDTO<T> where T : BaseEntity
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
    }
}
