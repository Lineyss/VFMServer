using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFM.Core.Interfaces;

namespace VFM.Application.Services
{
    public class Hash : IHash
    {
        public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        public bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
