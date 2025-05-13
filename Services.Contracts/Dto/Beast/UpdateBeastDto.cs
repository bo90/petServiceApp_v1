using Services.Contracts.Helpers;

namespace Services.Contracts.Dto.Beast;

public class UpdateBeastDto
{
    /// <summary>
    /// Кличка
    /// </summary>
    public string nickName { get; set; }
    
    /// <summary>
    /// Тип животного
    /// </summary>
    public BeastTypeDto beastType { get; set; }
    
    /// <summary>
    /// Дата пропажи
    /// </summary>
    public DateTime dateLoss { get; set; }
    
    /// <summary>
    /// рост
    /// </summary>
    public int height { get; set; }
    
    /// <summary>
    /// Ширина
    /// </summary>
    public int width { get; set; }
    
    /// <summary>
    /// цвет
    /// </summary>
    public string color { get; set; }
    
    /// <summary>
    /// Особые приметы
    /// </summary>
    public string specialSign { get; set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string description { get; set; }

    /// <summary>
    /// Актуальность поиска
    /// </summary>
    public bool isActual { get; set; } = true;
    
    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime? dateUpdate { get; set; }
}