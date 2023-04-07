using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.IEP
{
    public class SpecialInstructionalIEPModel
    {
        public int SpecialInstruction_ID { get; set; }
        public int IEPlan_ID { get; set; }
        public string Question_1 { get; set; }
        public string Question_2 { get; set; }
        public string Question_3 { get; set; }
        public string Question_4 { get; set; }
        public string Question_5 { get; set; }
        public string Question_6 { get; set; }
    }
}