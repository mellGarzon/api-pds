using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PDS.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using PDS.Domain.Interfaces.ServiceInterfaces;

namespace PDS.Services.Services
{
	public static class AuthService
	{

        public static bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHash);
            byte[] saltBytes = Convert.FromBase64String(passwordSalt);
            using (var hmac = new HMACSHA512(saltBytes))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(hashBytes);
            }
        }



        public static (string hash, string salt) CreatePasswordHash(string password)
        {
            byte[] salt;
            byte[] hash;
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

    }
}

