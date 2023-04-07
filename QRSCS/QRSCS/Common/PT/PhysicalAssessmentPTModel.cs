using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class PhysicalAssessmentPTModel
    {
        public int PhysicalAssessmentPT_ID { get; set; }
        public int PT_ID { get; set; }
        public string Contracture_Deformity { get; set; }
        public string Muscle_Tone { get; set; }
        public string UpperLimbs_Strength { get; set; }
        public string UpperLimbs_Rom { get; set; }
        public string LowerLimbs_Strength { get; set; }
        public string LowerLimbs_Rom { get; set; }
    }
}