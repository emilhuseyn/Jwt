using App.Core.Entities.Commons;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implementations
{
    public class TranslationRepository<T> : Repository<Translation<T>>, ITranslationRepository<T> where T : BaseEntity
    {
        public TranslationRepository(AppDbContext context) : base(context) { }
    }
}
