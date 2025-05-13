using AutoMapper;
using Services.Abstractions.BeastServices;
using Services.Contracts.Dto.Beast;
using Services.Repositories;

namespace Services.Implementations.Beast;

public class BeastMongoService : IBeastService
{
    private readonly IBeastRepository _repository;
    private readonly IMapper _mapper;

    public BeastMongoService(IBeastRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<BeastDto> GetBeastByIdAsync(Guid beastId)
    {
        return _mapper.Map<Domain.Entity.Beast, BeastDto>(await _repository.GetByIdAsync(beastId));
    }

    public async Task<Guid> CreateNewBeastAsync(CreateBeastDto beastDto)
    {
        var beast = _mapper.Map<CreateBeastDto, Domain.Entity.Beast>(beastDto);
        await _repository.AddAsync(beast);
        return beast.Id;
    }

    public async Task UpdateBeastAsyn(Guid beastId, UpdateBeastDto beastDto)
    {
        var beast = await _repository.GetByIdAsync(beastId);
        if (beast is null)
            throw new Exception($"Не удалось найти животное в БД, по ИД: {beastId}");
        beast.dateUpdate = DateTime.Now;
        await _repository.UpdateAsync(beastId, beast);
    }

    public async Task DeleteBeastAsync(Guid beastId)
    {
        var beast = await _repository.GetByIdAsync(beastId);
        if (beast is null)
            throw new Exception($"Не удалось найти животное с ID: {beastId}");
        
        beast.isActual = false;
        await _repository.DeleteAsync(beastId);
    }

    public async Task<ICollection<Domain.Entity.Beast>> GetAllBeastsAsync()
    {
        var beasts = await _repository.GetAllAsync();
        return (ICollection<Domain.Entity.Beast>)beasts;
    }
}