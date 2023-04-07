using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.IEP
{
    public class SupplementaryAidsIEPModel
    {
        public int SupplementaryAids_ID { get; set; }
        public int IEPlan_ID { get; set; }
        public string Related_Services_1 { get; set; }
        public string Related_Services_2 { get; set; }
        public string Related_Services_3 { get; set; }
        public string Related_Services_4 { get; set; }
        public string Related_Services_5 { get; set; }
        public string Related_Services_6 { get; set; }
        public string Related_Services_7 { get; set; }
        public string Provider_Name_1 { get; set; }
        public string Provider_Name_2 { get; set; }
        public string Provider_Name_3 { get; set; }
        public string Provider_Name_4 { get; set; }
        public string Provider_Name_5 { get; set; }
        public string Provider_Name_6 { get; set; }
        public string Provider_Name_7 { get; set; }
        public int Hours_per_week_1 { get; set; }
        public int Hours_per_week_2 { get; set; }
        public int Hours_per_week_3 { get; set; }
        public int Hours_per_week_4 { get; set; }
        public int Hours_per_week_5 { get; set; }
        public int Hours_per_week_6 { get; set; }
        public int Hours_per_week_7 { get; set; }
        public string Location_1 { get; set; }
        public string Location_2 { get; set; }
        public string Location_3 { get; set; }
        public string Location_4 { get; set; }
        public string Location_5 { get; set; }
        public string Location_6 { get; set; }
        public string Location_7 { get; set; }
        public string Program_Modifications { get; set; }
        public string Recommended_Instructional_Interventions { get; set; }
    }
}