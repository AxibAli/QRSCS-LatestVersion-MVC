using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class AudiologyAssessmentModel
    {
        public int Audiology_Assessment_ID { get; set; }
        public int GR_NO { get; set; }
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public string Disabilities { get; set; }
        public string Left_Ear_Picture { get; set; }
        public string Right_Ear_Picture { get; set; }
        public System.DateTime Date_of_Assessment { get; set; }
    }
}