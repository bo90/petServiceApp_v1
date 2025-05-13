using AutoMapper;
using Domain.Entity;
using Services.Contracts.Dto.Owner;

namespace Services.Implementations.Mapping;

public class OwnerMappingProfile : Profile
{
    public OwnerMappingProfile()
    {
        CreateMap<Domain.Entity.Owner, OwnerDto>();
        
        CreateMap<CreateOwnerDto, Domain.Entity.Owner>()
            .ForMember(x=>x.isDeleted,d=>d.Ignore())
            .ForMember(x=>x.dateModify,d=>d.Ignore());
        
        CreateMap<UpdateOwnerDto, Domain.Entity.Owner>()
            .ForMember(x=>x.Id, d=>d.Ignore())
            .ForMember(x=>x.dateCreated, d=>d.Ignore());
    }
}