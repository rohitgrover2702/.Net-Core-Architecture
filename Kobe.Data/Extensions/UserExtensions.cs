using Kobe.Data.Repository;
using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobe.Data.Extensions
{
    public static class UserExtensions
    {
        public static async Task<KobeUser> GetSingleByUsernameorEmail(this IEntityBaseRepository<KobeUser> userRepository, string username, string email)
        {
            return await userRepository.GetAll().FirstOrDefaultAsync(x => x.Username == username || x.Email == email);
        }
    }
}
