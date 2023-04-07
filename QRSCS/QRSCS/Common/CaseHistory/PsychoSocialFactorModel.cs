using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.CaseHistory
{
    public class PsychoSocialFactorModel
    {
        public int Psycho_Social_Factors_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        public string Friends_Attitude { get; set; }
        public string Sibling_Relationship { get; set; }
        public string HomeAndParent_Attitude { get; set; }
        public string HobbiesAndInterest { get; set; }
    }
}