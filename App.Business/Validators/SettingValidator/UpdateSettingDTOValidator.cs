
using App.Business.DTOs.SettingDTOs;
using App.Business.Validators.Commons;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTech.Business.Validators.SettingValidator
{
	public class UpdateSettingDTOValidator : BaseEntityValidator<UpdateSettingDTO>
	{
		public UpdateSettingDTOValidator()
		{
			//RuleFor(dto => dto.Key).Cascade(CascadeMode.Stop)
			//	.NotEmpty().WithMessage("Key field is required.");
		}
	}
 }
