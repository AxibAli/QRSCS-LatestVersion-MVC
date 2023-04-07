using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class PhysiotherapyModel
    {
        public int PT_ID { get; set; }
        public int GR_NO { get; set; }
        public bool CP { get; set; }
        public bool Down_Syndrome { get; set; }
        public bool Autistic { get; set; }
        public bool Muscular_Dystrophy { get; set; }
        public bool Physical_Disability { get; set; }
        public string Others { get; set; }
        public DateTime Date_of_Assessment { get; set; }
        public int Siblings { get; set; }
        public string Marriage_Type { get; set; }
        public string Blood_Group { get; set; }
        public string General_Health { get; set; }
        public string Present_Complain { get; set; }
    }
}