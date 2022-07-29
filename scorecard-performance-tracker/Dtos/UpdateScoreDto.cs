using scorecard_cbt.ModelValidationHelper;
using System;
using System.ComponentModel.DataAnnotations;

namespace scorecard_performance_tracker.DTOs
{
    public class UpdateScoreDto
    {
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string UserId { get; set; }
        public string DevSquad { get; set; }

        [Range(0.0, 100, ErrorMessage = DataAnnotationsHelper.ScoreValidator)]
        public double AgileScore { get; set; }

        [Range(0.0, 20, ErrorMessage = "The field {0} must be greater than {1} and less than 20.")]
        public double AlgorithmScore { get; set; }

        [Range(0.0, 100, ErrorMessage = DataAnnotationsHelper.ScoreValidator)]
        public double AssesmentScore { get; set; }

        [Range(0.0, 100, ErrorMessage = DataAnnotationsHelper.ScoreValidator)]
        public double WeeklyTaskScore { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UpdatedByValidator)]
        public string UpdatedBy { get; set; }
    }
}
