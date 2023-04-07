using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class TreatmentPlanPTModel
    {
        public int TreatmentPlanPT_ID { get; set; }
        public int PT_ID { get; set; }
        public string LongTerm_Goal { get; set; }
        public string ShortTerm_Goal { get; set; }
        public string Recommendations { get; set; }
    }
}