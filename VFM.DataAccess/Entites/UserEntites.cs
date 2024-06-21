using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFM.DataAccess.Entites
{
    // Модель базы данных
    public class UserEntites
    {
        public Guid ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
