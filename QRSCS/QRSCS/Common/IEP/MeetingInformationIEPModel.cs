using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.IEP
{
    public class MeetingInformationIEPModel
    {
        public int MeetingInformation_ID { get; set; }
        public int IEPlan_ID { get; set; }
        public bool Initial_IEP { get; set; }
        public DateTime Date_Initial_IEP { get; set; }
        public bool Annual_Review { get; set; }
        public DateTime Date_Annual_Review { get; set; }
        public bool Review_Other_Than_Annaul_Review { get; set; }
        public DateTime Date_Review_Other_Than_Annaul_Review { get; set; }
        public bool Ammendment { get; set; }
        public DateTime Date_Ammendment { get; set; }
        public string Communicating_Language { get; set; }
    }
}