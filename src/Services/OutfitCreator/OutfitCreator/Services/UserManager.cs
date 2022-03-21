﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OutfitCreator;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions;

namespace OutfitCreator.Services
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private UserManager<IdentityUser> userManager;
        private IConfiguration configuration;
        private readonly ITokenBuilder tokenBuilder;

        public UserManager(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager,
            IConfiguration configuration, ITokenBuilder tokenBuilder)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenBuilder = tokenBuilder;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var userExist = await userManager.FindByEmailAsync(model.Email);
            if (userExist != null)
                throw new ArgumentException("Email already exist in system.");

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
            };

            try
            {
                var result = await userManager.CreateAsync(identityUser, model.Password);
                var playerId = Guid.NewGuid();

                if (result.Succeeded)
                {
                    return new UserManagerResponse
                    {
                        Message = "User created successfully!",
                        IsSuccess = true
                    };

                }

                return new UserManagerResponse
                {
                    Message = "User did not create",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            try
            {
                var result = await userManager.CheckPasswordAsync(user, model.Password);

                if (!result)
                    return new UserManagerResponse
                    {
                        Message = "Invalid password",
                        IsSuccess = false,
                    };

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, model.Email)
                };

                var token = tokenBuilder.GetToken(claims).Result;

                return new UserManagerResponse
                {
                    Message = "Token generated successfully",
                    Token = token.TokenAsString,
                    IsSuccess = true,
                    ExpireDate = token.ValidTo
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserManagerResponse> SignOutUserAsync()
        {
            try
            {
                await httpContextAccessor.HttpContext.SignOutAsync().ConfigureAwait(false);

                return new UserManagerResponse
                {
                    Message = "User signed out successfully",
                    Token = string.Empty,
                    IsSuccess = true,
                    ExpireDate = null
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
