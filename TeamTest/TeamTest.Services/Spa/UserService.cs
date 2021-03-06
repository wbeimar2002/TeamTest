﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using TeamTest.Models.Payloads;
using TeamTest.Repositories.Repositories;
using TeamTest.Services.Helpers;
using TeamTest.Services.Interfaces;

namespace TeamTest.Services.Spa
{
    public class UserService : IUserService
    {
        private readonly ISpaRepository<User> _userRepository;
        private readonly AppSettingsDto _appSettings;
        public UserService(ISpaRepository<User> spaRepository, IOptions<AppSettingsDto> appSettings)
        {
            _userRepository = spaRepository;
            _appSettings = appSettings.Value;

        }

        public UserDto Authenticate(UserPayload userPayload)
        {
            try
            {
                var user = this.GetUser(userPayload);

                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecureKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user.WithoutPassword();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private UserDto GetUser(UserPayload userPayload)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == userPayload.UserName && x.Password == userPayload.PassWord);
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
