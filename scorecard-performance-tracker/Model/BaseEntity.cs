using scorecard_cbt.ModelValidationHelper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scorecard_performance_tracker.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}