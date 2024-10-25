using App.Business.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.CategoryDTOs
{
    public class CategoryDTO:BaseEntityDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryDTO> SubCategories { get; set; }
    }
}
