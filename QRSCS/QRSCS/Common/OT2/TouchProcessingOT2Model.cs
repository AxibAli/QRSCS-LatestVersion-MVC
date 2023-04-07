using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.OT2
{
    public class TouchProcessingOT2Model
    {
        public int TouchProcessingOT2_ID { get; set; }
        public int OT2_ID { get; set; }
        public string SN_16 { get; set; }
        public string SN_17 { get; set; }
        public string AV_18 { get; set; }
        public string SN_19 { get; set; }
        public string SN_20 { get; set; }
        public string SK_21 { get; set; }
        public string SK_22 { get; set; }
        public string RG_23 { get; set; }
        public string RG_24 { get; set; }
        public string SK_25 { get; set; }
        public string RG_26 { get; set; }
        public int Touch_Raw_Score { get; set; }
        public string Touch_Comments { get; set; }
    }
}