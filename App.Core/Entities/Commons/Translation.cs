using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Entities.Commons
{
    public class Translation<T> : BaseEntity, IAuditedEntity where T : BaseEntity
    {
        public int EntityId { get; set; }
        public T Entity { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public ELanguage Language { get; set; } 

        // Base Fields
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
