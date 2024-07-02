using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFM.Core.Models;
using VFM.DataAccess.Entites;

namespace VFM.DataAccess.Configuration
{
    // Класс для конфигурации модели в базы данных не обязательно но считается хорошим тоном 
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntites>
    {
        public void Configure(EntityTypeBuilder<UserEntites> builder)
        {
            builder.HasKey(user => user.ID);

            builder.Property(user => user.Email)
                .HasMaxLength(User.MaxEmailLenght)
                .IsRequired()
                .IsUnicode();

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.Property(user => user.Password)
                .HasMaxLength(User.MaxPasswordLenght)
                .IsRequired();
        }
    }
}
