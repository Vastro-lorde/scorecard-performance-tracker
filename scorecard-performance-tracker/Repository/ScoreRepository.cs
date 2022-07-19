using Microsoft.EntityFrameworkCore;
using scorecard_performance_tracker.Data;
using scorecard_performance_tracker.Models;

namespace scorecard_performance_tracker.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Score> _dbSet;
        public ScoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Score>();
        }

        public async Task<bool> CreateScoreAsync(Score score)
        {
            score.UpdatedBy = "";
            _dbContext.Scores.Add(score);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteScore(Score request)
        {
            _dbSet.Remove(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateScoreAsync(Score request)
        {
            _dbSet.Update(request);
             return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<Score> GetScoreByIdAsync(string id)
        {
            var score = await _dbContext.Scores.FindAsync(id);
            return score;
        }
        public async Task<List<Score>> GetAllScoresAsync()
        {
            var scores = await _dbContext.Scores.ToListAsync();
            return scores = await _dbContext.Scores.ToListAsync();
        }
        public async Task<ICollection<Score>> GetScoresByDevNameAsync(string DevName)
        {
            var scores = await _dbContext.Scores.Where(x => x.DevName == DevName).ToListAsync();
            return scores;
        }
    }
}
