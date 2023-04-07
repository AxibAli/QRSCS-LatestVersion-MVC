using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.OT2
{
    public class AuditoryProcessingOT2Model
    {
        public int AuditoryProcessingOT2_ID { get; set; }
        public int OT2_ID { get; set; }
        public string AV_1 { get; set; }
        public string AV_2 { get; set; }
        public string SN_3 { get; set; }
        public string SN_4 { get; set; }
        public string AV_5 { get; set; }
        public string SN_6 { get; set; }
        public string SN_7 { get; set; }
        public string RG_8 { get; set; }
        public int Auditory_Raw_Score { get; set; }
        public string Auditory_Comments { get; set; }
    }
}