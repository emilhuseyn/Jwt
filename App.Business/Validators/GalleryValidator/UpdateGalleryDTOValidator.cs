using App.Business.DTOs.GalleryDTOs;
using App.Business.Validators.Commons;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTech.Business.Validators.GalleryValidator
{
    public class UpdateGalleryDTOValidator : BaseEntityValidator<UpdateGalleryDTO>
    {
        public UpdateGalleryDTOValidator()
        {
            RuleFor(dto => dto.Image)
                .NotEmpty().WithMessage("Image is required.");
  
        }
    }
}
