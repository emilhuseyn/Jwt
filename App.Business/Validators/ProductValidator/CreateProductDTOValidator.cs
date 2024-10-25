using App.Business.DTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTech.Business.Validators.ProductValidator
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(dto => dto.Image)
                .NotEmpty().WithMessage("Image is required.");
 
             
            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");             
        }
    }
}
