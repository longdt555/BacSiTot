using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("FacilityReview")]
    public class FacilityReviewModel : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string TimeVisited { get; set; }
        public bool RecommendUsing { get; set; }
        public string RecommendUsingStr => RecommendUsing ? "Khuyên dùng" : "Không khuyên dùng";
        public float Question1Score { get; set; } = 0;
        public float Question2Score { get; set; } = 0;
        public float Question3Score { get; set; } = 0;
        public float Question4Score { get; set; } = 0;
        public double AveragePoint => Math.Round((Question1Score + Question2Score + Question3Score + Question4Score) / 4, 1);
        [ForeignKey("HealthFacilityId")]
        public virtual HealthFacilityModel HealthFacility { get; set; }
    }
}