namespace VFM.API.Models
{
    // Класс чтобы возвращать не все поля 
    // По стаднарту не все поля нужны для фронта (например id во время создания модели)
    // Для того чтобы под каждый этот случай не создать отдельную модель создается класс record
    public record UsersResponse (Guid id, string Email, string Password);
}
