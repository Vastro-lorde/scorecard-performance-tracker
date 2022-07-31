using AutoMapper;
using scorecard_performance_tracker.DTOs;
using scorecard_performance_tracker.Models;
using scorecard_performance_tracker.Repository;
using scorecard_performance_tracker.Utilities.Pagination;
using System.Net;

namespace scorecard_performance_tracker.Services
{
    public class ScoreServices : IScoreServices
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IMapper _mapper;
        public ScoreServices(IScoreRepository scoreRepository, IMapper mapper)
        {
            _scoreRepository = scoreRepository;
            _mapper = mapper;
        }

        public async Task<Response<ScoreResponseDto>> GetScoreByIdAsync(string ScoreId)
        {
            var score = await _scoreRepository.GetScoreByIdAsync(ScoreId);
            if (score != null)
            {
                var result = _mapper.Map<ScoreResponseDto>(score);
                return new Response<ScoreResponseDto>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }

            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Score>> DeleteScoreAsync(string ScoreId)
        {
            var score = await _scoreRepository.GetScoreByIdAsync(ScoreId);
            if (score == null)
            {
                return new Response<Score>()
                {
                    Message = "Score Not Found",
                    ResponseCode = HttpStatusCode.NoContent,
                    IsSuccessful = false
                };
            }
            bool delete = await _scoreRepository.DeleteScore(score);
            if (delete)
            {
                return new Response<Score>()
                {
                    Message = "Score Successfully Deleted",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            else
            {
                return new Response<Score>()
                {
                    Message = "Failed to delete score",
                    ResponseCode = HttpStatusCode.Conflict,
                    IsSuccessful = false
                };
            }

            
        }

        public async Task<Response<PaginationModel<IEnumerable<ScoreResponseDto>>>> GetAllScoresAsync(int pageSize, int pageNumber)
        {
            var scores = await _scoreRepository.GetAllScoresAsync();
            var response = _mapper.Map<IEnumerable<ScoreResponseDto>>(scores);

            if (scores != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<ScoreResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Scores",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<ScoreResponseDto>>>()
            {
                Data = null,
                Message = "No Scores Found",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }

        public async Task<Response<PaginationModel<IEnumerable<ScoreResponseDto>>>> GetScoresByUserIdAsync(int pageSize, int pageNumber, string UserId)
        {
            var scores = await _scoreRepository.GetScoresByUserIdAsync(UserId);
            var response = _mapper.Map<IEnumerable<ScoreResponseDto>>(scores);

            if (scores != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<ScoreResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Scores",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<ScoreResponseDto>>>()
            {
                Data = null,
                Message = "No Scores Found",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }

        public async Task<Response<Score>> CreateScoreAsync(CreateScoreDto createScore)
        {
            
            double task = createScore.WeeklyTaskScore;
            double agile = createScore.AgileScore;
            double assessment = createScore.AssesmentScore;
            double algorithm = createScore.AlgorithmScore;
            double CumulativeScore = Math.Floor((task * 0.4) + (agile * 0.2) + (assessment * 0.2) + (algorithm * 0.2));
            Score score = _mapper.Map<Score>(createScore);
            score.CumulativeScore = CumulativeScore;
            var result = await _scoreRepository.CreateScoreAsync(score);
            if (result)
            {
                return new Response<Score>()
                {
                    Data = score,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Score>> UpdateScoreDetails(string ScoreId, UpdateScoreDto updateScore)
        {
            var score = await _scoreRepository.GetScoreByIdAsync(ScoreId);

            if (score != null)
            {
                double task = updateScore.WeeklyTaskScore;
                double agile = updateScore.AgileScore;
                double assessment = updateScore.AssesmentScore;
                double algorithm = updateScore.AlgorithmScore;
                double CumulativeScore = Math.Floor((task * 0.4) + (agile * 0.2) + (assessment * 0.2) + (algorithm * 0.2));

                var updatedScore = _mapper.Map(updateScore,score);

                updatedScore.CumulativeScore = CumulativeScore;
                updatedScore.UpdatedOn = DateTime.Now;

                var result = await _scoreRepository.UpdateScoreAsync(updatedScore);

                if (result)
                {
                    return new Response<Score>()
                    {
                        Data = updatedScore,
                        IsSuccessful = true,
                        Message = "Score updated",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<Score>()
                {
                    IsSuccessful = false,
                    Message = "Score not updated",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            throw new ArgumentException("Score not found");
        }
    }
}
