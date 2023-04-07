using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class OccupationalTherapy2Manager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        public NewAdmissionModel CheckUserExists(string GR_No)
        {
            NewAdmissionModel obj = new NewAdmissionModel();

            int check = Convert.ToInt32(GR_No);
            var userdata = db.New_Admission.Where(x => x.GR_NO == check).Select(x => new { x.GR_NO, x.Student_First_Name, x.Student_Last_Name, x.Father_Name, x.Gender, x.Disability, x.Dob }).FirstOrDefault();
            if (userdata != null)
            {
                obj.Student_First_Name = userdata.Student_First_Name;
                obj.Student_Last_Name = userdata.Student_Last_Name;
                obj.Father_Name = userdata.Father_Name;
                obj.Gender = userdata.Gender;
                obj.Disability = userdata.Disability;
                obj.Dob = userdata.Dob;
            }
            return obj;
        }

        //Occupational Therapy 2
        public int AddOccupationalTherapy2(OccupationalTherapy2ModelDTO grno)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var IsPresent = db.OccupationalTherapy2.FirstOrDefault(x => x.GR_NO == grno.occupationalTherapy2.GR_NO);

                    var testYear = string.Empty;
                    if (IsPresent != null)
                    {
                        testYear = Convert.ToDateTime(IsPresent.Test_Date).Year.ToString();
                    }
                    else testYear = "0000";
                    var currentYear = DateTime.Now.Year.ToString();

                    if (testYear != currentYear)
                    {
                        OccupationalTherapy2 table = new OccupationalTherapy2();
                        table.GR_NO = grno.occupationalTherapy2.GR_NO;
                        table.Test_Date = grno.occupationalTherapy2.Test_Date;
                        table.Examiner_Name = grno.occupationalTherapy2.Examiner_Name;
                        table.Examiner_Profession = grno.occupationalTherapy2.Examiner_Profession;
                        table.Caregiver_Name = grno.occupationalTherapy2.Caregiver_Name;
                        table.Caregiver_Relationship = grno.occupationalTherapy2.Caregiver_Relationship;
                        table.Name_Of_School = grno.occupationalTherapy2.Name_Of_School;
                        table.School_Level = grno.occupationalTherapy2.School_Level;
                        table.Child_Order = grno.occupationalTherapy2.Child_Order;
                        table.Children_Years_Living = grno.occupationalTherapy2.Children_Years_Living;
                        db.OccupationalTherapy2.Add(table);
                        var check = db.SaveChanges();

                        if (check > 0)
                        {
                            AuditoryProcessing_OT2 table2 = new AuditoryProcessing_OT2();
                            table2.OT2_ID = table.OT2_ID;
                            table2.AV_1 = grno.auditoryProcessing.AV_1;
                            table2.AV_2 = grno.auditoryProcessing.AV_2;
                            table2.SN_3 = grno.auditoryProcessing.SN_3;
                            table2.SN_4 = grno.auditoryProcessing.SN_4;
                            table2.AV_5 = grno.auditoryProcessing.AV_5;
                            table2.SN_6 = grno.auditoryProcessing.SN_6;
                            table2.SN_7 = grno.auditoryProcessing.SN_7;
                            table2.RG_8 = grno.auditoryProcessing.RG_8;
                            table2.Auditory_Raw_Score = grno.auditoryProcessing.Auditory_Raw_Score;
                            table2.Auditory_Comments = grno.auditoryProcessing.Auditory_Comments;
                            db.AuditoryProcessing_OT2.Add(table2);

                            VisualProcessing_OT2 table3 = new VisualProcessing_OT2();
                            table3.OT2_ID = table.OT2_ID;
                            table3.SN_9 = grno.visualProcessing.SN_9;
                            table3.SN_11 = grno.visualProcessing.SN_11;
                            table3.RG_12 = grno.visualProcessing.RG_12;
                            table3.SN_13 = grno.visualProcessing.SN_13;
                            table3.SK_14 = grno.visualProcessing.SK_14;
                            table3.AV_15 = grno.visualProcessing.AV_15;
                            table3.Visual_Raw_Score = grno.visualProcessing.Visual_Raw_Score;
                            table3.Visual_Comments = grno.visualProcessing.Visual_Comments;
                            db.VisualProcessing_OT2.Add(table3);

                            TouchProcessing_OT2 table4 = new TouchProcessing_OT2();
                            table4.OT2_ID = table.OT2_ID;
                            table4.SN_16 = grno.touchProcessing.SN_16;
                            table4.SN_17 = grno.touchProcessing.SN_17;
                            table4.AV_18 = grno.touchProcessing.AV_18;
                            table4.SN_19 = grno.touchProcessing.SN_19;
                            table4.SN_20 = grno.touchProcessing.SN_20;
                            table4.SK_21 = grno.touchProcessing.SK_21;
                            table4.SK_22 = grno.touchProcessing.SK_22;
                            table4.RG_23 = grno.touchProcessing.RG_23;
                            table4.RG_24 = grno.touchProcessing.RG_24;
                            table4.SK_25 = grno.touchProcessing.SK_25;
                            table4.RG_26 = grno.touchProcessing.RG_26;
                            table4.Touch_Raw_Score = grno.touchProcessing.Touch_Raw_Score;
                            table4.Touch_Comments = grno.touchProcessing.Touch_Comments;
                            db.TouchProcessing_OT2.Add(table4);


                            MovementProcessing_OT2 table5 = new MovementProcessing_OT2();
                            table5.OT2_ID = table.OT2_ID;
                            table5.SK_27 = grno.movementProcessing.SK_27;
                            table5.SK_28 = grno.movementProcessing.SK_28;
                            table5.SK_29 = grno.movementProcessing.SK_29;
                            table5.SK_30 = grno.movementProcessing.SK_30;
                            table5.SK_31 = grno.movementProcessing.SK_31;
                            table5.SK_32 = grno.movementProcessing.SK_32;
                            table5.RG_33 = grno.movementProcessing.RG_33;
                            table5.RG_34 = grno.movementProcessing.RG_34;
                            table5.Movement_Raw_Score = grno.movementProcessing.Movement_Raw_Score;
                            table5.Movement_Comments = grno.movementProcessing.Movement_Comments;
                            db.MovementProcessing_OT2.Add(table5);

                            BodyPositionProcessing_OT2 table6 = new BodyPositionProcessing_OT2();
                            table6.OT2_ID = table.OT2_ID;
                            table6.RG_35 = grno.bodyPositionProcessing.RG_35;
                            table6.RG_36 = grno.bodyPositionProcessing.RG_36;
                            table6.RG_37 = grno.bodyPositionProcessing.RG_37;
                            table6.RG_38 = grno.bodyPositionProcessing.RG_38;
                            table6.RG_39 = grno.bodyPositionProcessing.RG_39;
                            table6.RG_40 = grno.bodyPositionProcessing.RG_40;
                            table6.SK_41 = grno.bodyPositionProcessing.SK_41;
                            table6.SK_42 = grno.bodyPositionProcessing.SK_42;
                            table6.Body_Postion_Raw_Score = grno.bodyPositionProcessing.Body_Postion_Raw_Score;
                            table6.Body_Position_Comments = grno.bodyPositionProcessing.Body_Position_Comments;
                            db.BodyPositionProcessing_OT2.Add(table6);

                            OralSensoryProcessing_OT2 table7 = new OralSensoryProcessing_OT2();
                            table7.OT2_ID = table.OT2_ID;
                            table7.SN_44 = grno.oralSensoryProcessing.SN_44;
                            table7.SN_45 = grno.oralSensoryProcessing.SN_45;
                            table7.SN_46 = grno.oralSensoryProcessing.SN_46;
                            table7.SN_47 = grno.oralSensoryProcessing.SN_47;
                            table7.SK_48 = grno.oralSensoryProcessing.SK_48;
                            table7.SK_49 = grno.oralSensoryProcessing.SK_49;
                            table7.SK_50 = grno.oralSensoryProcessing.SK_50;
                            table7.SK_51 = grno.oralSensoryProcessing.SK_51;
                            table7.SN_52 = grno.oralSensoryProcessing.SN_52;
                            table7.Oral_Sensory_Raw_Score = grno.oralSensoryProcessing.Oral_Sensory_Raw_Score;
                            table7.Oral_Sensory_Comments = grno.oralSensoryProcessing.Oral_Sensory_Comments;
                            db.OralSensoryProcessing_OT2.Add(table7);

                            ConductProcessing_OT2 table8 = new ConductProcessing_OT2();
                            table8.OT2_ID = table.OT2_ID;
                            table8.RG_53 = grno.conductProcessing.RG_53;
                            table8.RG_54 = grno.conductProcessing.RG_54;
                            table8.SK_55 = grno.conductProcessing.SK_55;
                            table8.SK_56 = grno.conductProcessing.SK_56;
                            table8.RG_57 = grno.conductProcessing.RG_57;
                            table8.AV_58 = grno.conductProcessing.AV_58;
                            table8.AV_59 = grno.conductProcessing.AV_59;
                            table8.SK_60 = grno.conductProcessing.SK_60;
                            table8.AV_61 = grno.conductProcessing.AV_61;
                            table8.Conduct_Raw_Score = grno.conductProcessing.Conduct_Raw_Score;
                            table8.Conduct_Comments = grno.conductProcessing.Conduct_Comments;
                            db.ConductProcessing_OT2.Add(table8);

                            SocialEmotionalProcessing_OT2 table9 = new SocialEmotionalProcessing_OT2();
                            table9.OT2_ID = table.OT2_ID;
                            table9.RG_62 = grno.socialEmotionalProcessing.RG_62;
                            table9.AV_63 = grno.socialEmotionalProcessing.AV_63;
                            table9.AV_64 = grno.socialEmotionalProcessing.AV_64;
                            table9.AV_65 = grno.socialEmotionalProcessing.AV_65;
                            table9.AV_66 = grno.socialEmotionalProcessing.AV_66;
                            table9.AV_67 = grno.socialEmotionalProcessing.AV_67;
                            table9.AV_68 = grno.socialEmotionalProcessing.AV_68;
                            table9.SN_69 = grno.socialEmotionalProcessing.SN_69;
                            table9.AV_70 = grno.socialEmotionalProcessing.AV_70;
                            table9.AV_71 = grno.socialEmotionalProcessing.AV_71;
                            table9.AV_72 = grno.socialEmotionalProcessing.AV_72;
                            table9.SN_73 = grno.socialEmotionalProcessing.SN_73;
                            table9.AV_74 = grno.socialEmotionalProcessing.AV_74;
                            table9.AV_75 = grno.socialEmotionalProcessing.AV_75;
                            table9.Social_Emotional_Score = grno.socialEmotionalProcessing.Social_Emotional_Score;
                            table9.Social_Emotional_Comments = grno.socialEmotionalProcessing.Social_Emotional_Comments;
                            db.SocialEmotionalProcessing_OT2.Add(table9);

                            AttentionalProcessing_OT2 table10 = new AttentionalProcessing_OT2();
                            table10.OT2_ID = table.OT2_ID;
                            table10.RG_76 = grno.attentionalProcessing.RG_76;
                            table10.SN_77 = grno.attentionalProcessing.SN_77;
                            table10.SN_78 = grno.attentionalProcessing.SN_78;
                            table10.RG_79 = grno.attentionalProcessing.RG_79;
                            table10.RG_80 = grno.attentionalProcessing.RG_80;
                            table10.AV_81 = grno.attentionalProcessing.AV_81;
                            table10.SK_82 = grno.attentionalProcessing.SK_82;
                            table10.SK_83 = grno.attentionalProcessing.SK_83;
                            table10.SN_84 = grno.attentionalProcessing.SN_84;
                            table10.RG_85 = grno.attentionalProcessing.RG_85;
                            table10.RG_86 = grno.attentionalProcessing.RG_86;
                            table10.Attentional_Score = grno.attentionalProcessing.Attentional_Score;
                            table10.Attentional_Comments = grno.attentionalProcessing.Attentional_Comments;
                            db.AttentionalProcessing_OT2.Add(table10);

                            Seeking_OT2 table11 = new Seeking_OT2();
                            table11.OT2_ID = table.OT2_ID;
                            table11.Raw_Score_14 = grno.seekingOT2.Raw_Score_14;
                            table11.Raw_Score_22 = grno.seekingOT2.Raw_Score_22;
                            table11.Raw_Score_25 = grno.seekingOT2.Raw_Score_25;
                            table11.Raw_Score_27 = grno.seekingOT2.Raw_Score_27;
                            table11.Raw_Score_28 = grno.seekingOT2.Raw_Score_28;
                            table11.Raw_Score_30 = grno.seekingOT2.Raw_Score_30;
                            table11.Raw_Score_31 = grno.seekingOT2.Raw_Score_31;
                            table11.Raw_Score_32 = grno.seekingOT2.Raw_Score_32;
                            table11.Raw_Score_41 = grno.seekingOT2.Raw_Score_41;
                            table11.Raw_Score_48 = grno.seekingOT2.Raw_Score_48;
                            table11.Raw_Score_49 = grno.seekingOT2.Raw_Score_49;
                            table11.Raw_Score_50 = grno.seekingOT2.Raw_Score_50;
                            table11.Raw_Score_51 = grno.seekingOT2.Raw_Score_51;
                            table11.Raw_Score_55 = grno.seekingOT2.Raw_Score_55;
                            table11.Raw_Score_56 = grno.seekingOT2.Raw_Score_56;
                            table11.Raw_Score_60 = grno.seekingOT2.Raw_Score_60;
                            table11.Raw_Score_62 = grno.seekingOT2.Raw_Score_62;
                            table11.Raw_Score_63 = grno.seekingOT2.Raw_Score_63;
                            table11.Seeking_Score = grno.seekingOT2.Seeking_Score;
                            db.Seeking_OT2.Add(table11);

                            Avoiding_OT2 table12 = new Avoiding_OT2();
                            table12.OT2_ID = table.OT2_ID;
                            table12.Raw_Score_1 = grno.avoidingOT2.Raw_Score_1;
                            table12.Raw_Score_2 = grno.avoidingOT2.Raw_Score_2;
                            table12.Raw_Score_5 = grno.avoidingOT2.Raw_Score_5;
                            table12.Raw_Score_15 = grno.avoidingOT2.Raw_Score_15;
                            table12.Raw_Score_18 = grno.avoidingOT2.Raw_Score_18;
                            table12.Raw_Score_58 = grno.avoidingOT2.Raw_Score_58;
                            table12.Raw_Score_59 = grno.avoidingOT2.Raw_Score_59;
                            table12.Raw_Score_61 = grno.avoidingOT2.Raw_Score_61;
                            table12.Raw_Score_63 = grno.avoidingOT2.Raw_Score_63;
                            table12.Raw_Score_64 = grno.avoidingOT2.Raw_Score_64;
                            table12.Raw_Score_65 = grno.avoidingOT2.Raw_Score_65;
                            table12.Raw_Score_66 = grno.avoidingOT2.Raw_Score_66;
                            table12.Raw_Score_67 = grno.avoidingOT2.Raw_Score_67;
                            table12.Raw_Score_68 = grno.avoidingOT2.Raw_Score_68;
                            table12.Raw_Score_70 = grno.avoidingOT2.Raw_Score_70;
                            table12.Raw_Score_71 = grno.avoidingOT2.Raw_Score_71;
                            table12.Raw_Score_72 = grno.avoidingOT2.Raw_Score_72;
                            table12.Raw_Score_74 = grno.avoidingOT2.Raw_Score_74;
                            table12.Raw_Score_75 = grno.avoidingOT2.Raw_Score_75;
                            table12.Raw_Score_81 = grno.avoidingOT2.Raw_Score_81;
                            table12.Avoiding_Score = grno.avoidingOT2.Avoiding_Score;
                            db.Avoiding_OT2.Add(table12);

                            Sensitivity_OT2 table13 = new Sensitivity_OT2();
                            table13.OT2_ID = table.OT2_ID;
                            table13.Raw_Score_3 = grno.sensitivityOT2.Raw_Score_3;
                            table13.Raw_Score_4 = grno.sensitivityOT2.Raw_Score_4;
                            table13.Raw_Score_6 = grno.sensitivityOT2.Raw_Score_6;
                            table13.Raw_Score_7 = grno.sensitivityOT2.Raw_Score_7;
                            table13.Raw_Score_9 = grno.sensitivityOT2.Raw_Score_9;
                            table13.Raw_Score_10 = grno.sensitivityOT2.Raw_Score_10;
                            table13.Raw_Score_13 = grno.sensitivityOT2.Raw_Score_13;
                            table13.Raw_Score_16 = grno.sensitivityOT2.Raw_Score_16;
                            table13.Raw_Score_19 = grno.sensitivityOT2.Raw_Score_19;
                            table13.Raw_Score_20 = grno.sensitivityOT2.Raw_Score_20;
                            table13.Raw_Score_44 = grno.sensitivityOT2.Raw_Score_44;
                            table13.Raw_Score_45 = grno.sensitivityOT2.Raw_Score_45;
                            table13.Raw_Score_46 = grno.sensitivityOT2.Raw_Score_46;
                            table13.Raw_Score_47 = grno.sensitivityOT2.Raw_Score_47;
                            table13.Raw_Score_52 = grno.sensitivityOT2.Raw_Score_52;
                            table13.Raw_Score_69 = grno.sensitivityOT2.Raw_Score_69;
                            table13.Raw_Score_73 = grno.sensitivityOT2.Raw_Score_73;
                            table13.Raw_Score_77 = grno.sensitivityOT2.Raw_Score_77;
                            table13.Raw_Score_78 = grno.sensitivityOT2.Raw_Score_78;
                            table13.Raw_Score_84 = grno.sensitivityOT2.Raw_Score_84;
                            table13.Sensitivity_Score = grno.sensitivityOT2.Sensitivity_Score;
                            db.Sensitivity_OT2.Add(table13);

                            Registration_OT2 table14 = new Registration_OT2();
                            table14.OT2_ID = table.OT2_ID;
                            table14.Raw_Score_12 = grno.registrationOT2.Raw_Score_12;
                            table14.Raw_Score_23 = grno.registrationOT2.Raw_Score_23;
                            table14.Raw_Score_24 = grno.registrationOT2.Raw_Score_24;
                            table14.Raw_Score_26 = grno.registrationOT2.Raw_Score_26;
                            table14.Raw_Score_33 = grno.registrationOT2.Raw_Score_33;
                            table14.Raw_Score_34 = grno.registrationOT2.Raw_Score_34;
                            table14.Raw_Score_35 = grno.registrationOT2.Raw_Score_35;
                            table14.Raw_Score_36 = grno.registrationOT2.Raw_Score_36;
                            table14.Raw_Score_37 = grno.registrationOT2.Raw_Score_37;
                            table14.Raw_Score_38 = grno.registrationOT2.Raw_Score_38;
                            table14.Raw_Score_39 = grno.registrationOT2.Raw_Score_39;
                            table14.Raw_Score_40 = grno.registrationOT2.Raw_Score_40;
                            table14.Raw_Score_53 = grno.registrationOT2.Raw_Score_53;
                            table14.Raw_Score_54 = grno.registrationOT2.Raw_Score_54;
                            table14.Raw_Score_57 = grno.registrationOT2.Raw_Score_57;
                            table14.Raw_Score_62 = grno.registrationOT2.Raw_Score_62;
                            table14.Raw_Score_79 = grno.registrationOT2.Raw_Score_79;
                            table14.Raw_Score_80 = grno.registrationOT2.Raw_Score_80;
                            table14.Raw_Score_85 = grno.registrationOT2.Raw_Score_85;
                            table14.Raw_Score_86 = grno.registrationOT2.Raw_Score_86;
                            table14.Registration_Score = grno.registrationOT2.Registration_Score;
                            db.Registration_OT2.Add(table14);

                            int check2 = db.SaveChanges();
                            transaction.Commit();
                            if (check2 > 0)
                            {
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        return 2;
                    }

                    return 0;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return 0;
                }
            }

        }

        private string Remarks(int score)
        {
            if (score < 20) return "Hypo";
            else if (score >= 20 && score < 48) return "Normal";
            else if (score >= 48 && score < 96) return "Hyper";
            else return "Cannot Evaluate";
        }
        public dynamic GetOT2PerformanceListbyId(int GRNO, bool isCurrentYear)
        {
            try
            {
                List<OT2Performance> performances = new List<OT2Performance>();

                var data = db.OccupationalTherapy2.Where(x => x.GR_NO == GRNO).ToList();
                if (data == null) return null;
                var SeekingOT2DB = db.Seeking_OT2.ToList();
                var AvoidingOT2DB = db.Avoiding_OT2.ToList();
                var SensitivityOT2DB = db.Sensitivity_OT2.ToList();
                var RegistrationOT2DB = db.Registration_OT2.ToList();

                if (!isCurrentYear)
                {

                    for (var i = 0; i < data.Count; i++)
                    {
                        OT2Performance performance = new OT2Performance();
                        var SeekingOT2 = SeekingOT2DB.Where(x => x.OT2_ID == data[i].OT2_ID).ToList();
                        var AvoidingOT2 = AvoidingOT2DB.Where(x => x.OT2_ID == data[i].OT2_ID).ToList();
                        var SensitivityOT2 = SensitivityOT2DB.Where(x => x.OT2_ID == data[i].OT2_ID).ToList();
                        var RegistrationOT2 = RegistrationOT2DB.Where(x => x.OT2_ID == data[i].OT2_ID).ToList();

                        performance.Year = data[i].Test_Date.Value.Year.ToString();
                        performance.Seeking = Remarks(SeekingOT2[0].Seeking_Score.Value);
                        performance.SeekingValue = Convert.ToInt32((Convert.ToDouble(SeekingOT2[0].Seeking_Score.Value) / 95) * 100);
                        performance.Avoiding = Remarks(AvoidingOT2[0].Avoiding_Score.Value);
                        performance.AvoidingValue = Convert.ToInt32((Convert.ToDouble(AvoidingOT2[0].Avoiding_Score.Value) / 100) * 100);
                        performance.Sensitivity = Remarks(SensitivityOT2[0].Sensitivity_Score.Value);
                        performance.SensitivityValue = Convert.ToInt32((Convert.ToDouble(SeekingOT2[0].Seeking_Score.Value) / 95) * 100);
                        performance.Registration = Remarks(RegistrationOT2[0].Registration_Score.Value);
                        performance.RegistrationValue = Convert.ToInt32((Convert.ToDouble(RegistrationOT2[0].Registration_Score.Value) / 110) * 100);
                        performances.Add(performance);
                    }

                    return performances;
                }
                else
                {
                    var SeekingOT2 = SeekingOT2DB.OrderByDescending(x => x.OT2_ID).Where(x => x.OT2_ID == data[0].OT2_ID).ToList();
                    var AvoidingOT2 = AvoidingOT2DB.OrderByDescending(x => x.OT2_ID).Where(x => x.OT2_ID == data[0].OT2_ID).ToList();
                    var SensitivityOT2 = SensitivityOT2DB.OrderByDescending(x => x.OT2_ID).Where(x => x.OT2_ID == data[0].OT2_ID).ToList();
                    var RegistrationOT2 = RegistrationOT2DB.OrderByDescending(x => x.OT2_ID).Where(x => x.OT2_ID == data[0].OT2_ID).ToList();


                    OT2Performance performance = new OT2Performance();
                    performance.Year = data[0].Test_Date.Value.Year.ToString();
                    performance.Seeking = Remarks(SeekingOT2[0].Seeking_Score.Value);
                    performance.SeekingValue = Convert.ToInt32((Convert.ToDouble(SeekingOT2[0].Seeking_Score.Value) / 95) * 100);
                    performance.Avoiding = Remarks(AvoidingOT2[0].Avoiding_Score.Value);
                    performance.AvoidingValue = Convert.ToInt32((Convert.ToDouble(AvoidingOT2[0].Avoiding_Score.Value) / 100) * 100);
                    performance.Sensitivity = Remarks(SensitivityOT2[0].Sensitivity_Score.Value);
                    performance.SensitivityValue = Convert.ToInt32((Convert.ToDouble(SeekingOT2[0].Seeking_Score.Value) / 95) * 100);
                    performance.Registration = Remarks(RegistrationOT2[0].Registration_Score.Value);
                    performance.RegistrationValue = Convert.ToInt32((Convert.ToDouble(RegistrationOT2[0].Registration_Score.Value) / 110) * 100);

                    performances.Add(performance);

                    return performances;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public dynamic GetStudentById(int GRNO)
        {
            var data = db.New_Admission.Where(x => x.GR_NO == GRNO).Select(x => new { Name = x.Student_First_Name + " " + x.Student_Last_Name, FatherName = x.Father_Name }).FirstOrDefault();

            return data;
        }
    }
    public class OT2Performance
    {
        public string Year { get; set; }
        public string Seeking { get; set; }
        public int SeekingValue { get; set; }
        public string Avoiding { get; set; }
        public int AvoidingValue { get; set; }
        public string Sensitivity { get; set; }
        public int SensitivityValue { get; set; }
        public string Registration { get; set; }
        public int RegistrationValue { get; set; }
    }
}