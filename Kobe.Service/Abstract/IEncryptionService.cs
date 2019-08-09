using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Service.Abstract
{
    public interface IEncryptionService
    {
        string CreateSalt();
        string EncryptPassword(string password, string salt);
    }
}
