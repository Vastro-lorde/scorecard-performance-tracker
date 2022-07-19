using AutoMapper;
using scorecard_performance_tracker.DTOs;
using scorecard_performance_tracker.Models;

namespace scorecard_performance_tracker.Dtos.Mapping
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            CreateMap<ScoreResponseDto, Score>().ReverseMap();
            CreateMap<CreateScoreDto, Score>().ReverseMap();
            CreateMap<UpdateScoreDto, Score>().ReverseMap();
        }
    }
}
