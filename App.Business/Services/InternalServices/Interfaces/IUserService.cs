using App.Business.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserDTO> Register(RegisterUserDTO registerUserDTO);
        Task<UserTokenDTO> Login(LoginUserDTO loginUserDTO);
    }
}
