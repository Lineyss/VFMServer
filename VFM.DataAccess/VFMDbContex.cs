using Microsoft.EntityFrameworkCore;
using VFM.DataAccess.Entites;

namespace VFM.DataAccess
{
    public class VFMDbContex : DbContext
    {
        public VFMDbContex(DbContextOptions<VFMDbContex> options) : base(options)
        {
            
        }

        public DbSet<UserEntites> Users { get; set; }
    }
}
