using App.Business.DTOs.CategoryDTOs;
using App.Business.Validators.Commons;
 
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTech.Business.Validators.CategoryValidator
{
    public class UpdateCategoryDTOValidator : BaseEntityValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(dto => dto.Title)
                  .NotEmpty().WithMessage("Title is required.")
                  .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }
    }
}
