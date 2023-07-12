using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PDS.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PDS.Domain.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace PDS.Services.Services
{
	public class TokenService: ITokenService
	{

        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;

        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public long GetUserId()
        {
            string token = _httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenObj = tokenHandler.ReadJwtToken(token);

            var userIdStr = tokenObj.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            long userId;
            if (string.IsNullOrEmpty(userIdStr) || !long.TryParse(userIdStr, out userId))
            {
                // caso o valor da string não possa ser convertido para long
                throw new Exception("Não foi possível obter o ID do usuário.");
            }

            // Retorna as informações do usuário
            return userId;
        }


        public string GetUserRole()
        {
            string token = _httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenObj = tokenHandler.ReadJwtToken(token);

            var role = tokenObj.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            return role;
        }


        public string CreateToken(long userId, string role)
        {
            List<Claim> claims = new List<Claim>
            {
             
                new Claim("id", userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

