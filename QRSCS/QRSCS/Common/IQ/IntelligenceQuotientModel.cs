using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.IQ
{
    public class IntelligenceQuotientModel
    {
        public int IQ_ID { get; set; }
        public int GR_NO { get; set; }
        public DateTime Date { get; set; }
        public bool Communication { get; set; }
        public bool Socialization { get; set; }
        public bool Self_Help_Skills { get; set; }
        public bool Cognition { get; set; }
        public bool Physical_Development { get; set; }
        public string Communication_Score { get; set; }
        public string Socialization_Score { get; set; }
        public string Self_Help_Skills_Score { get; set; }
        public string Cognition_Score { get; set; }
        public string Physical_Development_Score { get; set; }
    }
}