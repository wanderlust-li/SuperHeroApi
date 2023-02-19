namespace SuperHeroApi.Models;

public class SuperHero
{
    // рядок визначає загальнодоступну цілочисельну властивість під назвою Id,
    // яка має як метод отримання, так і параметр встановлення. Ця властивість представляє унікальний ідентифікатор для об’єкта SuperHero.
    public int Id { get; set; }
    
    // містить як getter, так і setter, і встановлює значення за замовчуванням у порожній рядок
    public string Name { get; set; } = string.Empty;
    
    // містить як getter, так і setter, і встановлює значення за замовчуванням у порожній рядок
    public string FirstName { get; set; } = string.Empty;
    
    // містить як getter, так і setter, і встановлює значення за замовчуванням у порожній рядок
    public string LastName { get; set; } = string.Empty;
    
    // містить як getter, так і setter, і встановлює значення за замовчуванням у порожній рядок
    public string Place { get; set; } = string.Empty;
    
    // Таким чином, цей код визначає структуру об’єкта SuperHero з його властивостями.
    // Ці властивості можна використовувати для зберігання та отримання інформації про супергероя.
}