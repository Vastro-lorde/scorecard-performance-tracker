using System;

namespace scorecard_performance_tracker.DTOs
{
    public class ScoreResponseDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string DevSquad { get; set; }
        public short AgileScore { get; set; }
        public short AlgorithmScore { get; set; }
        public short AssesmentScore { get; set; }
        public short WeeklyTaskScore { get; set; }
        public short CumulativeScore { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
