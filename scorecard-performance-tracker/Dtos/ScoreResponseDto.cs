using System;

namespace scorecard_performance_tracker.DTOs
{
    public class ScoreResponseDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string DevSquad { get; set; }
        public double AgileScore { get; set; }
        public double AlgorithmScore { get; set; }
        public double AssesmentScore { get; set; }
        public double WeeklyTaskScore { get; set; }
        public double CumulativeScore { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
