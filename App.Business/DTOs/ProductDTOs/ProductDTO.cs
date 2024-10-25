using App.Business.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.DTOs.ProductDTOs
{
    public class ProductDTO : BaseEntityDTO
    {
        public string CategoryName { get; set; }
        public string CateDescription { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
    }
}
