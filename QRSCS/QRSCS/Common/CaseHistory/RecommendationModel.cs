using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace QRSCS.Common.CaseHistory
{
    public class RecommendationModel
    {
        public int Recommendation_Answer_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string IEP { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Physical_Therapy { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Occupational_Therapy { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Speech_Therapy { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Music_Therapy { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Vocational_Therapy { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Correction_of_Defect { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Glasses { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Heraing_Aid { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Orthopedic_appliance { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Attention_to_home_situation { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Parental_Counseling { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Any_other_Home { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Home_Based_Program { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Special_School { get; set; }
        [Required(ErrorMessage = "Kindly select your desired recommendation.")]
        public string Medication { get; set; }
        public string Any_other { get; set; }
    }
}