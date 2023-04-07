using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class CaseHistoryManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int CaseHistoryID = 0;
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

        //Case-History
        public int AddCaseHistory(CaseHistoryModelDTO grno)
        {
            Case_History table = new Case_History();
            table.GR_NO = grno.CaseHistory.GR_NO;
            table.Date_of_Examination = grno.CaseHistory.Date_of_Examination;
            db.Case_History.Add(table);
            CaseHistoryID = table.CaseHistory_ID;

            Family_History table2 = new Family_History();
            table2.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table2.Father_Name = grno.FamilyHistory.Father_Name;
            table2.Father_Age = grno.FamilyHistory.Father_Age;
            table2.Father_Education = grno.FamilyHistory.Father_Education;
            table2.Father_Profession = grno.FamilyHistory.Father_Profession;
            table2.Father_Financial_Status = grno.FamilyHistory.Father_Financial_Status;
            table2.Father_General_Health = grno.FamilyHistory.Father_General_Health;
            table2.Father_Blood_Group = grno.FamilyHistory.Father_Blood_Group;
            table2.Year_of_Marriage = grno.FamilyHistory.Year_of_Marriage;
            table2.Father_Age_at_the_time_of_Child_Birth = grno.FamilyHistory.Father_Age_at_the_time_of_Child_Birth;
            table2.Father_Paternal_Relationship = grno.FamilyHistory.Father_Paternal_Relationship;
            table2.Father_Family_System = grno.FamilyHistory.Father_Family_System;
            table2.Mother_Name = grno.FamilyHistory.Mother_Name;
            table2.Mother_Age = grno.FamilyHistory.Mother_Age;
            table2.Mother_Education = grno.FamilyHistory.Mother_Education;
            table2.Mother_Profession = grno.FamilyHistory.Mother_Profession;
            table2.Mother_Financial_Status = grno.FamilyHistory.Mother_Financial_Status;
            table2.Mother_General_Health = grno.FamilyHistory.Mother_General_Health;
            table2.Mother_Blood_Group = grno.FamilyHistory.Mother_Blood_Group;
            table2.Mother_Age_at_the_time_of_Child_Birth = grno.FamilyHistory.Mother_Age_at_the_time_of_Child_Birth;
            table2.Mother_Paternal_Relationship = grno.FamilyHistory.Mother_Paternal_Relationship;
            table2.Mother_Family_System = grno.FamilyHistory.Mother_Family_System;
            db.Family_History.Add(table2);

            Particulars_of_Sibling table3 = new Particulars_of_Sibling();
            table3.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table3.Number_of_Siblings = grno.ParticularsOfSibling.Number_of_Siblings;
            table3.Child_Order = grno.ParticularsOfSibling.Child_Order;
            table3.Any_Disability = grno.ParticularsOfSibling.Any_Disability;
            db.Particulars_of_Sibling.Add(table3);

            Development_History table4 = new Development_History();
            table4.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table4.Anemia = grno.DevelopmentHistory.Anemia;
            table4.Exposure_or_Radiation = grno.DevelopmentHistory.Exposure_or_Radiation;
            table4.Rubella = grno.DevelopmentHistory.Rubella;
            table4.Attempted_Abortion = grno.DevelopmentHistory.Attempted_Abortion;
            table4.Mediation_Drugs = grno.DevelopmentHistory.Mediation_Drugs;
            table4.Alcohol = grno.DevelopmentHistory.Alcohol;
            table4.Tobaco = grno.DevelopmentHistory.Tobaco;
            table4.Any_Other_Development = grno.DevelopmentHistory.Any_Other_Development;
            table4.Labor = grno.DevelopmentHistory.Labor;
            table4.Condition_at_birth = grno.DevelopmentHistory.Condition_at_birth;
            table4.Attendant_During_Labour = grno.DevelopmentHistory.Attendant_During_Labour;
            table4.Juandice = grno.DevelopmentHistory.Juandice;
            table4.Convulsions = grno.DevelopmentHistory.Convulsions;
            table4.Cyanotic_Attacks = grno.DevelopmentHistory.Cyanotic_Attacks;
            table4.Feeding_Difficulty = grno.DevelopmentHistory.Feeding_Difficulty;
            table4.Any_Other_Neo_Natal_Period = grno.DevelopmentHistory.Any_Other_Neo_Natal_Period;
            db.Development_History.Add(table4);

            Post_Natal table5 = new Post_Natal();
            table5.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table5.Birth_Weight_Months = grno.PostNatal.Birth_Weight_Months;
            table5.Birth_Weight_Years = grno.PostNatal.Birth_Weight_Years;
            table5.Smiling_Months = grno.PostNatal.Smiling_Months;
            table5.Smiling_Years = grno.PostNatal.Smiling_Years;
            table5.Cooing_Months = grno.PostNatal.Cooing_Months;
            table5.Cooing_Years = grno.PostNatal.Cooing_Years;
            table5.Neck_Control_Months = grno.PostNatal.Neck_Control_Months;
            table5.Neck_Control_Years = grno.PostNatal.Neck_Control_Years;
            table5.Teething_Months = grno.PostNatal.Teething_Months;
            table5.Teething_Years = grno.PostNatal.Teething_Years;
            table5.Sitting_alone_Months = grno.PostNatal.Sitting_alone_Months;
            table5.Sitting_alone_Years = grno.PostNatal.Sitting_alone_Years;
            table5.Crawling_Months = grno.PostNatal.Crawling_Months;
            table5.Crawling_Years = grno.PostNatal.Crawling_Years;
            table5.Walk_alone_Months = grno.PostNatal.Walk_alone_Months;
            table5.Walk_alone_Years = grno.PostNatal.Walk_alone_Years;
            table5.Spoke_1st_Word_Months = grno.PostNatal.Spoke_1st_Word_Months;
            table5.Spoke_1st_Word_Years = grno.PostNatal.Spoke_1st_Word_Years;
            table5.Able_to_Feed_alone_Months = grno.PostNatal.Able_to_Feed_alone_Months;
            table5.Able_to_Feed_alone_Years = grno.PostNatal.Able_to_Feed_alone_Years;
            table5.Sphineter_Control_Months = grno.PostNatal.Sphineter_Control_Months;
            table5.Sphineter_Control_Years = grno.PostNatal.Sphineter_Control_Years;
            table5.Puberty_Months = grno.PostNatal.Puberty_Months;
            table5.Puberty_Years = grno.PostNatal.Puberty_Years;
            table5.Meningitis_Encephalitis_Months = grno.PostNatal.Meningitis_Encephalitis_Months;
            table5.Meningitis_Encephalitis_Years = grno.PostNatal.Meningitis_Encephalitis_Years;
            table5.Convulsion_Months = grno.PostNatal.Convulsion_Months;
            table5.Convulsion_Years = grno.PostNatal.Convulsion_Years;
            table5.Head_Injury_Months = grno.PostNatal.Head_Injury_Months;
            table5.Head_Injury_Years = grno.PostNatal.Head_Injury_Years;
            table5.Dehydration_Months = grno.PostNatal.Dehydration_Months;
            table5.Dehydration_Years = grno.PostNatal.Dehydration_Years;
            table5.Severe_Malnutrition_Months = grno.PostNatal.Severe_Malnutrition_Months;
            table5.Severe_Malnutrition_Years = grno.PostNatal.Severe_Malnutrition_Years;
            table5.Any_Other_illness_Months = grno.PostNatal.Any_Other_illness_Months;
            db.Post_Natal.Add(table5);

            Medical_History table6 = new Medical_History();
            table6.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table6.Measles_Answer = grno.MedicalHistory.Measles_Answer;
            table6.Measles_Age = grno.MedicalHistory.Measles_Age;
            table6.Whooping_Enough_Answer = grno.MedicalHistory.Whooping_Enough_Answer;
            table6.Whooping_Enough_Age = grno.MedicalHistory.Whooping_Enough_Age;
            table6.Mumps_Answer = grno.MedicalHistory.Mumps_Answer;
            table6.Mumps_Age = grno.MedicalHistory.Mumps_Age;
            table6.Chickenpox_Answer = grno.MedicalHistory.Chickenpox_Answer;
            table6.Chickenpox_Age = grno.MedicalHistory.Chickenpox_Age;
            table6.Pneumonia_Answer = grno.MedicalHistory.Pneumonia_Answer;
            table6.Pneumonia_Age = grno.MedicalHistory.Pneumonia_Age;
            table6.Diphtheria_Answer = grno.MedicalHistory.Diphtheria_Answer;
            table6.Diphtheria_Age = grno.MedicalHistory.Diphtheria_Age;
            table6.Polio_Answer = grno.MedicalHistory.Polio_Answer;
            table6.Polio_Age = grno.MedicalHistory.Polio_Age;
            table6.Influenza_Answer = grno.MedicalHistory.Influenza_Answer;
            table6.Influenza_Age = grno.MedicalHistory.Influenza_Age;
            table6.Typhoid_Answer = grno.MedicalHistory.Typhoid_Answer;
            table6.Typhoid_Age = grno.MedicalHistory.Typhoid_Age;
            table6.Convulsion_Answer = grno.MedicalHistory.Convulsion_Answer;
            table6.Convulsion_Age = grno.MedicalHistory.Convulsion_Age;
            table6.Rheumatic_Fever_Answer = grno.MedicalHistory.Rheumatic_Fever_Answer;
            table6.Rheumatic_Fever_Age = grno.MedicalHistory.Rheumatic_Fever_Age;
            table6.High_Grade_Fever_Answer = grno.MedicalHistory.High_Grade_Fever_Answer;
            table6.High_Grade_Fever_Age = grno.MedicalHistory.High_Grade_Fever_Age;
            table6.Any_Other = grno.MedicalHistory.Any_Other;
            db.Medical_History.Add(table6);

            Education_History table7 = new Education_History();
            table7.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table7.Name_of_School = grno.EducationHistory.Name_of_School;
            table7.Age_at_First_Admission = grno.EducationHistory.Age_at_First_Admission;
            table7.Performance = grno.EducationHistory.Performance;
            table7.Duration = grno.EducationHistory.Duration;
            table7.Reason_for_Withdrawal = grno.EducationHistory.Reason_for_Withdrawal;
            db.Education_History.Add(table7);

            Psycho_Social_Factors table8 = new Psycho_Social_Factors();
            table8.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table8.Friends_Attitude = grno.PsychoSocialFactor.Friends_Attitude;
            table8.Sibling_Relationship = grno.PsychoSocialFactor.Sibling_Relationship;
            table8.HomeAndParent_Attitude = grno.PsychoSocialFactor.HomeAndParent_Attitude;
            table8.HobbiesAndInterest = grno.PsychoSocialFactor.HobbiesAndInterest;
            db.Psycho_Social_Factors.Add(table8);

            Behavioral_Observation table9 = new Behavioral_Observation();
            table9.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table9.Aggressive = grno.BehavioralObservation.Aggressive;
            table9.Restlessness = grno.BehavioralObservation.Restlessness;
            table9.Impulsivity = grno.BehavioralObservation.Impulsivity;
            table9.Distractibility = grno.BehavioralObservation.Distractibility;
            table9.Destructive = grno.BehavioralObservation.Destructive;
            table9.Hyper_Active = grno.BehavioralObservation.Hyper_Active;
            table9.Tantrum = grno.BehavioralObservation.Tantrum;
            table9.Self_Stimulation = grno.BehavioralObservation.Self_Stimulation;
            table9.Shyness = grno.BehavioralObservation.Shyness;
            table9.Complain = grno.BehavioralObservation.Complain;
            table9.Dependence = grno.BehavioralObservation.Dependence;
            table9.Low_Self_Image = grno.BehavioralObservation.Low_Self_Image;
            table9.Add_ = grno.BehavioralObservation.Add_;
            table9.Short_Attention_Span = grno.BehavioralObservation.Short_Attention_Span;
            table9.Poor_Motivation = grno.BehavioralObservation.Poor_Motivation;
            table9.Isolation_ = grno.BehavioralObservation.Isolation_;
            table9.Withdrawn = grno.BehavioralObservation.Withdrawn;
            table9.Asocial = grno.BehavioralObservation.Asocial;
            db.Behavioral_Observation.Add(table9);

            Conclusion table10 = new Conclusion();
            table10.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table10.Conclusion_text = grno.Conclusion.Conclusion_text;
            db.Conclusions.Add(table10);

            Recommendation table11 = new Recommendation();
            table11.CaseHistory_ID = grno.CaseHistory.CaseHistory_ID;
            table11.IEP = grno.Recommendation.IEP;
            table11.Physical_Therapy = grno.Recommendation.Physical_Therapy;
            table11.Occupational_Therapy = grno.Recommendation.Occupational_Therapy;
            table11.Speech_Therapy = grno.Recommendation.Speech_Therapy;
            table11.Music_Therapy = grno.Recommendation.Music_Therapy;
            table11.Vocational_Therapy = grno.Recommendation.Vocational_Therapy;
            table11.Correction_of_Defect = grno.Recommendation.Correction_of_Defect;
            table11.Glasses = grno.Recommendation.Glasses;
            table11.Heraing_Aid = grno.Recommendation.Heraing_Aid;
            table11.Orthopedic_appliance = grno.Recommendation.Orthopedic_appliance;
            table11.Attention_to_home_situation = grno.Recommendation.Attention_to_home_situation;
            table11.Parental_Counseling = grno.Recommendation.Parental_Counseling;
            table11.Any_other_Home = grno.Recommendation.Any_other_Home;
            table11.Home_Based_Program = grno.Recommendation.Home_Based_Program;
            table11.Special_School = grno.Recommendation.Special_School;
            table11.Medication = grno.Recommendation.Medication;
            table11.Any_other = grno.Recommendation.Any_other;
            db.Recommendations.Add(table11);

            db.SaveChanges();
            CaseHistoryID = table.CaseHistory_ID;
            return CaseHistoryID;

        }
    }
}