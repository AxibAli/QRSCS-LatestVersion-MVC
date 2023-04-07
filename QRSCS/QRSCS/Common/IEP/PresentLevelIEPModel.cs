using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.IEP
{
    public class PresentLevelIEPModel
    {
        public int PresentLevel_ID { get; set; }
        public int IEPlan_ID { get; set; }
        public string Physical_Development { get; set; }
        public string Communication { get; set; }
        public string Self_Help_Skills { get; set; }
        public string Cognition { get; set; }
        public string Socialization { get; set; }
        public string Functional_Academic { get; set; }
        public string Academic_Performance { get; set; }
        public string PreVocational_Skills { get; set; }
        public string Others { get; set; }
    }
}