using Services.Contracts.Helpers;

namespace Services.Contracts.Dto.Owner;

public class UpdateOwnerDto
{
    /// <summary>
    /// Тип пользователя
    /// </summary>
    public UserTypeDto userType { get; set; }
    
    /// <summary>
    /// Дата изменения
    /// </summary>
    public DateTime? dateModify { get; set; }
    
    /// <summary>
    /// признак удаления
    /// </summary>
    public bool isDeleted { get; set; } = false;
}