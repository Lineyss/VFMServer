using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFM.Core.Models;
using VFM.Core.Interfaces;
using VFM.DataAccess.Entites;

namespace VFM.DataAccess.Repositories
{
    // Репозиторий для создания CRUD операций над моделью
    public class UserRepository : IUserRepository
    {
        private readonly VFMDbContex context;
        public UserRepository(VFMDbContex context)
        {
            this.context = context;
        }

        public async Task<User?> GetByEmail(string Email)
        {
            UserEntites? user = await context.Users
                .FirstOrDefaultAsync(user => user.Email == Email);

            return user == null ? null : User.Create(user.ID, user.Email, user.Password).user;
        }

        public async Task<List<User>> Get()
        {
            // AsNoTracking - методя который позволяет не отслеживать изменения над моделью
            // Когда данные берутся из бд то entity framework помещает их в кэш чтобы следить за их изменениями
            // Чтобы избежать этого в тех случаях когда мы точно не будем изменять модели используется этот метод
            var userEntites = await context.Users.AsNoTracking().ToListAsync();

            var users = userEntites
                .Select(element => User.Create(element.ID, element.Email, element.Password).user)
                .ToList();

            return users;
        }

        public async Task<Guid> Create(User user)
        {
            var usersEntity = new UserEntites
            {
                ID = user.ID,
                Email = user.Email,
                Password = user.Password
            };

            await context.Users.AddAsync(usersEntity);
            await context.SaveChangesAsync();

            return usersEntity.ID;
        }

        public async Task<Guid> Update(Guid id, string Email, string Password)
        {
            await context.Users
                .Where(element => element.ID == id)
                // ExecuteUpdateAsync - метод который позволяет обновлять модель без получения ее экземпляра и изменения каждой переменной
                .ExecuteUpdateAsync(element=> element
                    .SetProperty(prop => prop.Email, prop => Email)
                    .SetProperty(prop => prop.Password, prop => Password));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await context.Users
                .Where(element => element.ID == id)
                .ExecuteDeleteAsync();

            return id;
        }

    }
}
