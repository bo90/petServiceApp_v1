using Services.Contracts.Dto.Owner;

namespace Services.Abstractions.OwnerService;

public interface IOwnerService
{
    /// <summary>
    /// Получить пользователя по его ID
    /// </summary>
    /// <param name="ownerId"></param>
    /// <returns></returns>
    Task<OwnerDto> GetOwnerByIdAsync(Guid ownerId);
    
    /// <summary>
    /// Создать нового пользователя в БД
    /// </summary>
    /// <param name="createOwnerDto"></param>
    /// <returns></returns>
    Task<Guid> CreatNewOwnerAsync(CreateOwnerDto createOwnerDto);
    
    /// <summary>
    /// Обновить сведения 
    /// </summary>
    /// <param name="updateOwnerDto"></param>
    /// <returns></returns>
    Task UpdateOwnerAsyn(UpdateOwnerDto updateOwnerDto);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="ownerId"></param>
    /// <returns></returns>
    Task DeleteOwnerAsyn(Guid ownerId);
    /// <summary>
    /// Получить список всех владельцев
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<OwnerDto>> GetAllOwnersAsync();
}