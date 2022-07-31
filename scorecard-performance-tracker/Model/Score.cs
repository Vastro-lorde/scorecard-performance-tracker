using scorecard_cbt.ModelValidationHelper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scorecard_performance_tracker.Models
{
    public class Score : BaseEntity
    {
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string? UserId { get; set; }
        [Required]
        public string? DevSquad { get; set; }
        public double AgileScore { get; set; }
        public double AlgorithmScore { get; set; }
        public double AssesmentScore { get; set; }
        public double WeeklyTaskScore { get; set; }
        public double CumulativeScore { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string? CreatedBy { get; set; }
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UpdatedByValidator)]
        public string? UpdatedBy { get; set; }
        
    }
}
