using QRSCS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace QRSCS.Manager
{
    public class AudioAssessmentManager
    {
        private double SplitString(string data)
        {
            if (data != null)
            {
                data = data.Replace(",", " ");
                string[] result = data.Split(' ');
                var sum = 0;
                for (var i = 0; i < result.Count(); i++)
                {
                    sum += Convert.ToInt32(result[i]);
                }

                double avg = Convert.ToDouble(sum) / Convert.ToDouble(result.Count());
                return avg;
            }
            else
            {
                return 0.0;
            }
        }

        public string UpdateAudiologyAssessment(AssessmentModel assessment, int GrNo)
        {
            DateTime myDateTime = DateTime.Now;
            string Currentyear = myDateTime.Year.ToString();
            string year = Currentyear;

            var LeftEarHL = SplitString(assessment.LeftEarAirUnmaskedHearingLevel);
            var RightEarHL = SplitString(assessment.RightEarAirUnmaskedHearingLevel);

            var response = string.Empty;
            int id = GrNo;
            if (id == 0) return "Gr No# is required to Add Record of Audiology";

            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var CheckHI = db.New_Admission.FirstOrDefault(x => x.GR_NO.Equals(id));

                var data = db.Audiology_Assessment.Where(a => a.GR_NO.Equals(GrNo)).OrderByDescending(b => b.Audiology_Assessment_ID).FirstOrDefault();

                if (data != null)
                {
                    year = DateTime.Parse(data.Date_of_Assessment.ToString()).Year.ToString();
                }

                if (CheckHI.Disability == "H.I")
                {
                    if (data == null || year != Currentyear)
                    {
                        Audiology_Assessment audio = new Audiology_Assessment()
                        {
                            Date_of_Assessment = DateTime.Now,
                            GR_NO = id,
                            Left_Ear_Air_UnmaskedFrequency = assessment.LeftEarAirUnmaskedFrequecy,
                            Left_Ear_Bone_MaskedFrequency = assessment.LeftEarBoneMaskedFrequecy,
                            Left_Ear_Air_Unmasked_HearingLevel = assessment.LeftEarAirUnmaskedHearingLevel,
                            Left_Ear_Bone_Masked_HearingLevel = assessment.LeftEarBoneMaskedHearingLevel,
                            Right_Ear_Air_UnmaskedFrequency = assessment.RightEarAirUnmaskedFrequecy,
                            Right_Ear_Bone_MaskedFrequency = assessment.RightEarBoneMaskedFrequecy,
                            Right_Ear_Air_Unmasked_HearingLevel = assessment.RightEarAirUnmaskedHearingLevel,
                            Right_Ear_Bone_Masked_HearingLevel = assessment.RightEarBoneMaskedHearingLevel,
                            Left_Ear_Mean = LeftEarHL.ToString(),
                            Right_Ear_Mean = RightEarHL.ToString(),
                        };

                        db.Audiology_Assessment.Add(audio);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            response = "Saved Successfully";
                        }
                    }
                }
                else
                {
                    return "Not H.I";
                }
            }
            return response;
        }

        public AudioAssessmentDTO GetAudiologyAssessment(int id)
        {
            AudioAssessmentDTO Emptylist = new AudioAssessmentDTO();
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                DateTime myDateTime = DateTime.Now;
                var Currentyear = myDateTime.Year;

                var dateFrom = Convert.ToDateTime(1 + "-" + 1 + "-" + Currentyear);
                var dateTo = Convert.ToDateTime(12 + "-" + 31 + "-" + Currentyear);

                var data = db.New_Admission.Where(a => a.GR_NO.Equals(id) && a.Disability == "H.I").FirstOrDefault();

                var IsPresent = db.Audiology_Assessment.Any(x => x.GR_NO == id && x.Date_of_Assessment >= dateFrom && x.Date_of_Assessment <= dateTo);

                if (data != null)
                {
                    var forDate = db.Audiology_Assessment.Where(a => a.GR_NO.Equals(id)).OrderByDescending(b => b.Audiology_Assessment_ID).FirstOrDefault();
                    var testDate = string.Empty;

                    if (forDate == null)
                    {
                        testDate = "No Test Done";
                    }
                    else testDate = forDate.Date_of_Assessment.ToShortDateString();

                    var student = db.New_Admission.Where(a => a.GR_NO.Equals(id)).FirstOrDefault();

                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;

                    AudioAssessmentDTO assessment = new AudioAssessmentDTO()
                    {
                        GR_NO = id,
                        Name = textInfo.ToTitleCase(student.Student_First_Name + " " + student.Student_Last_Name),
                        Father_Name = textInfo.ToTitleCase(student.Father_Name),
                        Disability = student.Disability,
                        Test_Date = testDate,
                        IsPresent = IsPresent,
                        IsContent = true
                    };
                    return assessment;
                }
                return Emptylist;
            }
        }

        private string getLevel(string data)
        {
            var result = string.Empty;
            var startIndex = data.IndexOf(".");
            if (startIndex != -1)
            {
                var subString = data.Substring(startIndex, data.Length - 2);
                var final = data.Replace(subString, string.Empty);
                int val = Convert.ToInt32(final);
                if (val == 0) result = "Cannot be Evaluated";
                else if (val >= 16 && val <= 25) result = "Normal";
                else if (val >= 26 && val <= 40) result = "Mild";
                else if (val >= 41 && val <= 55) result = "Moderate";
                else if (val >= 56 && val <= 70) result = "Moderately Severe";
                else if (val >= 71 && val <= 90) result = "Severe";
                else if (val >= 91) result = "Profound";
                return result;
            }
            else
            {
                int val = Convert.ToInt32(data);
                if (val == 0) result = "Cannot be Evaluated";
                else if (val >= 16 && val <= 25) result = "Normal";
                else if (val >= 26 && val <= 40) result = "Mild";
                else if (val >= 41 && val <= 55) result = "Moderate";
                else if (val >= 56 && val <= 70) result = "Moderately Severe";
                else if (val >= 71 && val <= 90) result = "Severe";
                else if (val >= 91) result = "Profound";
                return result;
            }
        }
        public List<AudiologyAssessmentPerformanceDTO> GetAssessmentPerformance(int id)
        {
            List<AudiologyAssessmentPerformanceDTO> EmptyList = new List<AudiologyAssessmentPerformanceDTO>();
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                List<AudiologyAssessmentPerformanceDTO> ad = new List<AudiologyAssessmentPerformanceDTO>();
                var data = db.Audiology_Assessment.Where(x => x.GR_NO == id).ToList();
                if (data != null)
                {
                    var person = (from p in db.New_Admission
                                  join e in db.Audiology_Assessment
                                  on p.GR_NO equals e.GR_NO
                                  where p.GR_NO == id
                                  select new
                                  {
                                      Name = p.Student_First_Name + " " + p.Student_Last_Name,
                                      Father_Name = p.Father_Name,
                                      Disability = p.Disability,

                                  }).ToList();
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;
                    for (var i = 0; i < data.Count; i++)
                    {

                        AudiologyAssessmentPerformanceDTO a = new AudiologyAssessmentPerformanceDTO()
                        {
                            Audiology_Assessment_ID = data[i].Audiology_Assessment_ID,
                            GR_NO = id,
                            Name = textInfo.ToTitleCase(person[0].Name),
                            Father_Name = textInfo.ToTitleCase(person[0].Father_Name),
                            Disability = person[0].Disability,
                            Year = DateTime.Parse(data[i].Date_of_Assessment.ToString()).Year.ToString(),
                            Left_Ear_Mean = data[i].Left_Ear_Mean,
                            Right_Ear_Mean = data[i].Right_Ear_Mean,
                            Left_Ear_Mean_Level = getLevel(data[i].Left_Ear_Mean),
                            Right_Ear_Mean_Level = getLevel(data[i].Right_Ear_Mean)
                        };
                        ad.Add(a);
                    }

                    return ad;
                }
                return EmptyList;
            }
        }
    }
}