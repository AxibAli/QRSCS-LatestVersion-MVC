using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class IntelligenceQuotientManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int IQ_ID = 0;
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

        //IQ
        public int AddIntelligenceQuotient(IntelligenceQuotientModelDTO grno)
        {
            IntelligenceQuotient table = new IntelligenceQuotient();
            table.GR_NO = grno.intelligenceQuotient.GR_NO;
            table.Communication=grno.intelligenceQuotient.Communication;
            table.Socialization = grno.intelligenceQuotient.Socialization;
            table.Self_Help_Skills = grno.intelligenceQuotient.Self_Help_Skills;
            table.Cognition = grno.intelligenceQuotient.Cognition;
            table.Physical_Development = grno.intelligenceQuotient.Physical_Development;
            table.Communication_Score = grno.intelligenceQuotient.Communication_Score;
            table.Socialization_Score = grno.intelligenceQuotient.Socialization_Score;
            table.Self_Help_Skills_Score = grno.intelligenceQuotient.Self_Help_Skills_Score;
            table.Cognition_Score = grno.intelligenceQuotient.Cognition_Score;
            table.Physical_Development_Score = grno.intelligenceQuotient.Physical_Development_Score;

            db.IntelligenceQuotients.Add(table);


            db.SaveChanges();
            IQ_ID = table.IQ_ID;
            return IQ_ID;
        }

    }
}