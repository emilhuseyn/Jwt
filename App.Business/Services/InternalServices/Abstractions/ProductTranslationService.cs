using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities;
using App.DAL.Handlers.Interfaces;
using App.DAL.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class ProductTranslationService : TranslationService<Product>, IProductTranslationService
    {
        public ProductTranslationService(
            ITranslationRepository<Product> translationRepository,
            IMapper mapper,
            ITranslationHandler<Product> translationHandler)
            : base(translationRepository, mapper, translationHandler) { }
    }
}
