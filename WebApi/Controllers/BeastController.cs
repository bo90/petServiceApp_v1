using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.BeastServices;
using Services.Contracts.Dto.Beast;
using WebApi.Models.BeastModels;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BeastController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IBeastService _service;
    private readonly IMapper _mapper;

    public BeastController(IBeastService service,
        IMapper mapper,
        ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Создать запись о животном
    /// </summary>
    /// <param name="beastModel">модель на вход</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost(Name = "CreateBeast")]
    public async Task<IActionResult> CreateNewBeastToDatabaseAsync(CreatingBeastModel beastModel)
    {
        try
        {
            _logger.LogInformation("Начало процесса создания новой записи в БД по животному.");
            if (beastModel is null)
            {
                _logger.LogCritical("Переданы пустые параметры");
                throw new Exception("Переданы пустые параметры");
            }

            if(beastModel.Id == Guid.Empty)
                beastModel.Id = Guid.NewGuid();

            var beast = _mapper.Map<CreatingBeastModel, CreateBeastDto>(beastModel);
            await _service.CreateNewBeastAsync(beast);
            _logger.LogInformation($"Запись успешно создана. GUID: {beast.Id}");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }
}