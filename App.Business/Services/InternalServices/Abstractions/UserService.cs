using App.Business.DTOs.UserDTOs;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
            
        public async Task<RegisterUserDTO> Register(RegisterUserDTO registerUserDTO)
        {
            var result = await _userManager.FindByNameAsync(registerUserDTO.Username);
            if (result is not null) 
            {
                throw new ArgumentException();
            }
            var response =  await _userManager.CreateAsync(new User()
            {
                Name=registerUserDTO.Name,
                Surname=registerUserDTO.Surname,
                Email=registerUserDTO.Email,
                UserName=registerUserDTO.Username,
            },registerUserDTO.Password);

            if(response.Succeeded == false)
            {
                throw new Exception();
            }
            return registerUserDTO;
        }


        public async Task<UserTokenDTO> Login(LoginUserDTO loginUserDTO)
        {
            var result = await _userManager.FindByNameAsync(loginUserDTO.Username);
            if (result is null)
            {
                throw new ArgumentException();
            }
            var response = await _userManager.CheckPasswordAsync(result, loginUserDTO.Password);

            if(response is false)
            {
                throw new Exception();
            }
            return new UserTokenDTO()
            {

            };

        }

    }
}