using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.FinalResult
{
    public class FinalResultModel
    {
        public int MidTerm_Result_ID { get; set; }
        [Required]
        public int GR_NO { get; set; }
        [Required]
        public string Term_Type { get; set; }
        [Required]
        public int English { get; set; }
        [Required]
        public int Urdu { get; set; }
        [Required]
        public int Maths { get; set; }
        [Required]
        public int Science { get; set; }
        [Required]
        public int Social_Studies { get; set; }
        [Required]
        public int Islamiat { get; set; }
        [Required]
        public int Computer { get; set; }
        [Required]
        public int Speech { get; set; }
        [Required]
        public int Language { get; set; }
        [Required]
        public int Concepts { get; set; }
        [Required]
        public int Art_and_Drawing { get; set; }
        [Required]
        public int Sindhi { get; set; }
        [Required]
        public int Obtained_Total { get; set; }
        [Required]
        public int Percentage { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public System.DateTime Result_Date { get; set; }
        
        public int Grand_English { get; set; }
        public int Grand_Urdu { get; set; }
        public int Grand_Maths { get; set; }
        public int Grand_Science { get; set; }
        public int Grand_Social_Studies { get; set; }
        public int Grand_Islamiat { get; set; }
        public int Grand_Computer { get; set; }
        public int Grand_Speech { get; set; }  
        public int Grand_Language { get; set; }  
        public int Grand_Concepts { get; set; } 
        public int Grand_Art_and_Drawing { get; set; } 
        public int Grand_Sindhi { get; set; }
        public int Grand_Total { get; set; }
        public int Grand_Percentage { get; set; }
        public string Grand_Grade { get; set; }
    }
}