using App.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Handlers.Interfaces
{
    public interface ITranslationHandler<T> : IHandler<Translation<T>> where T : BaseEntity { }
}
