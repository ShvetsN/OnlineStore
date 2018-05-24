using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Identity;
using DataLayer.Сontexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;

namespace UnitOfWork.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;


        public UserUnitOfWork(SignInManager<User> signInManager, UserManager<User> userManager, 
            IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> AuthorizationAsync(LoginUser loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);
            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == loginUser.Email);
                var token = await GenerateToken(appUser);

                return token;
            }
            throw new ApplicationException("LOGIN ERROR");
        }
       
        public async Task<string> RegistrationAsync(RegistrationUser rUser)
        {

            var user = _mapper.Map<User>(rUser);
            user.UserName = rUser.Email;

            
            var result = await _userManager.CreateAsync(user, rUser.Password);

            if (result.Succeeded)

            {
                var u = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(u, "User");
                await _signInManager.SignInAsync(user, false);

                return await GenerateToken(user);

            }

            throw new ApplicationException("REGISTRATION ERROR");
        }

        public Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>

            {

                new Claim(JwtRegisteredClaimNames.Sub, user.Email),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.NameIdentifier, user.Id)

                //new Claim(ClaimTypes.Role, user.Role.Name)

            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));



            var token = new JwtSecurityToken(

                _configuration["JwtIssuer"],

                _configuration["JwtIssuer"],

                claims,

                expires: expires,

                signingCredentials: creds

            );



            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
