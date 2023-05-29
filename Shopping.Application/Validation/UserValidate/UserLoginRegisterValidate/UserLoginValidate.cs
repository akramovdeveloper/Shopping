﻿using FluentValidation;
using Shopping.Application.DTO.UserDto.LoginRegister;

namespace Shopping.Application.Validation.UserValidate.UserLoginRegisterValidate
{
    public class UserLoginValidate:AbstractValidator<UserLogin>
    {
        public UserLoginValidate()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            
        }
    }
}
