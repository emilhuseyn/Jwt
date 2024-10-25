using App.Core.Entities.Commons;
using App.DAL.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Handlers.Implementations
{
    public class TranslationHandler<T> : Handler<Translation<T>>, ITranslationHandler<T> where T : BaseEntity { }
}
