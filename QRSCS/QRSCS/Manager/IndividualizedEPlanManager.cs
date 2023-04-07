using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class IndividualizedEPlanManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        //        int IEPlan_ID = 0;
        //        public NewAdmissionModel CheckUserExists(string GR_No)
        //        {
        //            NewAdmissionModel obj = new NewAdmissionModel();

        //            int check = Convert.ToInt32(GR_No);
        //            var userdata = db.New_Admission.Where(x => x.GR_NO == check).Select(x => new { x.GR_NO, x.Student_First_Name, x.Student_Last_Name, x.Father_Name, x.Gender, x.Disability }).FirstOrDefault();
        //            if (userdata != null)
        //            {

        //                obj.Student_First_Name = userdata.Student_First_Name;
        //                obj.Student_Last_Name = userdata.Student_Last_Name;
        //                obj.Father_Name = userdata.Father_Name;
        //                obj.Gender = userdata.Gender;
        //                obj.Disability = userdata.Disability;
        //            }
        //            return obj;
        //        }
        //        //IEP
        //        public int AddIEPlan(IndividualizedEPlanModelDTO grno)
        //        {
        //            IEPlan table = new IEPlan();
        //            table.GR_No = grno.iEPlanModel.GR_No;
        //            table.Date_Of_Assessment = grno.iEPlanModel.Date_Of_Assessment;
        //            db.IEPlans.Add(table);
        //            IEPlan_ID = table.IEPlan_ID;


        //            MeetingInformation_IEP table2 = new MeetingInformation_IEP();
        //            table2.IEPlan_ID = grno.iEPlanModel.IEPlan_ID;
        //            table2.Initial_IEP = grno.meetingInformation.Initial_IEP;
        //            table2.Annual_Review = grno.meetingInformation.Annual_Review;
        //            table2.Review_Other_Than_Annaul_Review = grno.meetingInformation.Review_Other_Than_Annaul_Review;
        //            table2.Ammendment = grno.meetingInformation.Ammendment;
        //            table2.Communicating_Language = grno.meetingInformation.Communicating_Language;
        //            db.MeetingInformation_IEP.Add(table2);


        //            PresentLevel_IEP table3 = new PresentLevel_IEP();
        //            table3.IEPlan_ID = grno.iEPlanModel.IEPlan_ID;
        //            table3.Physical_Development = grno.presentLevel.Physical_Development;
        //            table3.Communication = grno.presentLevel.Communication;
        //            table3.Self_Help_Skills = grno.presentLevel.Self_Help_Skills;
        //            table3.Cognition = grno.presentLevel.Cognition;
        //            table3.Socialization = grno.presentLevel.Socialization;
        //            table3.Functional_Academic = grno.presentLevel.Functional_Academic;
        //            table3.Academic_Performance = grno.presentLevel.Academic_Performance;
        //            table3.PreVocational_Skills = grno.presentLevel.PreVocational_Skills;
        //            table3.Others = grno.presentLevel.Others;
        //            db.PresentLevel_IEP.Add(table3);

        //            SpecialInstructional_IEP table4 = new SpecialInstructional_IEP();
        //            table4.IEPlan_ID = grno.iEPlanModel.IEPlan_ID;
        //            table4.Question_1 = grno.specialInstructional.Question_1;
        //            table4.Question_2 = grno.specialInstructional.Question_2;
        //            table4.Question_3 = grno.specialInstructional.Question_3;
        //            table4.Question_4 = grno.specialInstructional.Question_4;
        //            table4.Question_5 = grno.specialInstructional.Question_5;
        //            table4.Question_6 = grno.specialInstructional.Question_6;
        //            db.SpecialInstructional_IEP.Add(table4);


        //            SupplementaryAids_IEP table5 = new SupplementaryAids_IEP();
        //            table5.IEPlan_ID = grno.iEPlanModel.IEPlan_ID;
        //            table5.Related_Services = grno.supplementaryAids.Related_Services;
        //            table5.Provider_Name = grno.supplementaryAids.Provider_Name;
        //            table5.Hours_per_week_ = grno.supplementaryAids.Hours_per_week_;
        //            table5.Location = grno.supplementaryAids.Location;
        //            table5.Program_Modifications = grno.supplementaryAids.Program_Modifications;
        //            table5.Recommended_Instructional_Interventions = grno.supplementaryAids.Recommended_Instructional_Interventions;
        //            db.SupplementaryAids_IEP.Add(table5);


        //            DevelopmentTeam_IEP table6 = new DevelopmentTeam_IEP();
        //            table6.IEPlan_ID = grno.iEPlanModel.IEPlan_ID;
        //            table6.DevelopmentTeam_Name = grno.developmentTeam.DevelopmentTeam_Name;
        //            table6.Team_Members_Signature = grno.developmentTeam.Team_Members_Signature;
        //            table6.Position = grno.developmentTeam.Position;
        //            db.DevelopmentTeam_IEP.Add(table6);


        //            db.SaveChanges();
        //            IEPlan_ID = table.IEPlan_ID;  
        //            return IEPlan_ID;
        //        }

        public int AddIEP(IndividualizedEPlanModelDTO grno)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var IsPresent = db.IEPlans.FirstOrDefault(x => x.GR_No == grno.iEPlanModel.GR_No);

                    var testYear = string.Empty;
                    if (IsPresent != null)
                    {
                        testYear = Convert.ToDateTime(IsPresent.Date_Of_Assessment).Year.ToString();
                    }
                    else testYear = "0000";
                    var currentYear = DateTime.Now.Year.ToString();

                    if (testYear != currentYear)
                    {
                        IEPlan table = new IEPlan();
                        table.GR_No = grno.iEPlanModel.GR_No;
                         table.Date_Of_Assessment = grno.iEPlanModel.Date_Of_Assessment.ToString();
                        db.IEPlans.Add(table);
                        var check = db.SaveChanges();

                        if (check > 0)
                        {
                            MeetingInformation_IEP table2 = new MeetingInformation_IEP();
                            table2.IEPlan_ID = table.IEPlan_ID;
                            table2.Initial_IEP = grno.meetingInformation.Initial_IEP;
                            table2.Date_Initial_IEP = grno.meetingInformation.Date_Initial_IEP;
                            table2.Annual_Review = grno.meetingInformation.Annual_Review;
                            table2.Date_Annual_Review = grno.meetingInformation.Date_Annual_Review;
                            table2.Review_Other_Than_Annaul_Review = grno.meetingInformation.Review_Other_Than_Annaul_Review;
                            table2.Date_Review_Other_Than_Annaul_Review = grno.meetingInformation.Date_Review_Other_Than_Annaul_Review;
                            table2.Ammendment = grno.meetingInformation.Ammendment;
                            table2.Date_Ammendment = grno.meetingInformation.Date_Ammendment;
                            table2.Communicating_Language = grno.meetingInformation.Communicating_Language;
                            db.MeetingInformation_IEP.Add(table2);

                            PresentLevel_IEP table3 = new PresentLevel_IEP();
                            table3.IEPlan_ID = table.IEPlan_ID;
                            table3.Physical_Development = grno.presentLevel.Physical_Development;
                            table3.Communication = grno.presentLevel.Communication;
                            table3.Self_Help_Skills = grno.presentLevel.Self_Help_Skills;
                            table3.Cognition = grno.presentLevel.Cognition;
                            table3.Socialization = grno.presentLevel.Socialization;
                            table3.Functional_Academic = grno.presentLevel.Functional_Academic;
                            table3.PreVocational_Skills = grno.presentLevel.PreVocational_Skills;
                            table3.Others = grno.presentLevel.Others;
                            db.PresentLevel_IEP.Add(table3);

                            IEP_Page3 table4 = new IEP_Page3();
                            table4.IEP_ID = table.IEPlan_ID;
                            table4.Goal_1 = grno.iEP_Page3.Goal_1;
                            table4.Goal_2 = grno.iEP_Page3.Goal_2;
                            table4.Goal_3 = grno.iEP_Page3.Goal_3;
                            table4.Goal_4 = grno.iEP_Page3.Goal_4;
                            table4.Goal_5 = grno.iEP_Page3.Goal_5;
                            table4.Goal_6 = grno.iEP_Page3.Goal_6;
                            table4.Goal_7 = grno.iEP_Page3.Goal_7;
                            table4.Goal_8 = grno.iEP_Page3.Goal_8;
                            table4.Goal_9 = grno.iEP_Page3.Goal_9;
                            table4.Goal_10 = grno.iEP_Page3.Goal_10;
                            table4.Goal_11 = grno.iEP_Page3.Goal_11;
                            table4.Goal_12 = grno.iEP_Page3.Goal_12;
                            table4.Provider_1 = grno.iEP_Page3.Provider_1;
                            table4.Provider_2 = grno.iEP_Page3.Provider_2;
                            table4.Provider_3 = grno.iEP_Page3.Provider_3;
                            table4.Provider_4 = grno.iEP_Page3.Provider_4;
                            table4.Provider_5 = grno.iEP_Page3.Provider_5;
                            table4.Provider_6 = grno.iEP_Page3.Provider_6;
                            table4.Provider_7 = grno.iEP_Page3.Provider_7;
                            table4.Provider_8 = grno.iEP_Page3.Provider_8;
                            table4.Provider_9 = grno.iEP_Page3.Provider_9;
                            table4.Provider_10 = grno.iEP_Page3.Provider_10;
                            table4.Provider_Others_1 = grno.iEP_Page3.Provider_Others_1;
                            table4.Provider_Other_2 = grno.iEP_Page3.Provider_Other_2;
                            table4.Evaluation_Method_1 = grno.iEP_Page3.Evaluation_Method_1;
                            table4.Evaluation_Method_2 = grno.iEP_Page3.Evaluation_Method_2;
                            table4.Evaluation_Method_3 = grno.iEP_Page3.Evaluation_Method_3;
                            table4.Evaluation_Method_4 = grno.iEP_Page3.Evaluation_Method_4;
                            table4.Evaluation_Method_5 = grno.iEP_Page3.Evaluation_Method_5;
                            table4.Evaluation_Method_6 = grno.iEP_Page3.Evaluation_Method_6;
                            table4.Evaluation_Method_7 = grno.iEP_Page3.Evaluation_Method_7;
                            table4.Evaluation_Method_8 = grno.iEP_Page3.Evaluation_Method_8;
                            table4.Evaluation_Method_9 = grno.iEP_Page3.Evaluation_Method_9;
                            table4.Evaluation_Method_10 = grno.iEP_Page3.Evaluation_Method_10;
                            table4.Evaluation_Method_Others_1 = grno.iEP_Page3.Evaluation_Method_Others_1;
                            table4.Evaluation_Method_Others_2 = grno.iEP_Page3.Evaluation_Method_Others_2;
                            table4.Initial_Date_1 = grno.iEP_Page3.Initial_Date_1;
                            table4.Initial_Date_2 = grno.iEP_Page3.Initial_Date_2;
                            table4.Initial_Date_3 = grno.iEP_Page3.Initial_Date_3;
                            table4.Initial_Date_4 = grno.iEP_Page3.Initial_Date_4;
                            table4.Initial_Date_5 = grno.iEP_Page3.Initial_Date_5;
                            table4.Initial_Date_6 = grno.iEP_Page3.Initial_Date_6;
                            table4.Initial_Date_7 = grno.iEP_Page3.Initial_Date_7;
                            table4.Initial_Date_8 = grno.iEP_Page3.Initial_Date_8;
                            table4.Initial_Date_9 = grno.iEP_Page3.Initial_Date_9;
                            table4.Initial_Date_10 = grno.iEP_Page3.Initial_Date_10;
                            table4.Initial_Date_11 = grno.iEP_Page3.Initial_Date_11;
                            table4.Initial_Date_12 = grno.iEP_Page3.Initial_Date_12;
                            table4.Check_Date_1 = grno.iEP_Page3.Check_Date_1;
                            table4.Check_Date_2 = grno.iEP_Page3.Check_Date_2;
                            table4.Check_Date_3 = grno.iEP_Page3.Check_Date_3;
                            table4.Check_Date_4 = grno.iEP_Page3.Check_Date_4;
                            table4.Check_Date_5 = grno.iEP_Page3.Check_Date_5;
                            table4.Check_Date_6 = grno.iEP_Page3.Check_Date_6;
                            table4.Check_Date_7 = grno.iEP_Page3.Check_Date_7;
                            table4.Check_Date_8 = grno.iEP_Page3.Check_Date_8;
                            table4.Check_Date_9 = grno.iEP_Page3.Check_Date_9;
                            table4.Check_Date_10 = grno.iEP_Page3.Check_Date_10;
                            table4.Check_Date_11 = grno.iEP_Page3.Check_Date_11;
                            table4.Check_Date_12 = grno.iEP_Page3.Check_Date_12;
                            table4.Mastery_Date_1 = grno.iEP_Page3.Mastery_Date_1;
                            table4.Mastery_Date_2 = grno.iEP_Page3.Mastery_Date_2;
                            table4.Mastery_Date_3 = grno.iEP_Page3.Mastery_Date_3;
                            table4.Mastery_Date_4 = grno.iEP_Page3.Mastery_Date_4;
                            table4.Mastery_Date_5 = grno.iEP_Page3.Mastery_Date_5;
                            table4.Mastery_Date_6 = grno.iEP_Page3.Mastery_Date_6;
                            table4.Mastery_Date_7 = grno.iEP_Page3.Mastery_Date_7;
                            table4.Mastery_Date_8 = grno.iEP_Page3.Mastery_Date_8;
                            table4.Mastery_Date_9 = grno.iEP_Page3.Mastery_Date_9;
                            table4.Mastery_Date_10 = grno.iEP_Page3.Mastery_Date_10;
                            table4.Mastery_Date_11 = grno.iEP_Page3.Mastery_Date_11;
                            table4.Mastery_Date_12 = grno.iEP_Page3.Mastery_Date_12;
                            db.IEP_Page3.Add(table4);

                            SpecialInstructional_IEP table5 = new SpecialInstructional_IEP();
                            table5.IEPlan_ID = table.IEPlan_ID;
                            table5.Question_1 = grno.specialInstructional.Question_1;
                            table5.Question_2 = grno.specialInstructional.Question_2;
                            table5.Question_3 = grno.specialInstructional.Question_3;
                            table5.Question_4 = grno.specialInstructional.Question_4;
                            table5.Question_5 = grno.specialInstructional.Question_5;
                            table5.Question_6 = grno.specialInstructional.Question_6;
                            db.SpecialInstructional_IEP.Add(table5);

                            SupplementaryAids_IEP table6 = new SupplementaryAids_IEP();
                            table6.IEPlan_ID = table.IEPlan_ID;
                            table6.Related_Services_1 = grno.supplementaryAids.Related_Services_1;
                            table6.Related_Services_2 = grno.supplementaryAids.Related_Services_2;
                            table6.Related_Services_3 = grno.supplementaryAids.Related_Services_3;
                            table6.Related_Services_4 = grno.supplementaryAids.Related_Services_4;
                            table6.Related_Services_5 = grno.supplementaryAids.Related_Services_5;
                            table6.Related_Services_6 = grno.supplementaryAids.Related_Services_6;
                            table6.Related_Services_7 = grno.supplementaryAids.Related_Services_7;
                            table6.Provider_Name_1 = grno.supplementaryAids.Provider_Name_1;
                            table6.Provider_Name_2 = grno.supplementaryAids.Provider_Name_2;
                            table6.Provider_Name_3 = grno.supplementaryAids.Provider_Name_3;
                            table6.Provider_Name_4 = grno.supplementaryAids.Provider_Name_4;
                            table6.Provider_Name_5 = grno.supplementaryAids.Provider_Name_5;
                            table6.Provider_Name_6 = grno.supplementaryAids.Provider_Name_6;
                            table6.Provider_Name_7 = grno.supplementaryAids.Provider_Name_7;
                            table6.Hours_per_week_1 = grno.supplementaryAids.Hours_per_week_1;
                            table6.Hours_per_week_2 = grno.supplementaryAids.Hours_per_week_2;
                            table6.Hours_per_week_3 = grno.supplementaryAids.Hours_per_week_3;
                            table6.Hours_per_week_4 = grno.supplementaryAids.Hours_per_week_4;
                            table6.Hours_per_week_5 = grno.supplementaryAids.Hours_per_week_5;
                            table6.Hours_per_week_6 = grno.supplementaryAids.Hours_per_week_6;
                            table6.Hours_per_week_7 = grno.supplementaryAids.Hours_per_week_7;
                            table6.Location_1 = grno.supplementaryAids.Location_1;
                            table6.Location_2 = grno.supplementaryAids.Location_2;
                            table6.Location_3 = grno.supplementaryAids.Location_3;
                            table6.Location_4 = grno.supplementaryAids.Location_4;
                            table6.Location_5 = grno.supplementaryAids.Location_5;
                            table6.Location_6 = grno.supplementaryAids.Location_6;
                            table6.Location_7 = grno.supplementaryAids.Location_7;
                            table6.Program_Modifications = grno.supplementaryAids.Program_Modifications;
                            table6.Recommended_Instructional_Interventions = grno.supplementaryAids.Recommended_Instructional_Interventions;
                            db.SupplementaryAids_IEP.Add(table6);

                            DevelopmentTeam_IEP table7 = new DevelopmentTeam_IEP();
                            table7.IEPlan_ID = table.IEPlan_ID;
                            table7.DevelopmentTeam_Name_1 = grno.developmentTeam.DevelopmentTeam_Name_1;
                            table7.DevelopmentTeam_Name_2 = grno.developmentTeam.DevelopmentTeam_Name_2;
                            table7.DevelopmentTeam_Name_3 = grno.developmentTeam.DevelopmentTeam_Name_3;
                            table7.DevelopmentTeam_Name_4 = grno.developmentTeam.DevelopmentTeam_Name_4;
                            table7.DevelopmentTeam_Name_5 = grno.developmentTeam.DevelopmentTeam_Name_5;
                            table7.DevelopmentTeam_Name_6 = grno.developmentTeam.DevelopmentTeam_Name_6;
                            table7.DevelopmentTeam_Name_7 = grno.developmentTeam.DevelopmentTeam_Name_7;
                            table7.Position_1 = grno.developmentTeam.Position_1;
                            table7.Position_2 = grno.developmentTeam.Position_2;
                            table7.Position_3 = grno.developmentTeam.Position_3;
                            table7.Position_4 = grno.developmentTeam.Position_4;
                            table7.Position_5 = grno.developmentTeam.Position_5;
                            table7.Position_6 = grno.developmentTeam.Position_6;
                            table7.Position_7 = grno.developmentTeam.Position_7;
                            db.DevelopmentTeam_IEP.Add(table7);

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

        public dynamic GetStudentById(int GRNO)
        {
            var data = db.New_Admission.Where(x => x.GR_NO == GRNO).Select(x => new { GRNO = x.GR_NO, Name = x.Student_First_Name + " " + x.Student_Last_Name, FatherName = x.Father_Name, Gender = x.Gender, Disability = x.Disability, Dob = x.Dob }).FirstOrDefault();

            return data;
        }

        public bool UpdateIEPData(IEPModel iEPModel)
        {
            var data = db.IEPlans.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID);

            data.Date_Of_Assessment = Convert.ToDateTime(iEPModel.Date_Of_Assessment).ToString();
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_1 = iEPModel.DevelopmentTeam_Name_1;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_2 = iEPModel.DevelopmentTeam_Name_2;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_3 = iEPModel.DevelopmentTeam_Name_3;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_4 = iEPModel.DevelopmentTeam_Name_4;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_5 = iEPModel.DevelopmentTeam_Name_5;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_6 = iEPModel.DevelopmentTeam_Name_6;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).DevelopmentTeam_Name_7 = iEPModel.DevelopmentTeam_Name_7;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_1 = iEPModel.Position_1;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_2 = iEPModel.Position_2;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_3 = iEPModel.Position_3;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_4 = iEPModel.Position_4;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_5 = iEPModel.Position_5;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_6 = iEPModel.Position_6;
            data.DevelopmentTeam_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Position_7 = iEPModel.Position_7;
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Initial_IEP = iEPModel.Initial_IEP;
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Date_Initial_IEP = Convert.ToDateTime(iEPModel.Date_Initial_IEP);
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Annual_Review = iEPModel.Annual_Review;
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Date_Annual_Review = Convert.ToDateTime(iEPModel.Date_Initial_IEP);
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Review_Other_Than_Annaul_Review = iEPModel.Review_Other_Than_Annaul_Review;
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Date_Review_Other_Than_Annaul_Review = Convert.ToDateTime(iEPModel.Date_Review_Other_Than_Annaul_Review);
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Ammendment = iEPModel.Ammendment;
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Date_Ammendment = Convert.ToDateTime(iEPModel.Date_Ammendment);
            data.MeetingInformation_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Communicating_Language = iEPModel.Communicating_Language;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_1 = iEPModel.Goal_1;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_2 = iEPModel.Goal_2;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_3 = iEPModel.Goal_3;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_4 = iEPModel.Goal_4;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_5 = iEPModel.Goal_5;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_6 = iEPModel.Goal_6;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_7 = iEPModel.Goal_7;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_8 = iEPModel.Goal_8;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_9 = iEPModel.Goal_9;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_10 = iEPModel.Goal_10;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_11 = iEPModel.Goal_11;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Goal_12 = iEPModel.Goal_12;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_1 = iEPModel.Provider_1;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_2 = iEPModel.Provider_2;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_3 = iEPModel.Provider_3;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_4 = iEPModel.Provider_4;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_5 = iEPModel.Provider_5;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_6 = iEPModel.Provider_6;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_7 = iEPModel.Provider_7;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_8 = iEPModel.Provider_8;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_9 = iEPModel.Provider_9;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_10 = iEPModel.Provider_10;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_Others_1 = iEPModel.Provider_Others_1;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Provider_Other_2 = iEPModel.Provider_Other_2;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_1 = iEPModel.Evaluation_Method_1;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_2 = iEPModel.Evaluation_Method_2;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_3 = iEPModel.Evaluation_Method_3;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_4 = iEPModel.Evaluation_Method_4;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_5 = iEPModel.Evaluation_Method_5;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_6 = iEPModel.Evaluation_Method_6;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_7 = iEPModel.Evaluation_Method_7;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_8 = iEPModel.Evaluation_Method_8;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_9 = iEPModel.Evaluation_Method_9;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_10 = iEPModel.Evaluation_Method_10;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_Others_1 = iEPModel.Evaluation_Method_Others_1;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Evaluation_Method_Others_2 = iEPModel.Evaluation_Method_Others_2;
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_1 = Convert.ToDateTime(iEPModel.Initial_Date_1);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_2 = Convert.ToDateTime(iEPModel.Initial_Date_2);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_3 = Convert.ToDateTime(iEPModel.Initial_Date_3);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_4 = Convert.ToDateTime(iEPModel.Initial_Date_4);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_5 = Convert.ToDateTime(iEPModel.Initial_Date_5);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_6 = Convert.ToDateTime(iEPModel.Initial_Date_6);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_7 = Convert.ToDateTime(iEPModel.Initial_Date_7);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_8 = Convert.ToDateTime(iEPModel.Initial_Date_8);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_9 = Convert.ToDateTime(iEPModel.Initial_Date_9);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_10 = Convert.ToDateTime(iEPModel.Initial_Date_10);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_11 = Convert.ToDateTime(iEPModel.Initial_Date_11);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Initial_Date_12 = Convert.ToDateTime(iEPModel.Initial_Date_12);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_1 = Convert.ToDateTime(iEPModel.Check_Date_1);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_2 = Convert.ToDateTime(iEPModel.Check_Date_2);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_3 = Convert.ToDateTime(iEPModel.Check_Date_3);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_4 = Convert.ToDateTime(iEPModel.Check_Date_4);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_5 = Convert.ToDateTime(iEPModel.Check_Date_5);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_6 = Convert.ToDateTime(iEPModel.Check_Date_6);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_7 = Convert.ToDateTime(iEPModel.Check_Date_7);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_8 = Convert.ToDateTime(iEPModel.Check_Date_8);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_9 = Convert.ToDateTime(iEPModel.Check_Date_9);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_10 = Convert.ToDateTime(iEPModel.Check_Date_10);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_11 = Convert.ToDateTime(iEPModel.Check_Date_11);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Check_Date_12 = Convert.ToDateTime(iEPModel.Check_Date_12);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_1 = Convert.ToDateTime(iEPModel.Mastery_Date_1);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_2 = Convert.ToDateTime(iEPModel.Mastery_Date_2);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_3 = Convert.ToDateTime(iEPModel.Mastery_Date_3);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_4 = Convert.ToDateTime(iEPModel.Mastery_Date_4);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_5 = Convert.ToDateTime(iEPModel.Mastery_Date_5);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_6 = Convert.ToDateTime(iEPModel.Mastery_Date_6);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_7 = Convert.ToDateTime(iEPModel.Mastery_Date_7);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_8 = Convert.ToDateTime(iEPModel.Mastery_Date_8);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_9 = Convert.ToDateTime(iEPModel.Mastery_Date_9);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_10 = Convert.ToDateTime(iEPModel.Mastery_Date_10);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_11 = Convert.ToDateTime(iEPModel.Mastery_Date_11);
            data.IEP_Page3.FirstOrDefault(x => x.IEP_ID == iEPModel.IEPlan_ID).Mastery_Date_12 = Convert.ToDateTime(iEPModel.Mastery_Date_12);
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Physical_Development = iEPModel.Physical_Development;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Communication = iEPModel.Communication;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Self_Help_Skills = iEPModel.Self_Help_Skills;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Cognition = iEPModel.Cognition;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Socialization = iEPModel.Socialization;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Functional_Academic = iEPModel.Functional_Academic;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Academic_Performance = iEPModel.Academic_Performance;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).PreVocational_Skills = iEPModel.PreVocational_Skills;
            data.PresentLevel_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Others = iEPModel.Others;
            data.SpecialInstructional_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Question_1 = iEPModel.Question_1;
            data.SpecialInstructional_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Question_2 = iEPModel.Question_2;
            data.SpecialInstructional_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Question_3 = iEPModel.Question_3;
            data.SpecialInstructional_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Question_4 = iEPModel.Question_4;
            data.SpecialInstructional_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Question_5 = iEPModel.Question_5;
            data.SpecialInstructional_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Question_6 = iEPModel.Question_6;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_1 = iEPModel.Related_Services_1;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_2 = iEPModel.Related_Services_2;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_3 = iEPModel.Related_Services_3;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_4 = iEPModel.Related_Services_4;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_5 = iEPModel.Related_Services_5;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_6 = iEPModel.Related_Services_6;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Related_Services_7 = iEPModel.Related_Services_7;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_1 = iEPModel.Provider_Name_1;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_2 = iEPModel.Provider_Name_2;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_3 = iEPModel.Provider_Name_3;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_4 = iEPModel.Provider_Name_4;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_5 = iEPModel.Provider_Name_5;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_6 = iEPModel.Provider_Name_6;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Provider_Name_7 = iEPModel.Provider_Name_7;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_1 = iEPModel.Hours_per_week_1;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_2 = iEPModel.Hours_per_week_2;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_3 = iEPModel.Hours_per_week_3;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_4 = iEPModel.Hours_per_week_4;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_5 = iEPModel.Hours_per_week_5;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_6 = iEPModel.Hours_per_week_6;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Hours_per_week_7 = iEPModel.Hours_per_week_7;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_1 = iEPModel.Location_1;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_2 = iEPModel.Location_2;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_3 = iEPModel.Location_3;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_4 = iEPModel.Location_4;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_5 = iEPModel.Location_5;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_6 = iEPModel.Location_6;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Location_7 = iEPModel.Location_7;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Program_Modifications = iEPModel.Program_Modifications;
            data.SupplementaryAids_IEP.FirstOrDefault(x => x.IEPlan_ID == iEPModel.IEPlan_ID).Recommended_Instructional_Interventions = iEPModel.Recommended_Instructional_Interventions;

            db.Entry(data).State = EntityState.Modified;
            int isSaved = db.SaveChanges();
            if (isSaved > 0) return true;
            return false;
        }

        public dynamic GetIEPDatabyId(int GRNO)
        {
            try
            {
                List<IEPData> iEPDatas = new List<IEPData>();

                var data = db.IEPlans.Where(x => x.GR_No == GRNO).ToList();
                if (data == null) return null;
                var iEPlan = db.IEPlans.ToList();

                for (var i = 0; i < data.Count; i++)
                {
                    IEPData iEPData = new IEPData();
                    var ieplan = iEPlan.Where(x => x.GR_No == data[i].GR_No).ToList();

                    iEPData.Year = Convert.ToDateTime(data[i].Date_Of_Assessment).Year.ToString();
                    iEPData.IEP_ID = data[i].IEPlan_ID;
                    iEPDatas.Add(iEPData);
                }

                return iEPDatas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEPModel GetIEPData(int IEP_ID, int GRNO)

        {
            try
            {
                var student = db.New_Admission.FirstOrDefault(x => x.GR_NO == GRNO);

                var result = (from o in db.IEPlans
                              join d in db.DevelopmentTeam_IEP on o.IEPlan_ID equals d.IEPlan_ID
                              join m in db.MeetingInformation_IEP on o.IEPlan_ID equals m.IEPlan_ID
                              join p in db.IEP_Page3 on o.IEPlan_ID equals p.IEP_ID
                              join pl in db.PresentLevel_IEP on o.IEPlan_ID equals pl.IEPlan_ID
                              join s in db.SpecialInstructional_IEP on o.IEPlan_ID equals s.IEPlan_ID
                              join sa in db.SupplementaryAids_IEP on o.IEPlan_ID equals sa.IEPlan_ID
                              where o.IEPlan_ID == IEP_ID
                              select new
                              {
                                  IEPlan_ID = o.IEPlan_ID,
                                  Date_Of_Assessment = o.Date_Of_Assessment,
                                  DevelopmentTeam_Name_1 = d.DevelopmentTeam_Name_1,
                                  DevelopmentTeam_Name_2 = d.DevelopmentTeam_Name_2,
                                  DevelopmentTeam_Name_3 = d.DevelopmentTeam_Name_3,
                                  DevelopmentTeam_Name_4 = d.DevelopmentTeam_Name_4,
                                  DevelopmentTeam_Name_5 = d.DevelopmentTeam_Name_5,
                                  DevelopmentTeam_Name_6 = d.DevelopmentTeam_Name_6,
                                  DevelopmentTeam_Name_7 = d.DevelopmentTeam_Name_7,
                                  Position_1 = d.Position_1,
                                  Position_2 = d.Position_2,
                                  Position_3 = d.Position_3,
                                  Position_4 = d.Position_4,
                                  Position_5 = d.Position_5,
                                  Position_6 = d.Position_6,
                                  Position_7 = d.Position_7,
                                  Initial_IEP = m.Initial_IEP,
                                  Date_Initial_IEP = m.Date_Initial_IEP,
                                  Annual_Review = m.Annual_Review,
                                  Date_Annual_Review = m.Date_Annual_Review,
                                  Review_Other_Than_Annaul_Review = m.Review_Other_Than_Annaul_Review,
                                  Date_Review_Other_Than_Annaul_Review = m.Date_Review_Other_Than_Annaul_Review,
                                  Ammendment = m.Ammendment,
                                  Date_Ammendment = m.Date_Ammendment,
                                  Communicating_Language = m.Communicating_Language,
                                  Goal_1 = p.Goal_1,
                                  Goal_2 = p.Goal_2,
                                  Goal_3 = p.Goal_3,
                                  Goal_4 = p.Goal_4,
                                  Goal_5 = p.Goal_5,
                                  Goal_6 = p.Goal_6,
                                  Goal_7 = p.Goal_7,
                                  Goal_8 = p.Goal_8,
                                  Goal_9 = p.Goal_9,
                                  Goal_10 = p.Goal_10,
                                  Goal_11 = p.Goal_11,
                                  Goal_12 = p.Goal_12,
                                  Provider_1 = p.Provider_1,
                                  Provider_2 = p.Provider_2,
                                  Provider_3 = p.Provider_3,
                                  Provider_4 = p.Provider_4,
                                  Provider_5 = p.Provider_5,
                                  Provider_6 = p.Provider_6,
                                  Provider_7 = p.Provider_7,
                                  Provider_8 = p.Provider_8,
                                  Provider_9 = p.Provider_9,
                                  Provider_10 = p.Provider_10,
                                  Provider_Others_1 = p.Provider_Others_1,
                                  Provider_Other_2 = p.Provider_Other_2,
                                  Evaluation_Method_1 = p.Evaluation_Method_1,
                                  Evaluation_Method_2 = p.Evaluation_Method_2,
                                  Evaluation_Method_3 = p.Evaluation_Method_3,
                                  Evaluation_Method_4 = p.Evaluation_Method_4,
                                  Evaluation_Method_5 = p.Evaluation_Method_5,
                                  Evaluation_Method_6 = p.Evaluation_Method_6,
                                  Evaluation_Method_7 = p.Evaluation_Method_7,
                                  Evaluation_Method_8 = p.Evaluation_Method_8,
                                  Evaluation_Method_9 = p.Evaluation_Method_9,
                                  Evaluation_Method_10 = p.Evaluation_Method_10,
                                  Evaluation_Method_Others_1 = p.Evaluation_Method_Others_1,
                                  Evaluation_Method_Others_2 = p.Evaluation_Method_Others_2,
                                  Initial_Date_1 = p.Initial_Date_1,
                                  Initial_Date_2 = p.Initial_Date_2,
                                  Initial_Date_3 = p.Initial_Date_3,
                                  Initial_Date_4 = p.Initial_Date_4,
                                  Initial_Date_5 = p.Initial_Date_5,
                                  Initial_Date_6 = p.Initial_Date_6,
                                  Initial_Date_7 = p.Initial_Date_7,
                                  Initial_Date_8 = p.Initial_Date_8,
                                  Initial_Date_9 = p.Initial_Date_9,
                                  Initial_Date_10 = p.Initial_Date_10,
                                  Initial_Date_11 = p.Initial_Date_11,
                                  Initial_Date_12 = p.Initial_Date_12,
                                  Check_Date_1 = p.Check_Date_1,
                                  Check_Date_2 = p.Check_Date_2,
                                  Check_Date_3 = p.Check_Date_3,
                                  Check_Date_4 = p.Check_Date_4,
                                  Check_Date_5 = p.Check_Date_5,
                                  Check_Date_6 = p.Check_Date_6,
                                  Check_Date_7 = p.Check_Date_7,
                                  Check_Date_8 = p.Check_Date_8,
                                  Check_Date_9 = p.Check_Date_9,
                                  Check_Date_10 = p.Check_Date_10,
                                  Check_Date_11 = p.Check_Date_11,
                                  Check_Date_12 = p.Check_Date_12,
                                  Mastery_Date_1 = p.Mastery_Date_1,
                                  Mastery_Date_2 = p.Mastery_Date_2,
                                  Mastery_Date_3 = p.Mastery_Date_3,
                                  Mastery_Date_4 = p.Mastery_Date_4,
                                  Mastery_Date_5 = p.Mastery_Date_5,
                                  Mastery_Date_6 = p.Mastery_Date_6,
                                  Mastery_Date_7 = p.Mastery_Date_7,
                                  Mastery_Date_8 = p.Mastery_Date_8,
                                  Mastery_Date_9 = p.Mastery_Date_9,
                                  Mastery_Date_10 = p.Mastery_Date_10,
                                  Mastery_Date_11 = p.Mastery_Date_11,
                                  Mastery_Date_12 = p.Mastery_Date_12,
                                  Physical_Development = pl.Physical_Development,
                                  Communication = pl.Communication,
                                  Self_Help_Skills = pl.Self_Help_Skills,
                                  Cognition = pl.Cognition,
                                  Socialization = pl.Socialization,
                                  Functional_Academic = pl.Functional_Academic,
                                  Academic_Performance = pl.Academic_Performance,
                                  PreVocational_Skills = pl.PreVocational_Skills,
                                  Others = pl.Others,
                                  Question_1 = s.Question_1,
                                  Question_2 = s.Question_2,
                                  Question_3 = s.Question_3,
                                  Question_4 = s.Question_4,
                                  Question_5 = s.Question_5,
                                  Question_6 = s.Question_6,
                                  Related_Services_1 = sa.Related_Services_1,
                                  Related_Services_2 = sa.Related_Services_2,
                                  Related_Services_3 = sa.Related_Services_3,
                                  Related_Services_4 = sa.Related_Services_4,
                                  Related_Services_5 = sa.Related_Services_5,
                                  Related_Services_6 = sa.Related_Services_6,
                                  Related_Services_7 = sa.Related_Services_7,
                                  Provider_Name_1 = sa.Provider_Name_1,
                                  Provider_Name_2 = sa.Provider_Name_2,
                                  Provider_Name_3 = sa.Provider_Name_3,
                                  Provider_Name_4 = sa.Provider_Name_4,
                                  Provider_Name_5 = sa.Provider_Name_5,
                                  Provider_Name_6 = sa.Provider_Name_6,
                                  Provider_Name_7 = sa.Provider_Name_7,
                                  Hours_per_week_1 = sa.Hours_per_week_1,
                                  Hours_per_week_2 = sa.Hours_per_week_2,
                                  Hours_per_week_3 = sa.Hours_per_week_3,
                                  Hours_per_week_4 = sa.Hours_per_week_4,
                                  Hours_per_week_5 = sa.Hours_per_week_5,
                                  Hours_per_week_6 = sa.Hours_per_week_6,
                                  Hours_per_week_7 = sa.Hours_per_week_7,
                                  Location_1 = sa.Location_1,
                                  Location_2 = sa.Location_2,
                                  Location_3 = sa.Location_3,
                                  Location_4 = sa.Location_4,
                                  Location_5 = sa.Location_5,
                                  Location_6 = sa.Location_6,
                                  Location_7 = sa.Location_7,
                                  Program_Modifications = sa.Program_Modifications,
                                  Recommended_Instructional_Interventions = sa.Recommended_Instructional_Interventions,
                              }).FirstOrDefault();

                //var newdate = Convert.ToDateTime(result.Date_Of_Assessment).ToString("yyyy-MM-dd");
                //var dt = newdate;
                //var newdate = "2022-05-02"; 

                IEPModel ePlanModelDTO = new IEPModel()
                {
                    StudentName = student.Student_First_Name + " " + student.Student_Last_Name,
                    FatherName = student.Father_Name,
                    Dob = Convert.ToDateTime(student.Dob).ToString("yyyy-MM-dd"),
                    Disability = student.Disability,
                    Gender = student.Gender,
                    GR_No = student.GR_NO,
                    IEPlan_ID = result.IEPlan_ID,
                    Date_Of_Assessment = Convert.ToDateTime(result.Date_Of_Assessment).ToString("yyyy-MM-dd"),
                    DevelopmentTeam_Name_1 = result.DevelopmentTeam_Name_1,
                    DevelopmentTeam_Name_2 = result.DevelopmentTeam_Name_2,
                    DevelopmentTeam_Name_3 = result.DevelopmentTeam_Name_3,
                    DevelopmentTeam_Name_4 = result.DevelopmentTeam_Name_4,
                    DevelopmentTeam_Name_5 = result.DevelopmentTeam_Name_5,
                    DevelopmentTeam_Name_6 = result.DevelopmentTeam_Name_6,
                    DevelopmentTeam_Name_7 = result.DevelopmentTeam_Name_7,
                    Position_1 = result.Position_1,
                    Position_2 = result.Position_2,
                    Position_3 = result.Position_3,
                    Position_4 = result.Position_4,
                    Position_5 = result.Position_5,
                    Position_6 = result.Position_6,
                    Position_7 = result.Position_7,
                    Initial_IEP = Convert.ToBoolean(result.Initial_IEP),
                    Date_Initial_IEP = Convert.ToDateTime(result.Date_Initial_IEP).ToString("yyyy-MM-dd"),
                    Annual_Review = Convert.ToBoolean(result.Annual_Review),
                    Date_Annual_Review = Convert.ToDateTime(result.Date_Annual_Review).ToString("yyyy-MM-dd"),
                    Review_Other_Than_Annaul_Review = Convert.ToBoolean(result.Review_Other_Than_Annaul_Review),
                    Date_Review_Other_Than_Annaul_Review = Convert.ToDateTime(result.Date_Review_Other_Than_Annaul_Review).ToString("yyyy-MM-dd"),
                    Ammendment = Convert.ToBoolean(result.Ammendment),
                    Date_Ammendment = Convert.ToDateTime(result.Date_Ammendment).ToString("yyyy-MM-dd"),
                    Communicating_Language = result.Communicating_Language,
                    Goal_1 = result.Goal_1,
                    Goal_2 = result.Goal_2,
                    Goal_3 = result.Goal_3,
                    Goal_4 = result.Goal_4,
                    Goal_5 = result.Goal_5,
                    Goal_6 = result.Goal_6,
                    Goal_7 = result.Goal_7,
                    Goal_8 = result.Goal_8,
                    Goal_9 = result.Goal_9,
                    Goal_10 = result.Goal_10,
                    Goal_11 = result.Goal_11,
                    Goal_12 = result.Goal_12,
                    Provider_1 = result.Provider_1,
                    Provider_2 = result.Provider_2,
                    Provider_3 = result.Provider_3,
                    Provider_4 = result.Provider_4,
                    Provider_5 = result.Provider_5,
                    Provider_6 = result.Provider_6,
                    Provider_7 = result.Provider_7,
                    Provider_8 = result.Provider_8,
                    Provider_9 = result.Provider_9,
                    Provider_10 = result.Provider_10,
                    Provider_Others_1 = result.Provider_Others_1,
                    Provider_Other_2 = result.Provider_Other_2,
                    Evaluation_Method_1 = result.Evaluation_Method_1,
                    Evaluation_Method_2 = result.Evaluation_Method_2,
                    Evaluation_Method_3 = result.Evaluation_Method_3,
                    Evaluation_Method_4 = result.Evaluation_Method_4,
                    Evaluation_Method_5 = result.Evaluation_Method_5,
                    Evaluation_Method_6 = result.Evaluation_Method_6,
                    Evaluation_Method_7 = result.Evaluation_Method_7,
                    Evaluation_Method_8 = result.Evaluation_Method_8,
                    Evaluation_Method_9 = result.Evaluation_Method_9,
                    Evaluation_Method_10 = result.Evaluation_Method_10,
                    Evaluation_Method_Others_1 = result.Evaluation_Method_Others_1,
                    Evaluation_Method_Others_2 = result.Evaluation_Method_Others_2,
                    Initial_Date_1 = Convert.ToDateTime(result.Initial_Date_1).ToString("yyyy-MM-dd"),
                    Initial_Date_2 = Convert.ToDateTime(result.Initial_Date_2).ToString("yyyy-MM-dd"),
                    Initial_Date_3 = Convert.ToDateTime(result.Initial_Date_3).ToString("yyyy-MM-dd"),
                    Initial_Date_4 = Convert.ToDateTime(result.Initial_Date_4).ToString("yyyy-MM-dd"),
                    Initial_Date_5 = Convert.ToDateTime(result.Initial_Date_5).ToString("yyyy-MM-dd"),
                    Initial_Date_6 = Convert.ToDateTime(result.Initial_Date_6).ToString("yyyy-MM-dd"),
                    Initial_Date_7 = Convert.ToDateTime(result.Initial_Date_7).ToString("yyyy-MM-dd"),
                    Initial_Date_8 = Convert.ToDateTime(result.Initial_Date_8).ToString("yyyy-MM-dd"),
                    Initial_Date_9 = Convert.ToDateTime(result.Initial_Date_9).ToString("yyyy-MM-dd"),
                    Initial_Date_10 = Convert.ToDateTime(result.Initial_Date_10).ToString("yyyy-MM-dd"),
                    Initial_Date_11 = Convert.ToDateTime(result.Initial_Date_11).ToString("yyyy-MM-dd"),
                    Initial_Date_12 = Convert.ToDateTime(result.Initial_Date_12).ToString("yyyy-MM-dd"),
                    Check_Date_1 = Convert.ToDateTime(result.Check_Date_1).ToString("yyyy-MM-dd"),
                    Check_Date_2 = Convert.ToDateTime(result.Check_Date_2).ToString("yyyy-MM-dd"),
                    Check_Date_3 = Convert.ToDateTime(result.Check_Date_3).ToString("yyyy-MM-dd"),
                    Check_Date_4 = Convert.ToDateTime(result.Check_Date_4).ToString("yyyy-MM-dd"),
                    Check_Date_5 = Convert.ToDateTime(result.Check_Date_5).ToString("yyyy-MM-dd"),
                    Check_Date_6 = Convert.ToDateTime(result.Check_Date_6).ToString("yyyy-MM-dd"),
                    Check_Date_7 = Convert.ToDateTime(result.Check_Date_7).ToString("yyyy-MM-dd"),
                    Check_Date_8 = Convert.ToDateTime(result.Check_Date_8).ToString("yyyy-MM-dd"),
                    Check_Date_9 = Convert.ToDateTime(result.Check_Date_9).ToString("yyyy-MM-dd"),
                    Check_Date_10 = Convert.ToDateTime(result.Check_Date_10).ToString("yyyy-MM-dd"),
                    Check_Date_11 = Convert.ToDateTime(result.Check_Date_11).ToString("yyyy-MM-dd"),
                    Check_Date_12 = Convert.ToDateTime(result.Check_Date_12).ToString("yyyy-MM-dd"),
                    Mastery_Date_2 = Convert.ToDateTime(result.Mastery_Date_2).ToString("yyyy-MM-dd"),
                    Mastery_Date_1 = Convert.ToDateTime(result.Mastery_Date_1).ToString("yyyy-MM-dd"),
                    Mastery_Date_3 = Convert.ToDateTime(result.Mastery_Date_3).ToString("yyyy-MM-dd"),
                    Mastery_Date_4 = Convert.ToDateTime(result.Mastery_Date_4).ToString("yyyy-MM-dd"),
                    Mastery_Date_5 = Convert.ToDateTime(result.Mastery_Date_5).ToString("yyyy-MM-dd"),
                    Mastery_Date_6 = Convert.ToDateTime(result.Mastery_Date_6).ToString("yyyy-MM-dd"),
                    Mastery_Date_7 = Convert.ToDateTime(result.Mastery_Date_7).ToString("yyyy-MM-dd"),
                    Mastery_Date_8 = Convert.ToDateTime(result.Mastery_Date_8).ToString("yyyy-MM-dd"),
                    Mastery_Date_9 = Convert.ToDateTime(result.Mastery_Date_9).ToString("yyyy-MM-dd"),
                    Mastery_Date_10 = Convert.ToDateTime(result.Mastery_Date_10).ToString("yyyy-MM-dd"),
                    Mastery_Date_11 = Convert.ToDateTime(result.Mastery_Date_11).ToString("yyyy-MM-dd"),
                    Mastery_Date_12 = Convert.ToDateTime(result.Mastery_Date_12).ToString("yyyy-MM-dd"),
                    Physical_Development = result.Physical_Development,
                    Communication = result.Communication,
                    Self_Help_Skills = result.Self_Help_Skills,
                    Cognition = result.Cognition,
                    Socialization = result.Socialization,
                    Functional_Academic = result.Functional_Academic,
                    Academic_Performance = result.Academic_Performance,
                    PreVocational_Skills = result.PreVocational_Skills,
                    Others = result.Others,
                    Question_1 = result.Question_1,
                    Question_2 = result.Question_2,
                    Question_3 = result.Question_3,
                    Question_4 = result.Question_4,
                    Question_5 = result.Question_5,
                    Question_6 = result.Question_6,
                    Related_Services_1 = result.Related_Services_1,
                    Related_Services_2 = result.Related_Services_2,
                    Related_Services_3 = result.Related_Services_3,
                    Related_Services_4 = result.Related_Services_4,
                    Related_Services_5 = result.Related_Services_5,
                    Related_Services_6 = result.Related_Services_6,
                    Related_Services_7 = result.Related_Services_7,
                    Provider_Name_1 = result.Provider_Name_1,
                    Provider_Name_2 = result.Provider_Name_2,
                    Provider_Name_3 = result.Provider_Name_3,
                    Provider_Name_4 = result.Provider_Name_4,
                    Provider_Name_5 = result.Provider_Name_5,
                    Provider_Name_6 = result.Provider_Name_6,
                    Provider_Name_7 = result.Provider_Name_7,
                    Hours_per_week_1 = result.Hours_per_week_1.Value,
                    Hours_per_week_2 = result.Hours_per_week_2.Value,
                    Hours_per_week_3 = result.Hours_per_week_3.Value,
                    Hours_per_week_4 = result.Hours_per_week_4.Value,
                    Hours_per_week_5 = result.Hours_per_week_5.Value,
                    Hours_per_week_6 = result.Hours_per_week_6.Value,
                    Hours_per_week_7 = result.Hours_per_week_7.Value,
                    Location_1 = result.Location_1,
                    Location_2 = result.Location_2,
                    Location_3 = result.Location_3,
                    Location_4 = result.Location_4,
                    Location_5 = result.Location_5,
                    Location_6 = result.Location_6,
                    Location_7 = result.Location_7,
                    Program_Modifications = result.Program_Modifications,
                    Recommended_Instructional_Interventions = result.Recommended_Instructional_Interventions,
                };

                return ePlanModelDTO;

            }
            catch (Exception)
            {
                return null;
            }
        }


    }

    public class IEPData
    {
        public string Year { get; set; }
        public int IEP_ID { get; set; }
        //public IEPlan IEPlan { get; set; }
        //public DevelopmentTeam_IEP DevelopmentTeam_IEP { get; set; }
        //public MeetingInformation_IEP meetingInformation_IEP { get; set; }
        //public IEP_Page3 iEP_Page3 { get; set; }
        //public PresentLevel_IEP presentLevel { get; set; }
        //public SpecialInstructional_IEP specialInstructional_IEP { get; set; }
        //public SupplementaryAids_IEP supplementaryAids { get; set; }
    }
}