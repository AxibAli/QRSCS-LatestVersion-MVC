﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class IEPModel
    {
        public int IEPlan_ID { get; set; }
        public int GR_No { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string Disability { get; set; }
        public string Dob { get; set; }
        public string Date_Of_Assessment { get; set; }
        public string DevelopmentTeam_Name_1 { get; set; }
        public string DevelopmentTeam_Name_2 { get; set; }
        public string DevelopmentTeam_Name_3 { get; set; }
        public string DevelopmentTeam_Name_4 { get; set; }
        public string DevelopmentTeam_Name_5 { get; set; }
        public string DevelopmentTeam_Name_6 { get; set; }
        public string DevelopmentTeam_Name_7 { get; set; }
        public string Position_1 { get; set; }
        public string Position_2 { get; set; }
        public string Position_3 { get; set; }
        public string Position_4 { get; set; }
        public string Position_5 { get; set; }
        public string Position_6 { get; set; }
        public string Position_7 { get; set; }
        public bool Initial_IEP { get; set; }
        public string Date_Initial_IEP { get; set; }
        public bool Annual_Review { get; set; }
        public string Date_Annual_Review { get; set; }
        public bool Review_Other_Than_Annaul_Review { get; set; }
        public string Date_Review_Other_Than_Annaul_Review { get; set; }
        public bool Ammendment { get; set; }
        public string Date_Ammendment { get; set; }
        public string Communicating_Language { get; set; }
        public string Goal_1 { get; set; }
        public string Goal_2 { get; set; }
        public string Goal_3 { get; set; }
        public string Goal_4 { get; set; }
        public string Goal_5 { get; set; }
        public string Goal_6 { get; set; }
        public string Provider_1 { get; set; }
        public string Provider_2 { get; set; }
        public string Provider_3 { get; set; }
        public string Provider_4 { get; set; }
        public string Provider_5 { get; set; }
        public string Provider_Others_1 { get; set; }
        public string Evaluation_Method_1 { get; set; }
        public string Evaluation_Method_2 { get; set; }
        public string Evaluation_Method_3 { get; set; }
        public string Evaluation_Method_4 { get; set; }
        public string Evaluation_Method_5 { get; set; }
        public string Evaluation_Method_Others_1 { get; set; }
        public string Initial_Date_1 { get; set; }
        public string Initial_Date_2 { get; set; }
        public string Initial_Date_3 { get; set; }
        public string Initial_Date_4 { get; set; }
        public string Initial_Date_5 { get; set; }
        public string Initial_Date_6 { get; set; }
        public string Check_Date_1 { get; set; }
        public string Check_Date_2 { get; set; }
        public string Check_Date_3 { get; set; }
        public string Check_Date_4 { get; set; }
        public string Check_Date_5 { get; set; }
        public string Check_Date_6 { get; set; }
        public string Mastery_Date_1 { get; set; }
        public string Mastery_Date_2 { get; set; }
        public string Mastery_Date_3 { get; set; }
        public string Mastery_Date_4 { get; set; }
        public string Mastery_Date_5 { get; set; }
        public string Mastery_Date_6 { get; set; }

        public string Goal_7 { get; set; }
        public string Goal_8 { get; set; }
        public string Goal_9 { get; set; }
        public string Goal_10 { get; set; }
        public string Goal_11 { get; set; }
        public string Goal_12 { get; set; }
        public string Provider_6 { get; set; }
        public string Provider_7 { get; set; }
        public string Provider_8 { get; set; }
        public string Provider_9 { get; set; }
        public string Provider_10 { get; set; }
        public string Provider_Other_2 { get; set; }
        public string Evaluation_Method_6 { get; set; }
        public string Evaluation_Method_7 { get; set; }
        public string Evaluation_Method_8 { get; set; }
        public string Evaluation_Method_9 { get; set; }
        public string Evaluation_Method_10 { get; set; }
        public string Evaluation_Method_Others_2 { get; set; }
        public string Initial_Date_7 { get; set; }
        public string Initial_Date_8 { get; set; }
        public string Initial_Date_9 { get; set; }
        public string Initial_Date_10 { get; set; }
        public string Initial_Date_11 { get; set; }
        public string Initial_Date_12 { get; set; }
        public string Check_Date_7 { get; set; }
        public string Check_Date_8 { get; set; }
        public string Check_Date_9 { get; set; }
        public string Check_Date_10 { get; set; }
        public string Check_Date_11 { get; set; }
        public string Check_Date_12 { get; set; }
        public string Mastery_Date_7 { get; set; }
        public string Mastery_Date_8 { get; set; }
        public string Mastery_Date_9 { get; set; }
        public string Mastery_Date_10 { get; set; }
        public string Mastery_Date_11 { get; set; }
        public string Mastery_Date_12 { get; set; }
        public string Physical_Development { get; set; }
        public string Communication { get; set; }
        public string Self_Help_Skills { get; set; }
        public string Cognition { get; set; }
        public string Socialization { get; set; }
        public string Functional_Academic { get; set; }
        public string Academic_Performance { get; set; }
        public string PreVocational_Skills { get; set; }
        public string Others { get; set; }
        public string Question_1 { get; set; }
        public string Question_2 { get; set; }
        public string Question_3 { get; set; }
        public string Question_4 { get; set; }
        public string Question_5 { get; set; }
        public string Question_6 { get; set; }
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
        public int SupplementaryAids_ID { get; set; }
        public int SpecialInstruction_ID { get; set; }
        public int PresentLevel_ID { get; set; }
        public int IEP_Page3ID { get; set; }
        public int MeetingInformation_ID { get; set; }
        public int DevelopmentTeam_ID { get; set; }

    }
}