using scorecard_performance_tracker.Models;

namespace scorecard_performance_tracker.Repository
{
    public interface IScoreRepository
    {
        Task<bool> CreateScoreAsync(Score score);
        Task<bool> DeleteScore(Score request);
        Task<List<Score>> GetAllScoresAsync();
        Task<Score> GetScoreByIdAsync(string id);
        Task<ICollection<Score>> GetScoresByUserIdAsync(string UserId);
        Task<bool> UpdateScoreAsync(Score request);
    }
}