﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QRSCS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class New_QRSCS_DatabaseEntities : DbContext
    {
        public New_QRSCS_DatabaseEntities()
            : base("name=New_QRSCS_DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Assign_Teacher> Assign_Teacher { get; set; }
        public virtual DbSet<AttentionalProcessing_OT2> AttentionalProcessing_OT2 { get; set; }
        public virtual DbSet<Audiology_Assessment> Audiology_Assessment { get; set; }
        public virtual DbSet<AuditoryProcessing_OT2> AuditoryProcessing_OT2 { get; set; }
        public virtual DbSet<Avoiding_OT2> Avoiding_OT2 { get; set; }
        public virtual DbSet<Behavioral_Observation> Behavioral_Observation { get; set; }
        public virtual DbSet<BehavioralTherapy> BehavioralTherapies { get; set; }
        public virtual DbSet<BodyPositionProcessing_OT2> BodyPositionProcessing_OT2 { get; set; }
        public virtual DbSet<Case_History> Case_History { get; set; }
        public virtual DbSet<Conclusion> Conclusions { get; set; }
        public virtual DbSet<ConductProcessing_OT2> ConductProcessing_OT2 { get; set; }
        public virtual DbSet<Create_Teacher> Create_Teacher { get; set; }
        public virtual DbSet<Development_History> Development_History { get; set; }
        public virtual DbSet<Developmental_History> Developmental_History { get; set; }
        public virtual DbSet<DevelopmentTeam_IEP> DevelopmentTeam_IEP { get; set; }
        public virtual DbSet<Education_History> Education_History { get; set; }
        public virtual DbSet<Expressive_Langauage> Expressive_Langauage { get; set; }
        public virtual DbSet<Family_History> Family_History { get; set; }
        public virtual DbSet<General_Information> General_Information { get; set; }
        public virtual DbSet<HistoryPregnancy_PT> HistoryPregnancy_PT { get; set; }
        public virtual DbSet<IDD_Result> IDD_Result { get; set; }
        public virtual DbSet<IEP_Page3> IEP_Page3 { get; set; }
        public virtual DbSet<IEPlan> IEPlans { get; set; }
        public virtual DbSet<IntelligenceQuotient> IntelligenceQuotients { get; set; }
        public virtual DbSet<Medical_History> Medical_History { get; set; }
        public virtual DbSet<MedicalInformation_PT> MedicalInformation_PT { get; set; }
        public virtual DbSet<MeetingInformation_IEP> MeetingInformation_IEP { get; set; }
        public virtual DbSet<MidTerm_Result> MidTerm_Result { get; set; }
        public virtual DbSet<Milestone_PT> Milestone_PT { get; set; }
        public virtual DbSet<MovementProcessing_OT2> MovementProcessing_OT2 { get; set; }
        public virtual DbSet<New_Admission> New_Admission { get; set; }
        public virtual DbSet<OccupationalTherapy1> OccupationalTherapy1 { get; set; }
        public virtual DbSet<OccupationalTherapy2> OccupationalTherapy2 { get; set; }
        public virtual DbSet<OralSensoryProcessing_OT2> OralSensoryProcessing_OT2 { get; set; }
        public virtual DbSet<OT1_Page1> OT1_Page1 { get; set; }
        public virtual DbSet<OT1_Page2> OT1_Page2 { get; set; }
        public virtual DbSet<OT1_Page3> OT1_Page3 { get; set; }
        public virtual DbSet<Particulars_of_Sibling> Particulars_of_Sibling { get; set; }
        public virtual DbSet<PhysicalAssessment_PT> PhysicalAssessment_PT { get; set; }
        public virtual DbSet<Physiotherapy> Physiotherapies { get; set; }
        public virtual DbSet<Post_Natal> Post_Natal { get; set; }
        public virtual DbSet<PresentLevel_IEP> PresentLevel_IEP { get; set; }
        public virtual DbSet<Psycho_Social_Factors> Psycho_Social_Factors { get; set; }
        public virtual DbSet<PsychologicalAssessment> PsychologicalAssessments { get; set; }
        public virtual DbSet<Receptive_langauge> Receptive_langauge { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<Registration_OT2> Registration_OT2 { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Seeking_OT2> Seeking_OT2 { get; set; }
        public virtual DbSet<Sensitivity_OT2> Sensitivity_OT2 { get; set; }
        public virtual DbSet<SocialEmotionalProcessing_OT2> SocialEmotionalProcessing_OT2 { get; set; }
        public virtual DbSet<Speach_and_Langauge> Speach_and_Langauge { get; set; }
        public virtual DbSet<Speach_Case_History> Speach_Case_History { get; set; }
        public virtual DbSet<SpecialInstructional_IEP> SpecialInstructional_IEP { get; set; }
        public virtual DbSet<Speech_Therapy_Assessment> Speech_Therapy_Assessment { get; set; }
        public virtual DbSet<Student_Current_Class> Student_Current_Class { get; set; }
        public virtual DbSet<Student_Current_Status> Student_Current_Status { get; set; }
        public virtual DbSet<Student_Result_Status> Student_Result_Status { get; set; }
        public virtual DbSet<SupplementaryAids_IEP> SupplementaryAids_IEP { get; set; }
        public virtual DbSet<TestDone_PT> TestDone_PT { get; set; }
        public virtual DbSet<TouchProcessing_OT2> TouchProcessing_OT2 { get; set; }
        public virtual DbSet<TreatmentPlan_PT> TreatmentPlan_PT { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VisualProcessing_OT2> VisualProcessing_OT2 { get; set; }
        public virtual DbSet<Week1_BT> Week1_BT { get; set; }
        public virtual DbSet<Week2_BT> Week2_BT { get; set; }
        public virtual DbSet<Week3_BT> Week3_BT { get; set; }
        public virtual DbSet<Week4_BT> Week4_BT { get; set; }
    }
}
