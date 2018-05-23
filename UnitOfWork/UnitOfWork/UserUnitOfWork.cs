using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Identity;
using DataLayer.Сontexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly UserContext _context;

        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private readonly RoleManager<User> _roleManager;

        private readonly IConfiguration _configuration;

        public UserUnitOfWork(UserManager<User> userManager, RoleManager<User> roleManager, UserContext context, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public Task Authorization()
        {
            throw new NotImplementedException();
        }

        public Task Resistration()
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>

            {

                new Claim(JwtRegisteredClaimNames.Sub, user.Email),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.NameIdentifier, user.Id),

                new Claim(ClaimTypes.Role, user.Role.Name)

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
