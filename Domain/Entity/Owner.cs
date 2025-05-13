using Domain.Base;
using Domain.Helpers;

namespace Domain.Entity;

public class Owner : IEntity<Guid>
{
    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Тип пользователя
    /// </summary>
    public UserType userType { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime dateCreated { get; set; } = DateTime.Now;
    
    /// <summary>
    /// Дата изменения
    /// </summary>
    public DateTime? dateModify { get; set; }
    
    /// <summary>
    /// признак удаления
    /// </summary>
    public bool isDeleted { get; set; } = false;
}