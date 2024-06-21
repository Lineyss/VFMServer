using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFM.Core.Models
{
    // Модель бизнес логики
    public class User
    {
        // Константы для максимальной длинны почты и пароля
        public const int MaxEmailLenght = 250;
        public const int MaxPasswordLenght = 250;

        // Приватный конструктор чтобы никто из вне не мог создать экземпляр класса
        private User(Guid id, string Email, string Password)
        {
            this.ID = id;
            this.Email = Email;
            this.Password = Password;
        }

        public Guid ID { get; }
        public string Email { get; } = string.Empty;
        public string Password { get;} = string.Empty;

        // Статаический конструктор который возвращает картеж созданного пользователя и ошибки
        public static (User user, string Error) Create(Guid id, string Email, string Password)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(Email) || Email.Length > MaxEmailLenght)
            {
                error = "Длинна почты не может быть больше 250 символов";
            }

            var user = new User(id, Email, Password);

            return (user, error);
        }
    }
}
