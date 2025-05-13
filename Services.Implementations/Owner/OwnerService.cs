using AutoMapper;
using Services.Abstractions.OwnerService;
using Services.Contracts.Dto.Owner;
using Services.Repositories;

namespace Services.Implementations.Owner;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }
    
    public async Task<OwnerDto> GetOwnerByIdAsync(Guid ownerId)
    {
        return _mapper.Map<Domain.Entity.Owner, OwnerDto>(await _ownerRepository.GetAsync(ownerId));
    }

    public async Task<Guid> CreatNewOwnerAsync(CreateOwnerDto createOwnerDto)
    {
        if(createOwnerDto.Id == Guid.Empty)
            throw new Exception("Передан пустой ид пользователя");
        
        var owner = _mapper.Map<CreateOwnerDto, Domain.Entity.Owner>(createOwnerDto);
        _ownerRepository.Add(owner);
        await _ownerRepository.SaveChangesAsync();
        return owner.Id;
    }

    public async Task UpdateOwnerAsyn(Guid ownerId, UpdateOwnerDto updateOwnerDto)
    {
        if(ownerId == Guid.Empty)
            throw new Exception("Передан пустой ИД Пользователя");
        
        var owner = _mapper.Map<UpdateOwnerDto, Domain.Entity.Owner>(updateOwnerDto);
        owner.dateCreated = DateTime.Now;
        _ownerRepository.Update(owner);
        await _ownerRepository.SaveChangesAsync();
    }

    public async Task DeleteOwnerAsyn(Guid ownerId)
    {
        var owner = _ownerRepository.Get(ownerId);
        _ownerRepository.Delete(owner);
        await _ownerRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<Domain.Entity.Owner>> GetAllOwnersAsync()
    {
        var owners = await _ownerRepository.GetAllAsync();
        return owners;
    }
}