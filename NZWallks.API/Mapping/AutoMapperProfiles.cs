using AutoMapper;
using NZWalks.API.Models.DTO;
using NZWallks.API.Models.Domain;
using NZWallks.API.Models.DTO;


namespace NZWallks.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Region Maping
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            // Walk Maping
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            // Difficulty Maping
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            
        }
    }
}
