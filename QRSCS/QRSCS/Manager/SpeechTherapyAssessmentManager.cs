using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;
using System.Globalization;
using System.Threading;

namespace QRSCS.Manager
{
    public class SpeechTherapyAssessmentManager
    {

        int idid = -9;
        public int AddSpeechTherapyAssessment(SpeechTherapyAssessmentModel staid)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                Speech_Therapy_Assessment tbluser = new Speech_Therapy_Assessment();
                tbluser.GR_NO = staid.GR_NO;
                tbluser.Speech_Test_Image = staid.Speech_Test_Image;
                tbluser.Full_Name = staid.Full_Name;
                tbluser.Marks = staid.Marks;
                tbluser.Std_Class = staid.Std_Class;
                db.Speech_Therapy_Assessment.Add(tbluser);
                tbluser.Date = staid.Date_of_Assessment;
                int idid = db.SaveChanges();

                int SAid = tbluser.Speech_Therapy_Assessment_ID;
            }
            return idid;
        }
        public List<SpeechTherapyAssessmentModel> selectStudentSpeechAssessment()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.Speech_Therapy_Assessment.ToList();
                List<SpeechTherapyAssessmentModel> List = request.Select(x => new SpeechTherapyAssessmentModel
                {
                    GR_NO = x.GR_NO,
                    Speech_Test_Image = x.Speech_Test_Image,
                    Speech_Therapy_Assessment_ID = x.Speech_Therapy_Assessment_ID,
                    Date_of_Assessment = x.Date,

                }).ToList();
                return List;
            }
        }

        public List<SpeechAssessmentDTO> GetSpeechAssessmentPerformance(int id)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                List<SpeechAssessmentDTO> speechList = new List<SpeechAssessmentDTO>();
                var data = db.Speech_Therapy_Assessment.Where(x => x.GR_NO == id).ToList();
                var admission = db.New_Admission.FirstOrDefault(x => x.GR_NO == id);
                if (data != null && admission != null)
                {
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;
                    for (var i = 0; i < data.Count; i++)
                    {
                        SpeechAssessmentDTO s = new SpeechAssessmentDTO()
                        {
                            Name = textInfo.ToTitleCase(admission.Student_First_Name + " " + admission.Student_Last_Name),
                            Father_Name = textInfo.ToTitleCase(admission.Father_Name),
                            Disability = admission.Disability,
                            Year = DateTime.Parse(data[i].Date.ToString()).Year.ToString(),
                            Marks = data[i].Marks.Value
                        };
                        speechList.Add(s);
                    }
                }
                return speechList;
            }
        }

    }
}