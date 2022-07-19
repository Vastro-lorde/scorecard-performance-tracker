using scorecard_cbt.ModelValidationHelper;
using System.ComponentModel.DataAnnotations;

namespace scorecard_performance_tracker.DTOs
{
    public class CreateScoreDto
    {
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string DevName { get; set; }
        [Required]
        public string DevSquad { get; set; }
        public short AgileScore { get; set; }
        public short AlgorithmScore { get; set; }
        public short AssesmentScore { get; set; }
        public short WeeklyTaskScore { get; set; }
        public short CumulativeScore { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string CreatedBy { get; set; }
    }
}
