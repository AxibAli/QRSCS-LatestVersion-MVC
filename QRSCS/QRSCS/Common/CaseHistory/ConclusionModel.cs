using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.CaseHistory
{
    public class ConclusionModel
    {
        public int Conclusion_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        public string Conclusion_text { get; set; }
    }
}