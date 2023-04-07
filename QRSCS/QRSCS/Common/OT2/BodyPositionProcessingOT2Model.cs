using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.OT2
{
    public class BodyPositionProcessingOT2Model
    {
        public int BodyPositionProcessingOT2_ID { get; set; }
        public int OT2_ID { get; set; }
        public string RG_35 { get; set; }
        public string RG_36 { get; set; }
        public string RG_37 { get; set; }
        public string RG_38 { get; set; }
        public string RG_39 { get; set; }
        public string RG_40 { get; set; }
        public string SK_41 { get; set; }
        public string SK_42 { get; set; }
        public int Body_Postion_Raw_Score { get; set; }
        public string Body_Position_Comments { get; set; }
    }
}