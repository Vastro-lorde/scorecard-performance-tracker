using scorecard_performance_tracker.DTOs;
using scorecard_performance_tracker.Models;
using scorecard_performance_tracker.Utilities.Pagination;

namespace scorecard_performance_tracker.Services
{
    public interface IScoreServices
    {
        Task<Response<Score>> CreateScoreAsync(CreateScoreDto createScore);
        Task<Response<Score>> DeleteScoreAsync(string ScoreId);
        Task<Response<PaginationModel<IEnumerable<ScoreResponseDto>>>> GetAllScoresAsync(int pageSize, int pageNumber);
        Task<Response<ScoreResponseDto>> GetScoreByIdAsync(string ScoreId);
        Task<Response<PaginationModel<IEnumerable<ScoreResponseDto>>>> GetScoresByNameAsync(int pageSize, int pageNumber, string DevName);
        Task<Response<Score>> UpdateScoreDetails(string ScoreId, UpdateScoreDto updateScore);
    }
}