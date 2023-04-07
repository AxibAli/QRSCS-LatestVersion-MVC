using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.OT2
{
    public class OccupationalTherapy2Model
    {
        public int OT2_ID { get; set; }
        public int GR_NO { get; set; }
        public DateTime Test_Date { get; set; }
        public string Examiner_Name { get; set; }
        public string Examiner_Profession { get; set; }
        public string Caregiver_Name { get; set; }
        public string Caregiver_Relationship { get; set; }
        public string Name_Of_School { get; set; }
        public int School_Level { get; set; }
        public string Child_Order { get; set; }
        public string Children_Years_Living { get; set; }
    }
}