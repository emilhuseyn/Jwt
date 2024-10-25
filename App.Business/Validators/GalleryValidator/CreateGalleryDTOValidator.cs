using App.Business.DTOs.GalleryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTech.Business.Validators.GalleryValidator
{
    public class CreateGalleryDTOValidator : AbstractValidator<CreateGalleryDTO>
    {
        public CreateGalleryDTOValidator()
        {
            RuleFor(dto => dto.Image)
                     .NotEmpty().WithMessage("Image is required.");
        }
    }
}
