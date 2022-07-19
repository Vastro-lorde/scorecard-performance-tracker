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
        public string? DevName { get; set; }
        [Required]
        public string? DevSquad { get; set; }
        public short AgileScore { get; set; }
        public short AlgorithmScore { get; set; }
        public short AssesmentScore { get; set; }
        public short WeeklyTaskScore { get; set; }
        public short CumulativeScore { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.CreatedByValidator)]
        public string? CreatedBy { get; set; }
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationsHelper.UpdatedByValidator)]
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
