using Kobe.Data.Extensions;
using Kobe.Data.Repository;
using Kobe.Domain.Entities;
using Kobe.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kobe.Service.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IAuthRepository _authRepository;

        public MembershipService(IEntityBaseRepository<KobeUser> userRepository, IEncryptionService encryptionService,
            IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<KobeUser> CreateUser(string username, string email, string password)
        {           
            return await _authRepository.CreateUser(username, email, password);
        }

        public async Task<KobeUser> Login(string username, string email, string password)
        {            
            return await _authRepository.Login(username, email, password);
        }

        private bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {           
            return true;
        }
    }
}
