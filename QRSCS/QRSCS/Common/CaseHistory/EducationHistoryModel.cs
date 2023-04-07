using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.CaseHistory
{
    public class EducationHistoryModel
    {
        public int Education_History_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        public string Name_of_School { get; set; }
        public string Age_at_First_Admission { get; set; }
        public string Performance { get; set; }
        public string Duration { get; set; }
        public string Reason_for_Withdrawal { get; set; }
    }
}