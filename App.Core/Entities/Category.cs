using App.Core.Entities.Commons;
using System;
using System.Collections.Generic;

namespace App.Core.Entities
{
    public class Category : BaseEntity, IAuditedEntity
    {
        public int? ParentCategoryId { get; set; }
        
        public Category ParentCategory { get; set; } 
        public ICollection<Product> Products { get; set; }
        public ICollection<Category>? SubCategories { get; set; } 
        public ICollection<Translation<Category>> Translations { get; set; }

        // Base Fields
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
