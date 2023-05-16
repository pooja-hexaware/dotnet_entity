using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using AutoMapper;
namespace backend.Api.Middleware
{
public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<HexaMember , HexaMemberDto>(); 
    }
  }
}
