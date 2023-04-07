using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.OT2
{
    public class ConductProcessingOT2Model
    {
        public int ConductProcessingOT2_ID { get; set; }
        public int OT2_ID { get; set; }
        public string RG_53 { get; set; }
        public string RG_54 { get; set; }
        public string SK_55 { get; set; }
        public string SK_56 { get; set; }
        public string RG_57 { get; set; }
        public string AV_58 { get; set; }
        public string AV_59 { get; set; }
        public string SK_60 { get; set; }
        public string AV_61 { get; set; }
        public int Conduct_Raw_Score { get; set; }
        public string Conduct_Comments { get; set; }
    }
}