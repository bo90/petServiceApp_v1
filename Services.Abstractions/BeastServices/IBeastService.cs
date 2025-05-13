using Services.Contracts.Dto.Beast;

namespace Services.Abstractions.BeastServices;

public interface IBeastService
{
    /// <summary>
    /// Получить животного по его ИД
    /// </summary>
    /// <param name="beastId"></param>
    /// <returns></returns>
    Task<BeastDto> GetBeastByIdAsync(Guid beastId);
    
    /// <summary>
    /// Создать новую запись по пропавшему животному
    /// </summary>
    /// <param name="beastDto"></param>
    /// <returns></returns>
    Task<Guid> CreateNewBeastAsync(CreateBeastDto beastDto);

    /// <summary>
    /// Обновить запись по пропавшему животному
    /// </summary>
    /// <param name="beastDto"></param>
    /// <returns></returns>
    Task UpdateBeastAsyn(UpdateBeastDto beastDto);
    
    /// <summary>
    /// Удалить запись по пропавшему животному
    /// </summary>
    /// <param name="beastId"></param>
    /// <returns></returns>
    Task DeleteBeastAsync(Guid beastId);
    
    /// <summary>
    /// Получить список всех пропавших животных
    /// </summary>
    /// <returns></returns>
    Task<ICollection<BeastDto>> GetAllBeastsAsync();
}