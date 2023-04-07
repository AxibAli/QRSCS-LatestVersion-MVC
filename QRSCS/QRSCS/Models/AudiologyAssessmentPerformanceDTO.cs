using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class AudiologyAssessmentPerformanceDTO
    {
        public int Audiology_Assessment_ID { get; set; }
        public int GR_NO { get; set; }
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public string Disability { get; set; }
        public string Year { get; set; }
        public string Left_Ear_Mean { get; set; }
        public string Left_Ear_Mean_Level { get; set; }
        public string Right_Ear_Mean { get; set; }
        public string Right_Ear_Mean_Level { get; set; }
    }
}