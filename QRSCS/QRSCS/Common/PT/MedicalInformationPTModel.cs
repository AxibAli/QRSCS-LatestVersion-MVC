using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class MedicalInformationPTModel
    {
        public int MedicalInformationPT_ID { get; set; }
        public int PT_ID { get; set; }
        public string Name_Of_Gp { get; set; }
        public string Medication { get; set; }
        public string Illness { get; set; }
        public string Allergies { get; set; }
        public string Tests { get; set; }
        public string Surgical_Intervention { get; set; }
    }
}