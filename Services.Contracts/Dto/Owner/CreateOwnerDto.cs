using Services.Contracts.Helpers;

namespace Services.Contracts.Dto.Owner;

public class CreateOwnerDto
{
    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Тип пользователя
    /// </summary>
    public UserTypeDto userType { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime dateCreated { get; set; } = DateTime.Now;
    
}