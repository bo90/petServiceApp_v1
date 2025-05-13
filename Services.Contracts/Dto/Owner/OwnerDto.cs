using Services.Contracts.Helpers;

namespace Services.Contracts.Dto.Owner;

public class OwnerDto
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
    public DateTime dateCreated { get; set; }
    
    /// <summary>
    /// Дата изменения
    /// </summary>
    public DateTime? dateModify { get; set; }
    
    /// <summary>
    /// признак удаления
    /// </summary>
    public bool isDeleted { get; set; } 
}