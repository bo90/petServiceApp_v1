using AutoMapper;
using Domain.Entity;
using Services.Contracts.Dto.Beast;

namespace Services.Implementations.Mapping;

public class BeastMappigProfile : Profile
{
    public BeastMappigProfile()
    {
        CreateMap<Domain.Entity.Beast, BeastDto>();

        CreateMap<CreateBeastDto, BeastDto>()
            .ForMember(x => x.dateUpdate, d => d.Ignore())
            .ForMember(x => x.isActual, d => d.Ignore());

        CreateMap<UpdateBeastDto, BeastDto>()
            .ForMember(x => x.Id, d => d.Ignore())
            .ForMember(x => x.OwnerId, d => d.Ignore())
            .ForMember(x => x.dateLoss, d => d.Ignore());
    }
}