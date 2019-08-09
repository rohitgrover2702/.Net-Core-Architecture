using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Kobe.Data.Extensions;
using Kobe.Domain.Entities;

namespace Kobe.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IEntityBaseRepository<KobeUser> _userRepository;
        public AuthRepository(IEntityBaseRepository<KobeUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<KobeUser> CreateUser(string username, string email, string password)
        {
            var existingUser = await _userRepository.GetSingleByUsernameorEmail(username, email);
            if (existingUser != null)
            {
                if (existingUser.Username == username)
                    throw new Exception("Username is already in use");
                else
                    throw new Exception("Email is already in use");

            }
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new KobeUser()
            {
                HashedPassword = passwordHash,
                Salt = passwordSalt,
                Email = email,
                Username = username,
                IsLocked = false,
            };
            _userRepository.Add(user);
            return user;
        }

        public async Task<KobeUser> Login(string username, string email, string password)
        {
            var user = await _userRepository.GetSingleByUsernameorEmail(username, email);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.HashedPassword, user.Salt))
                return null;

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
