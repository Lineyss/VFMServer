using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFM.Core.Interfaces
{
    public interface IHash
    {
        string Generate(string password);
        bool Verify(string password, string hashedPassword);
    }
}
