using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kobe.Service.Abstract
{
    public interface IMembershipService
    {
        Task<KobeUser> CreateUser(string username, string email, string password);
        Task<KobeUser> Login(string username, string email, string password);
    }
}
