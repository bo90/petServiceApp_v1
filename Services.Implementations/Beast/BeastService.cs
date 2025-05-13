using AutoMapper;
using Services.Abstractions.BeastServices;
using Services.Contracts.Dto.Beast;
using Services.Repositories;

namespace Services.Implementations.Beast;

public class BeastService : IBeastService
{
    private readonly IBeastRepository _repository;
    private readonly IMapper _mapper;

    public BeastService(IBeastRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<BeastDto> GetBeastByIdAsync(Guid beastId)
    {
        if (beastId == Guid.Empty)
            throw new Exception("Передан пустой ИД Животного");
        return _mapper.Map<Domain.Entity.Beast, BeastDto>(await _repository.GetAsync(beastId));
    }

    public async Task<Guid> CreateNewBeastAsync(CreateBeastDto beastDto)
    {
        if(beastDto.OwnerId == Guid.Empty) 
            throw new Exception("Передан пустой ИД пользователя");
        
        if(beastDto.Id == Guid.Empty)
            beastDto.Id = Guid.NewGuid();

        var beast = _mapper.Map<CreateBeastDto, Domain.Entity.Beast>(beastDto);
        _repository.Add(beast);
        await _repository.SaveChangesAsync();
        return beast.Id;
    }

    public async Task UpdateBeastAsyn(Guid beastId, UpdateBeastDto beastDto)
    {
        if (beastDto is null)
            throw new Exception("Передана пустая сущность");

        if (beastId == Guid.Empty)
            throw new Exception("Передан пустой ИД животного");

        var best = await _repository.GetAsync(beastId);
        if(best is null)
            throw new Exception($"По GUID: {beastId} не найдено ни одно животное");

        var updBest = _mapper.Map<UpdateBeastDto, Domain.Entity.Beast>(beastDto);
        updBest.dateUpdate = DateTime.Now;
        _repository.Update(updBest);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteBeastAsync(Guid beastId)
    {
        var beast = await _repository.GetAsync(beastId);
        if (beast is null)
            throw new Exception($"Не удалось найти животного по ID: {beastId}");
        beast.isActual = false;
        beast.dateUpdate = DateTime.Now;
        _repository.Delete(beast);
        await _repository.SaveChangesAsync();
    }

    public async Task<ICollection<Domain.Entity.Beast>> GetAllBeastsAsync()
    {
       var beasts = await _repository.GetAllAsync();
       return beasts;
    }
}