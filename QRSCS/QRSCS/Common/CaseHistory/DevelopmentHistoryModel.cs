using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.CaseHistory
{
    public class DevelopmentHistoryModel
    {
        public int Development_History_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Anemia { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Exposure_or_Radiation { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Rubella { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Attempted_Abortion { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Mediation_Drugs { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Alcohol { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Tobaco { get; set; }
        public string Any_Other_Development { get; set; }
        [Required(ErrorMessage = "Kindly Select any of your desired option")]
        public string Labor { get; set; }
        [Required(ErrorMessage = "Kindly choose your desired option")]
        public string Condition_at_birth { get; set; }
        [Required(ErrorMessage = "Kindly choose your desired option")]
        public string Attendant_During_Labour { get; set; }
        [Required(ErrorMessage = "Kindly choose your desired option")]
        public string Juandice { get; set; }
        [Required(ErrorMessage = "Kindly choose your desired option")]
        public string Convulsions { get; set; }
        [Required(ErrorMessage = "Kindly choose your desired option")]
        public string Cyanotic_Attacks { get; set; }
        [Required(ErrorMessage = "Kindly choose your desired option")]
        public string Feeding_Difficulty { get; set; }
        public string Any_Other_Neo_Natal_Period { get; set; }
    }
}