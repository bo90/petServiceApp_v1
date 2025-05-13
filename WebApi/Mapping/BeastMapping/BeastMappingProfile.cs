using AutoMapper;
using Services.Contracts.Dto.Beast;
using WebApi.Models.BeastModels;

namespace WebApi.Mapping.BeastMapping;

public class BeastMappingProfile : Profile
{
    public BeastMappingProfile()
    {
        CreateMap<BeastDto, ViewBeastModel>();
        CreateMap<CreateBeastDto, CreatingBeastModel>();
        CreateMap<UpdateBeastDto, UpdatingBeastModel>();
    }
}