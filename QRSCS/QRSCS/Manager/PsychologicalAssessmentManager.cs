using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class PsychologicalAssessmentManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int PA_ID = 0;
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
        //PA
        public int AddPsychologicalAssessment(PsychologicalAssessmentModel grno)
        {
            PsychologicalAssessment table = new PsychologicalAssessment();
            table.GR_NO = grno.GR_NO;
            table.Solosson_Intelligence_Test = grno.Solosson_Intelligence_Test;
            table.Draw_A_Person_Test = grno.Draw_A_Person_Test;
            table.Colored_Progressive_Matrices = grno.Colored_Progressive_Matrices;
            table.Standard_Progressive_Matrices = grno.Standard_Progressive_Matrices;
            table.Vineland_Adaptive_Behavior_Scales = grno.Vineland_Adaptive_Behavior_Scales;
            table.Childhood_Autism_Rating_Scale = grno.Childhood_Autism_Rating_Scale;
            table.Attention_Deficit_Hyperactive_Disorder_Test = grno.Attention_Deficit_Hyperactive_Disorder_Test;
            table.Children_Apperception_Thematic_Test = grno.Children_Apperception_Thematic_Test;
            table.Personality_Assessment = grno.Personality_Assessment;

            db.PsychologicalAssessments.Add(table);


            db.SaveChanges();
            PA_ID = table.PA_ID;
            return PA_ID;
        }
    }


}