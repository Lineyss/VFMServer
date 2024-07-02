using Microsoft.EntityFrameworkCore;
using VFM.DataAccess.Configuration;
using VFM.DataAccess.Entites;

namespace VFM.DataAccess
{
    public class VFMDbContex : DbContext
    {
        public VFMDbContex(DbContextOptions<VFMDbContex> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<UserEntites> Users { get; set; }
    }
}
