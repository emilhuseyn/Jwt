using App.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Interfaces
{
    public interface ITranslationRepository<T> : IRepository<Translation<T>> where T : BaseEntity { }
}
