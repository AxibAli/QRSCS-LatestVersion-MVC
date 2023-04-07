using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class PhysiotherapyManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int PT_ID = 0;
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
        //PT
        public int AddPhysiotherapy(PhysiotherapyModelDTO grno)
        {
            Physiotherapy table = new Physiotherapy();
            table.GR_NO = grno.physiotherapyModel.GR_NO;
            table.Date_of_Assessment = grno.physiotherapyModel.Date_of_Assessment;
            table.CP = grno.physiotherapyModel.CP;
            table.Down_Syndrome = grno.physiotherapyModel.Down_Syndrome;
            table.Autistic = grno.physiotherapyModel.Autistic;
            table.Muscular_Dystrophy = grno.physiotherapyModel.Muscular_Dystrophy;
            table.Physical_Disability = grno.physiotherapyModel.Physical_Disability;
            table.Others = grno.physiotherapyModel.Others;
            table.Siblings = grno.physiotherapyModel.Siblings;
            table.Marriage_Type = grno.physiotherapyModel.Marriage_Type;
            table.Blood_Group = grno.physiotherapyModel.Blood_Group;
            table.General_Health = grno.physiotherapyModel.General_Health;
            table.Present_Complain = grno.physiotherapyModel.Present_Complain;
            db.Physiotherapies.Add(table);
            PT_ID = table.PT_ID;


            HistoryPregnancy_PT table2 = new HistoryPregnancy_PT();
            table2.PT_ID = grno.physiotherapyModel.PT_ID;
            table2.Pregnancy_Length = grno.historyPregnancy.Pregnancy_Length;
            table2.Pregnancy_Type = grno.historyPregnancy.Pregnancy_Type;
            table2.Birth_Detail = grno.historyPregnancy.Birth_Detail;
            table2.Breathing_Problem = grno.historyPregnancy.Breathing_Problem;
            table2.Baby_Position = grno.historyPregnancy.Baby_Position;
            table2.Pregnancy = grno.historyPregnancy.Pregnancy;
            db.HistoryPregnancy_PT.Add(table2);


            MedicalInformation_PT table3 = new MedicalInformation_PT();
            table3.PT_ID = grno.physiotherapyModel.PT_ID;
            table3.Name_Of_Gp = grno.medicalInformation.Name_Of_Gp;
            table3.Medication = grno.medicalInformation.Medication;
            table3.Illness = grno.medicalInformation.Illness;
            table3.Allergies = grno.medicalInformation.Allergies;
            table3.Tests = grno.medicalInformation.Tests;
            table3.Surgical_Intervention = grno.medicalInformation.Surgical_Intervention;
            db.MedicalInformation_PT.Add(table3);


            Milestone_PT table4 = new Milestone_PT();
            table4.PT_ID = grno.physiotherapyModel.PT_ID;
            table4.Cry = grno.milestonePT.Cry;
            table4.Neck_Control = grno.milestonePT.Neck_Control;
            table4.Sitting = grno.milestonePT.Sitting;
            table4.Crawling = grno.milestonePT.Crawling;
            table4.Standing = grno.milestonePT.Standing;
            table4.Walking = grno.milestonePT.Walking;
            table4.Spoke_First_Word = grno.milestonePT.Spoke_First_Word;
            table4.Bowl_Bladder = grno.milestonePT.Bowl_Bladder;
            table4.Tactile = grno.milestonePT.Tactile;
            table4.Auditory = grno.milestonePT.Tactile;
            table4.Visual = grno.milestonePT.Tactile;
            table4.Taste_Smell = grno.milestonePT.Tactile;
            db.Milestone_PT.Add(table4);

            PhysicalAssessment_PT table5 = new PhysicalAssessment_PT();
            table5.PT_ID = grno.physiotherapyModel.PT_ID;
            table5.Contracture_Deformity = grno.physicalAssessment.Contracture_Deformity;
            table5.Muscle_Tone = grno.physicalAssessment.Muscle_Tone;
            table5.UpperLimbs_Strength = grno.physicalAssessment.UpperLimbs_Strength;
            table5.UpperLimbs_Rom = grno.physicalAssessment.UpperLimbs_Rom;
            table5.LowerLimbs_Strength = grno.physicalAssessment.LowerLimbs_Strength;
            table5.LowerLimbs_Rom = grno.physicalAssessment.LowerLimbs_Rom;
            db.PhysicalAssessment_PT.Add(table5);


            TreatmentPlan_PT table6 = new TreatmentPlan_PT();
            table6.PT_ID = grno.physiotherapyModel.PT_ID;
            table6.LongTerm_Goal = grno.treatmentPlan.LongTerm_Goal;
            table6.ShortTerm_Goal = grno.treatmentPlan.ShortTerm_Goal;
            table6.Recommendations = grno.treatmentPlan.Recommendations;
            db.TreatmentPlan_PT.Add(table6);

            TestDone_PT table7 = new TestDone_PT();  
            table7.Goniometer = grno.testDone.Goniometer;
            table7.Muscle_Strength = grno.testDone.Muscle_Strength;
           


            db.SaveChanges();
            PT_ID = table.PT_ID;
            return PT_ID;


        }

    }
}