using App.Business.DTOs.TranslationDTOs;
using App.Core.Entities.Commons;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Validators.TranslationValidator
{
    public class CreateTranslationDTOValidator<T> : AbstractValidator<CreateTranslationDTO<T>> where T : BaseEntity
    {
        public CreateTranslationDTOValidator()
        {
            RuleFor(x => x.EntityId)
                .NotNull().WithMessage("EntityId is required.")
                .GreaterThan(0).WithMessage("EntityId must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(250).WithMessage("Title cannot exceed 250 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Language)
                .NotNull().WithMessage("Language is required.");
        }
    }
}
