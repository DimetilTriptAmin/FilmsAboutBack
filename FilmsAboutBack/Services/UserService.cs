﻿using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.DataAccess.UnitOfWork.Interfaces;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using FilmsAboutBack.TokenGenerators;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FilmsAboutBack.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtGenerator _generator;

        public UserService(
            IUnitOfWork unitOfWork, 
            UserManager<User> userManager,
            JwtGenerator generator
            ) : base(unitOfWork)
        {
            _userManager = userManager;
            _generator = generator;
        }

        public async Task<GenericResponse<UserResponse>> GetUserAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetAsync(id);

                if (user == null)
                {
                    return new GenericResponse<UserResponse>("User not found.", HttpStatusCode.NotFound);
                }

                UserResponse userResponse = new UserResponse()
                { Avatar = user.Avatar, Email = user.Email, UserName = user.UserName };

                return new GenericResponse<UserResponse>(userResponse, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<UserResponse>("Server is offline.", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<GenericResponse<LoginResponse>> LoginUserAsync(LoginRequest loginRequest)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(loginRequest.Username);

                if (user == null)
                {
                    return new GenericResponse<LoginResponse>("No such username.", HttpStatusCode.BadRequest);
                }

                var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

                if (!isPasswordCorrect)
                {
                    return new GenericResponse<LoginResponse>("Password does not match.", HttpStatusCode.BadRequest);
                }

                LoginResponse response = AuthorizeUser(user);
                
                user.refreshToken = response.RefreshToken;
                await _userManager.UpdateAsync(user);

                return new GenericResponse<LoginResponse>(response, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<LoginResponse>("Server is offline.", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<GenericResponse<bool>> LogoutAsync(int id)
        {
            try
            {
                User user = await _unitOfWork.UserRepository.GetAsync(id);

                if (user == null)
                {
                    return new GenericResponse<bool>("Invalid token.", HttpStatusCode.BadRequest);
                }

                user.refreshToken = "";
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return new GenericResponse<bool>(true, HttpStatusCode.BadRequest); ;
            }
            catch
            {
                return new GenericResponse<bool>("Server is offline.", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<GenericResponse<LoginResponse>> RefreshAsync(string token)
        {
            try
            {
                var request = await _unitOfWork.UserRepository.Filter(user => user.refreshToken == token);

                var user = request.FirstOrDefault();

                if (user == null)
                {
                    return new GenericResponse<LoginResponse>("Invalid token.", HttpStatusCode.BadRequest);
                }

                LoginResponse response = AuthorizeUser(user);
                user.refreshToken = response.RefreshToken;
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return new GenericResponse<LoginResponse>(response, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<LoginResponse>("Server is offline.", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<GenericResponse<LoginResponse>> RegisterUserAsync(RegisterRequest registerRequest)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(registerRequest.Username);
                if (user != null)
                {
                    return new GenericResponse<LoginResponse>("This username is taken.", HttpStatusCode.BadRequest);
                }

                user = await _userManager.FindByEmailAsync(registerRequest.Email);
                if (user != null)
                {
                    return new GenericResponse<LoginResponse>("This email is registered.", HttpStatusCode.BadRequest);

                }

                if (registerRequest.Password != registerRequest.ConfirmPassword)
                {
                    return new GenericResponse<LoginResponse>("Passwords must be equal.", HttpStatusCode.BadRequest);
                }

                user = new User()
                {
                    UserName = registerRequest.Username,
                    Email = registerRequest.Email,
                };

                var result = await _userManager.CreateAsync(user, registerRequest.Password);
                LoginResponse response = AuthorizeUser(user);
                user.refreshToken = response.RefreshToken;
                await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return new GenericResponse<LoginResponse>(string.Join(",", result.Errors.Select(e => e.Description)),
                        HttpStatusCode.BadRequest);
                }

                return new GenericResponse<LoginResponse>(response, HttpStatusCode.OK);
            }
            catch
            {
                return new GenericResponse<LoginResponse>("Server is offline.", HttpStatusCode.InternalServerError);
            }
        }

        private LoginResponse AuthorizeUser(User user)
        {
            var accessToken = _generator.GenerateAccessToken(user);
            var refreshToken = _generator.GenerateRefreshToken();

            return new LoginResponse(accessToken, refreshToken);
        }
    }
}
