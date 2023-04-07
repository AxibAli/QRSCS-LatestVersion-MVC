using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class BehavioralTherapyManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int BT_ID = 0;
        public NewAdmissionModel CheckUserExists(string GR_No)
        {
            NewAdmissionModel obj = new NewAdmissionModel();

            int check = Convert.ToInt32(GR_No);
            var userdata = db.New_Admission.Where(x => x.GR_NO == check).Select(x => new { x.GR_NO, x.Student_First_Name, x.Student_Last_Name, x.Father_Name, x.Gender, x.Disability }).FirstOrDefault();
            if (userdata != null)
            {

                obj.Student_First_Name = userdata.Student_First_Name;
                obj.Student_Last_Name = userdata.Student_Last_Name;
                obj.Father_Name = userdata.Father_Name;
                obj.Gender = userdata.Gender;
                obj.Disability = userdata.Disability;
            }
            return obj;
        }
        //BT
        public int AddBehavioraltherapy(BehavioralTherapyModelDTO grno)
        {
            BehavioralTherapy table = new BehavioralTherapy();
            table.GR_NO = grno.BehavioralTherapy.GR_NO;
            db.BehavioralTherapies.Add(table);
            table.Date = grno.BehavioralTherapy.Date;
            BT_ID = table.BT_ID;

    

            Week1_BT table3 = new Week1_BT();
            table3.BT_ID = grno.BehavioralTherapy.BT_ID;
            table3.Throwing_Week1 = grno.Week1BT.Throwing_Week1;
            table3.Pushing_Week1 = grno.Week1BT.Pushing_Week1;
            table3.Pinching_Week1 = grno.Week1BT.Pinching_Week1;
            table3.EyehandCoordination_Week1 = grno.Week1BT.EyehandCoordination_Week1;
            table3.HeadacheComplain_Week1 = grno.Week1BT.HeadacheComplain_Week1;
            table3.Vomiting_Week1 = grno.Week1BT.Vomiting_Week1;
            table3.AttachmentIssue_Week1 = grno.Week1BT.AttachmentIssue_Week1;
            table3.Adjustment_Week1 = grno.Week1BT.Adjustment_Week1;
            table3.Biting_Week1 = grno.Week1BT.Adjustment_Week1;
            table3.HairPulling_Week1 = grno.Week1BT.HairPulling_Week1;
            table3.EatingProblems_Week1 = grno.Week1BT.EatingProblems_Week1;
            table3.NoncomplianceBehavior_Week1 = grno.Week1BT.NoncomplianceBehavior_Week1;
            table3.Withdrawn_Week1 = grno.Week1BT.Withdrawn_Week1;
            table3.Shyness_Week1 = grno.Week1BT.Shyness_Week1;
            table3.Tolerance_Week1 = grno.Week1BT.Tolerance_Week1;
            table3.Irritability_Week1 = grno.Week1BT.Tolerance_Week1;
            table3.Unhappy_Week1 = grno.Week1BT.Unhappy_Week1;
            table3.Moodswings_Week1 = grno.Week1BT.Moodswings_Week1;
            table3.Hyperactive_Week1 = grno.Week1BT.Hyperactive_Week1;
            table3.Isolation_Week1 = grno.Week1BT.Isolation_Week1;
            table3.InAttention_Week1 = grno.Week1BT.InAttention_Week1;
            table3.SustainAttention_Week1 = grno.Week1BT.SustainAttention_Week1;
            table3.Restlessness_Week1 = grno.Week1BT.Restlessness_Week1;
            table3.AttachmentIssue_Week1 = grno.Week1BT.AttachmentIssue_Week1;
            table3.Crying_Week1 = grno.Week1BT.Crying_Week1;
            table3.Shouting_Week1 = grno.Week1BT.Shouting_Week1;
            table3.AbusiveLanguage_Week1 = grno.Week1BT.AbusiveLanguage_Week1;
            table3.Splitting_Week1 = grno.Week1BT.Splitting_Week1;
            table3.SelfInjurious_Week1 = grno.Week1BT.SelfInjurious_Week1;
            table3.PhysicalAggression_Week1 = grno.Week1BT.PhysicalAggression_Week1;
            table3.Other_Week1 = grno.Week1BT.Other_Week1;
            table3.FrequencyBehavior_Week1 = grno.Week1BT.FrequencyBehavior_Week1;
            db.Week1_BT.Add(table3);


            Week2_BT table4 = new Week2_BT();
            table4.BT_ID = grno.BehavioralTherapy.BT_ID;
            table4.Throwing_Week2 = grno.Week2BT.Throwing_Week2;
            table4.Pushing_Week2 = grno.Week2BT.Pushing_Week2;
            table4.Pinching_Week2 = grno.Week2BT.Pinching_Week2;
            table4.EyehandCoordination_Week2 = grno.Week2BT.EyehandCoordination_Week2;
            table4.HeadacheComplain_Week2 = grno.Week2BT.HeadacheComplain_Week2;
            table4.Vomiting_Week2 = grno.Week2BT.Vomiting_Week2;
            table4.AttachmentIssue_Week2 = grno.Week2BT.AttachmentIssue_Week2;
            table4.Adjustment_Week2 = grno.Week2BT.Adjustment_Week2;
            table4.Biting_Week2 = grno.Week2BT.Adjustment_Week2;
            table4.HairPulling_Week2 = grno.Week2BT.HairPulling_Week2;
            table4.EatingProblems_Week2 = grno.Week2BT.EatingProblems_Week2;
            table4.NoncomplianceBehavior_Week2 = grno.Week2BT.NoncomplianceBehavior_Week2;
            table4.Withdrawn_Week2 = grno.Week2BT.Withdrawn_Week2;
            table4.Shyness_Week2 = grno.Week2BT.Shyness_Week2;
            table4.Tolerance_Week2 = grno.Week2BT.Tolerance_Week2;
            table4.Irritability_Week2 = grno.Week2BT.Irritability_Week2;
            table4.Unhappy_Week2 = grno.Week2BT.Unhappy_Week2;
            table4.Moodswings_Week2 = grno.Week2BT.Moodswings_Week2;
            table4.Hyperactive_Week2 = grno.Week2BT.Hyperactive_Week2;
            table4.Isolation_Week2 = grno.Week2BT.Isolation_Week2;
            table4.InAttention_Week2 = grno.Week2BT.InAttention_Week2;
            table4.SustainAttention_Week2 = grno.Week2BT.SustainAttention_Week2;
            table4.Restlessness_Week2 = grno.Week2BT.Restlessness_Week2;
            table4.AttachmentIssue_Week2 = grno.Week2BT.AttachmentIssue_Week2;
            table4.Crying_Week2 = grno.Week2BT.Crying_Week2;
            table4.Shouting_Week2 = grno.Week2BT.Shouting_Week2;
            table4.AbusiveLanguage_Week2 = grno.Week2BT.AbusiveLanguage_Week2;
            table4.Splitting_Week2 = grno.Week2BT.Splitting_Week2;
            table4.SelfInjurious_Week2 = grno.Week2BT.SelfInjurious_Week2;
            table4.PhysicalAggression_Week2 = grno.Week2BT.PhysicalAggression_Week2;
            table4.Other_Week2 = grno.Week2BT.Other_Week2;
            table4.FrequencyBehavior_Week2 = grno.Week2BT.FrequencyBehavior_Week2;
            db.Week2_BT.Add(table4);


            Week3_BT table5 = new Week3_BT();
            table5.BT_ID = grno.BehavioralTherapy.BT_ID;
            table5.Throwing_Week3 = grno.Week3BT.Throwing_Week3;
            table5.Pushing_Week3 = grno.Week3BT.Pushing_Week3;
            table5.Pinching_Week3 = grno.Week3BT.Pinching_Week3;
            table5.EyehandCoordination_Week3 = grno.Week3BT.EyehandCoordination_Week3;
            table5.HeadacheComplain_Week3 = grno.Week3BT.HeadacheComplain_Week3;
            table5.Vomiting_Week3 = grno.Week3BT.Vomiting_Week3;
            table5.AttachmentIssue_Week3 = grno.Week3BT.AttachmentIssue_Week3;
            table5.Adjustment_Week3 = grno.Week3BT.Adjustment_Week3;
            table5.Biting_Week3 = grno.Week3BT.Adjustment_Week3;
            table5.HairPulling_Week3= grno.Week3BT.HairPulling_Week3;
            table5.EatingProblems_Week3 = grno.Week3BT.EatingProblems_Week3;
            table5.NoncomplianceBehavior_Week3 = grno.Week3BT.NoncomplianceBehavior_Week3;
            table5.Withdrawn_Week3 = grno.Week3BT.Withdrawn_Week3;
            table5.Shyness_Week3 = grno.Week3BT.Shyness_Week3;
            table5.Tolerance_Week3 = grno.Week3BT.Tolerance_Week3;
            table5.Irritability_Week3 = grno.Week3BT.Irritability_Week3;
            table5.Unhappy_Week3 = grno.Week3BT.Unhappy_Week3;
            table5.Moodswings_Week3 = grno.Week3BT.Moodswings_Week3;
            table5.Hyperactive_Week3 = grno.Week3BT.Hyperactive_Week3;
            table5.Isolation_Week3 = grno.Week3BT.Isolation_Week3;
            table5.InAttention_Week3 = grno.Week3BT.InAttention_Week3;
            table5.SustainAttention_Week3 = grno.Week3BT.SustainAttention_Week3;
            table5.Restlessness_Week3 = grno.Week3BT.Restlessness_Week3;
            table5.AttachmentIssue_Week3 = grno.Week3BT.AttachmentIssue_Week3;
            table5.Crying_Week3 = grno.Week3BT.Crying_Week3;
            table5.Shouting_Week3 = grno.Week3BT.Shouting_Week3;
            table5.AbusiveLanguage_Week3 = grno.Week3BT.AbusiveLanguage_Week3;
            table5.Splitting_Week3 = grno.Week3BT.Splitting_Week3;
            table5.SelfInjurious_Week3 = grno.Week3BT.SelfInjurious_Week3;
            table5.PhysicalAggression_Week3 = grno.Week3BT.PhysicalAggression_Week3;
            table5.Other_Week3 = grno.Week3BT.Other_Week3;
            table5.FrequencyBehavior_Week3 = grno.Week3BT.FrequencyBehavior_Week3;
            db.Week3_BT.Add(table5);


            Week4_BT table6 = new Week4_BT();
            table6.BT_ID = grno.BehavioralTherapy.BT_ID;
            table6.Throwing_Week4 = grno.Week4BT.Throwing_Week4;
            table6.Pushing_Week4 = grno.Week4BT.Pushing_Week4;
            table6.Pinching_Week4 = grno.Week4BT.Pinching_Week4;
            table6.EyehandCoordination_Week4 = grno.Week4BT.EyehandCoordination_Week4;
            table6.HeadacheComplain_Week4 = grno.Week4BT.HeadacheComplain_Week4;
            table6.Vomiting_Week4 = grno.Week4BT.Vomiting_Week4;
            table6.AttachmentIssue_Week4 = grno.Week4BT.AttachmentIssue_Week4;
            table6.Adjustment_Week4 = grno.Week4BT.Adjustment_Week4;
            table6.Biting_Week4 = grno.Week4BT.Adjustment_Week4;
            table6.HairPulling_Week4 = grno.Week4BT.HairPulling_Week4;
            table6.EatingProblems_Week4 = grno.Week4BT.EatingProblems_Week4;
            table6.NoncomplianceBehavior_Week4 = grno.Week4BT.NoncomplianceBehavior_Week4;
            table6.Withdrawn_Week4 = grno.Week4BT.Withdrawn_Week4;
            table6.Shyness_Week4 = grno.Week4BT.Shyness_Week4;
            table6.Tolerance_Week4 = grno.Week4BT.Tolerance_Week4;
            table6.Irritability_Week4 = grno.Week4BT.Irritability_Week4;
            table6.Unhappy_Week4 = grno.Week4BT.Unhappy_Week4;
            table6.Moodswings_Week4 = grno.Week4BT.Moodswings_Week4;
            table6.Hyperactive_Week4 = grno.Week4BT.Hyperactive_Week4;
            table6.Isolation_Week4 = grno.Week4BT.Isolation_Week4;
            table6.InAttention_Week4 = grno.Week4BT.InAttention_Week4;
            table6.SustainAttention_Week4 = grno.Week4BT.SustainAttention_Week4;
            table6.Restlessness_Week4 = grno.Week4BT.Restlessness_Week4;
            table6.AttachmentIssue_Week4 = grno.Week4BT.AttachmentIssue_Week4;
            table6.Crying_Week4 = grno.Week4BT.Crying_Week4;
            table6.Shouting_Week4 = grno.Week4BT.Shouting_Week4;
            table6.AbusiveLanguage_Week4 = grno.Week4BT.AbusiveLanguage_Week4;
            table6.Splitting_Week4 = grno.Week4BT.Splitting_Week4;
            table6.SelfInjurious_Week4 = grno.Week4BT.SelfInjurious_Week4;
            table6.PhysicalAggression_Week4 = grno.Week4BT.PhysicalAggression_Week4;
            table6.Other_Week4 = grno.Week4BT.Other_Week4;
            table6.FrequencyBehavior_Week4 = grno.Week4BT.FrequencyBehavior_Week4;
            db.Week4_BT.Add(table6);


























            db.SaveChanges();
            BT_ID = table.BT_ID;
            return BT_ID;
        }
    }
}