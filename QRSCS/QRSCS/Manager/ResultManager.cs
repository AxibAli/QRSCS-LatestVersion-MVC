using QRSCS.Common.BiMonthlyResult;
using QRSCS.Common.FinalResult;
using QRSCS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace QRSCS.Manager
{
    public class ResultManager
    {
        private decimal Fourty_Percent_Weightage(int grandTotal)
        {
            var answer = Convert.ToDecimal(grandTotal);
            answer = (decimal)(answer / 100);
            answer = answer * 40;
            return answer;
        }

        private decimal Sixty_Percent_Weightage(int grandTotal)
        {
            var answer = Convert.ToDecimal(grandTotal);
            answer = (decimal)(answer / 100);
            answer = answer * 60;
            return answer;
        }

        private decimal percentageCalc(int mark)
        {
            var marks = (decimal)mark;
            marks = (decimal)(marks / 1800);
            var percentage = (decimal)(marks * 100);
            return percentage;

        }
        private string CheckGrade(double percentage)
        {
            if (percentage > 90) return "A+";
            else if (percentage > 80 && percentage <= 90) return "A";
            else if (percentage > 70 && percentage <= 80) return "B+";
            else if (percentage > 60 && percentage <= 70) return "B";
            else if (percentage > 50 && percentage <= 60) return "C";
            else return "D";
        }
        public int AddBiMonthlyResult(BiMonthlyModel biMonthlyModel)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var IsFound = db.New_Admission.FirstOrDefault(x => x.GR_NO.Equals(biMonthlyModel.GR_NO));
                if (IsFound == null) return 0;

                Result result = new Result()
                {
                    GR_NO = biMonthlyModel.GR_NO,
                    Test_Type = biMonthlyModel.Test_Type,
                    English = biMonthlyModel.English,
                    Urdu = biMonthlyModel.Urdu,
                    Maths = biMonthlyModel.Maths,
                    Science = biMonthlyModel.Science,
                    Social_Studies = biMonthlyModel.Social_Studies,
                    Islamiat = biMonthlyModel.Islamiat,
                    Computer = biMonthlyModel.Computer,
                    Speech = biMonthlyModel.Speech,
                    Language = biMonthlyModel.Language,
                    Concepts = biMonthlyModel.Concepts,
                    Art_and_Drawing = biMonthlyModel.Art_and_Drawing,
                    Sindhi = biMonthlyModel.Sindhi,
                    Obtained_Total = biMonthlyModel.Obtained_Total,
                    Percentage = biMonthlyModel.Percentage,
                    Grade = biMonthlyModel.Grade,
                    Result_Date = biMonthlyModel.Result_Date
                };
                var data = db.Results.Any(o => o.Test_Type == biMonthlyModel.Test_Type && o.GR_NO.Equals(biMonthlyModel.GR_NO));
                if (data)
                {
                    return 2;
                }
                else
                {
                    db.Results.Add(result);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public int AddMidTermResult(FinalResultModel finalResultModel)
        {
            try
            {
                using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
                {
                    var IsFound = db.New_Admission.FirstOrDefault(x => x.GR_NO.Equals(finalResultModel.GR_NO));
                    if (IsFound == null) return 0;

                    List<string> biMonthlys = new List<string>();
                    var biMonthlysResult = db.Results.Where(x => x.GR_NO.Equals(finalResultModel.GR_NO)).ToList();

                    foreach (var biMonthly in biMonthlysResult)
                    {
                        biMonthlys.Add(biMonthly.Test_Type.ToString());
                    }

                    var Term_Type = finalResultModel.Term_Type;
                    var t1 = "1st Term";
                    var t2 = "2nd Term";
                    GrandTotalDTO grand = new GrandTotalDTO();

                    if (Term_Type == t2)
                    {
                        if (biMonthlys.Contains("3rd Bi-Monthly") == true && biMonthlys.Contains("4th Bi-Monthly") == true)
                        {
                            var index_3rd = biMonthlys.IndexOf("3rd Bi-Monthly");
                            var index_4th = biMonthlys.IndexOf("4th Bi-Monthly");

                            grand.Grand_English = Convert.ToInt32(biMonthlysResult[index_3rd].English) + Convert.ToInt32(biMonthlysResult[index_4th].English);
                            grand.Grand_Islamiat = Convert.ToInt32(biMonthlysResult[index_3rd].Islamiat) + Convert.ToInt32(biMonthlysResult[index_4th].Islamiat);
                            grand.Grand_Language = Convert.ToInt32(biMonthlysResult[index_3rd].Language) + Convert.ToInt32(biMonthlysResult[index_4th].Language);
                            grand.Grand_Maths = Convert.ToInt32(biMonthlysResult[index_3rd].Maths) + Convert.ToInt32(biMonthlysResult[index_4th].Maths);
                            grand.Grand_Science = Convert.ToInt32(biMonthlysResult[index_3rd].Science) + Convert.ToInt32(biMonthlysResult[index_4th].Science);
                            grand.Grand_Social_Studies = Convert.ToInt32(biMonthlysResult[index_3rd].Social_Studies) + Convert.ToInt32(biMonthlysResult[index_4th].Social_Studies);
                            grand.Grand_Urdu = Convert.ToInt32(biMonthlysResult[index_3rd].Urdu) + Convert.ToInt32(biMonthlysResult[index_4th].Urdu);
                            grand.Grand_Speech = Convert.ToInt32(biMonthlysResult[index_3rd].Speech) + Convert.ToInt32(biMonthlysResult[index_4th].Speech);
                            grand.Grand_Sindhi = Convert.ToInt32(biMonthlysResult[index_3rd].Sindhi) + Convert.ToInt32(biMonthlysResult[index_4th].Sindhi);
                            grand.Grand_Concepts = Convert.ToInt32(biMonthlysResult[index_3rd].Concepts) + Convert.ToInt32(biMonthlysResult[index_4th].Concepts);
                            grand.Grand_Computer = Convert.ToInt32(biMonthlysResult[index_3rd].Computer) + Convert.ToInt32(biMonthlysResult[index_4th].Computer);
                            grand.Grand_Art_and_Drawing = Convert.ToInt32(biMonthlysResult[index_3rd].Art_and_Drawing) + Convert.ToInt32(biMonthlysResult[index_4th].Art_and_Drawing);
                            grand.Grand_Total = Convert.ToInt32(biMonthlysResult[index_3rd].Obtained_Total) + Convert.ToInt32(biMonthlysResult[index_4th].Obtained_Total) + Convert.ToInt32(finalResultModel.Obtained_Total);
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                        else if (biMonthlys.Contains("3rd Bi-Monthly") == true)
                        {
                            var index_3rd = biMonthlys.IndexOf("3rd Bi-Monthly");

                            grand.Grand_English = Convert.ToInt32(biMonthlysResult[index_3rd].English);
                            grand.Grand_Islamiat = Convert.ToInt32(biMonthlysResult[index_3rd].Islamiat);
                            grand.Grand_Language = Convert.ToInt32(biMonthlysResult[index_3rd].Language);
                            grand.Grand_Maths = Convert.ToInt32(biMonthlysResult[index_3rd].Maths);
                            grand.Grand_Science = Convert.ToInt32(biMonthlysResult[index_3rd].Science);
                            grand.Grand_Social_Studies = Convert.ToInt32(biMonthlysResult[index_3rd].Social_Studies);
                            grand.Grand_Urdu = Convert.ToInt32(biMonthlysResult[index_3rd].Urdu);
                            grand.Grand_Speech = Convert.ToInt32(biMonthlysResult[index_3rd].Speech);
                            grand.Grand_Sindhi = Convert.ToInt32(biMonthlysResult[index_3rd].Sindhi);
                            grand.Grand_Concepts = Convert.ToInt32(biMonthlysResult[index_3rd].Concepts);
                            grand.Grand_Computer = Convert.ToInt32(biMonthlysResult[index_3rd].Computer);
                            grand.Grand_Art_and_Drawing = Convert.ToInt32(biMonthlysResult[index_3rd].Art_and_Drawing);
                            grand.Grand_Total = Convert.ToInt32(biMonthlysResult[index_3rd].Obtained_Total);
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                        else if (biMonthlys.Contains("4th Bi-Monthly") == true)
                        {
                            var index_4th = biMonthlys.IndexOf("4th Bi-Monthly");

                            grand.Grand_English = Convert.ToInt32(biMonthlysResult[index_4th].English);
                            grand.Grand_Islamiat = Convert.ToInt32(biMonthlysResult[index_4th].Islamiat);
                            grand.Grand_Language = Convert.ToInt32(biMonthlysResult[index_4th].Language);
                            grand.Grand_Maths = Convert.ToInt32(biMonthlysResult[index_4th].Maths);
                            grand.Grand_Science = Convert.ToInt32(biMonthlysResult[index_4th].Science);
                            grand.Grand_Social_Studies = Convert.ToInt32(biMonthlysResult[index_4th].Social_Studies);
                            grand.Grand_Urdu = Convert.ToInt32(biMonthlysResult[index_4th].Urdu);
                            grand.Grand_Speech = Convert.ToInt32(biMonthlysResult[index_4th].Speech);
                            grand.Grand_Sindhi = Convert.ToInt32(biMonthlysResult[index_4th].Sindhi);
                            grand.Grand_Concepts = Convert.ToInt32(biMonthlysResult[index_4th].Concepts);
                            grand.Grand_Computer = Convert.ToInt32(biMonthlysResult[index_4th].Computer);
                            grand.Grand_Art_and_Drawing = Convert.ToInt32(biMonthlysResult[index_4th].Art_and_Drawing);
                            grand.Grand_Total = Convert.ToInt32(biMonthlysResult[index_4th].Obtained_Total);
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                        else
                        {

                            grand.Grand_English = 0;
                            grand.Grand_Islamiat = 0;
                            grand.Grand_Language = 0;
                            grand.Grand_Maths = 0;
                            grand.Grand_Science = 0;
                            grand.Grand_Social_Studies = 0;
                            grand.Grand_Urdu = 0;
                            grand.Grand_Speech = 0;
                            grand.Grand_Sindhi = 0;
                            grand.Grand_Concepts = 0;
                            grand.Grand_Computer = 0;
                            grand.Grand_Art_and_Drawing = 0;
                            grand.Grand_Total = 0;
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                    }
                    else if (Term_Type == t1)
                    {
                        if (biMonthlys.Contains("1st Bi-Monthly") == true && biMonthlys.Contains("2nd Bi-Monthly") == true)
                        {
                            var index_1st = biMonthlys.IndexOf("1st Bi-Monthly");
                            var index_2st = biMonthlys.IndexOf("2nd Bi-Monthly");

                            grand.Grand_English = Convert.ToInt32(biMonthlysResult[index_1st].English) + Convert.ToInt32(biMonthlysResult[index_2st].English);
                            grand.Grand_Islamiat = Convert.ToInt32(biMonthlysResult[index_1st].Islamiat) + Convert.ToInt32(biMonthlysResult[index_2st].Islamiat);
                            grand.Grand_Language = Convert.ToInt32(biMonthlysResult[index_1st].Language) + Convert.ToInt32(biMonthlysResult[index_2st].Language);
                            grand.Grand_Maths = Convert.ToInt32(biMonthlysResult[index_1st].Maths) + Convert.ToInt32(biMonthlysResult[index_2st].Maths);
                            grand.Grand_Science = Convert.ToInt32(biMonthlysResult[index_1st].Science) + Convert.ToInt32(biMonthlysResult[index_2st].Science);
                            grand.Grand_Social_Studies = Convert.ToInt32(biMonthlysResult[index_1st].Social_Studies) + Convert.ToInt32(biMonthlysResult[index_2st].Social_Studies);
                            grand.Grand_Urdu = Convert.ToInt32(biMonthlysResult[index_1st].Urdu) + Convert.ToInt32(biMonthlysResult[index_2st].Urdu);
                            grand.Grand_Speech = Convert.ToInt32(biMonthlysResult[index_1st].Speech) + Convert.ToInt32(biMonthlysResult[index_2st].Speech);
                            grand.Grand_Sindhi = Convert.ToInt32(biMonthlysResult[index_1st].Sindhi) + Convert.ToInt32(biMonthlysResult[index_2st].Sindhi);
                            grand.Grand_Concepts = Convert.ToInt32(biMonthlysResult[index_1st].Concepts) + Convert.ToInt32(biMonthlysResult[index_2st].Concepts);
                            grand.Grand_Computer = Convert.ToInt32(biMonthlysResult[index_1st].Computer) + Convert.ToInt32(biMonthlysResult[index_2st].Computer);
                            grand.Grand_Art_and_Drawing = Convert.ToInt32(biMonthlysResult[index_1st].Art_and_Drawing) + Convert.ToInt32(biMonthlysResult[index_2st].Art_and_Drawing);
                            grand.Grand_Total = Convert.ToInt32(biMonthlysResult[index_1st].Obtained_Total) + Convert.ToInt32(biMonthlysResult[index_2st].Obtained_Total) + Convert.ToInt32(finalResultModel.Obtained_Total);
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                        else if (biMonthlys.Contains("1st Bi-Monthly") == true)
                        {
                            var index_1st = biMonthlys.IndexOf("1st Bi-Monthly");

                            grand.Grand_English = Convert.ToInt32(biMonthlysResult[index_1st].English);
                            grand.Grand_Islamiat = Convert.ToInt32(biMonthlysResult[index_1st].Islamiat);
                            grand.Grand_Language = Convert.ToInt32(biMonthlysResult[index_1st].Language);
                            grand.Grand_Maths = Convert.ToInt32(biMonthlysResult[index_1st].Maths);
                            grand.Grand_Science = Convert.ToInt32(biMonthlysResult[index_1st].Science);
                            grand.Grand_Social_Studies = Convert.ToInt32(biMonthlysResult[index_1st].Social_Studies);
                            grand.Grand_Urdu = Convert.ToInt32(biMonthlysResult[index_1st].Urdu);
                            grand.Grand_Speech = Convert.ToInt32(biMonthlysResult[index_1st].Speech);
                            grand.Grand_Sindhi = Convert.ToInt32(biMonthlysResult[index_1st].Sindhi);
                            grand.Grand_Concepts = Convert.ToInt32(biMonthlysResult[index_1st].Concepts);
                            grand.Grand_Computer = Convert.ToInt32(biMonthlysResult[index_1st].Computer);
                            grand.Grand_Art_and_Drawing = Convert.ToInt32(biMonthlysResult[index_1st].Art_and_Drawing);
                            grand.Grand_Total = Convert.ToInt32(biMonthlysResult[index_1st].Obtained_Total);
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                        else if (biMonthlys.Contains("2nd Bi-Monthly") == true)
                        {
                            var index_2nd = biMonthlys.IndexOf("2nd Bi-Monthly");

                            grand.Grand_English = Convert.ToInt32(biMonthlysResult[index_2nd].English);
                            grand.Grand_Islamiat = Convert.ToInt32(biMonthlysResult[index_2nd].Islamiat);
                            grand.Grand_Language = Convert.ToInt32(biMonthlysResult[index_2nd].Language);
                            grand.Grand_Maths = Convert.ToInt32(biMonthlysResult[index_2nd].Maths);
                            grand.Grand_Science = Convert.ToInt32(biMonthlysResult[index_2nd].Science);
                            grand.Grand_Social_Studies = Convert.ToInt32(biMonthlysResult[index_2nd].Social_Studies);
                            grand.Grand_Urdu = Convert.ToInt32(biMonthlysResult[index_2nd].Urdu);
                            grand.Grand_Speech = Convert.ToInt32(biMonthlysResult[index_2nd].Speech);
                            grand.Grand_Sindhi = Convert.ToInt32(biMonthlysResult[index_2nd].Sindhi);
                            grand.Grand_Concepts = Convert.ToInt32(biMonthlysResult[index_2nd].Concepts);
                            grand.Grand_Computer = Convert.ToInt32(biMonthlysResult[index_2nd].Computer);
                            grand.Grand_Art_and_Drawing = Convert.ToInt32(biMonthlysResult[index_2nd].Art_and_Drawing);
                            grand.Grand_Total = Convert.ToInt32(biMonthlysResult[index_2nd].Obtained_Total);
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                        else
                        {

                            grand.Grand_English = 0;
                            grand.Grand_Islamiat = 0;
                            grand.Grand_Language = 0;
                            grand.Grand_Maths = 0;
                            grand.Grand_Science = 0;
                            grand.Grand_Social_Studies = 0;
                            grand.Grand_Urdu = 0;
                            grand.Grand_Speech = 0;
                            grand.Grand_Sindhi = 0;
                            grand.Grand_Concepts = 0;
                            grand.Grand_Computer = 0;
                            grand.Grand_Art_and_Drawing = 0;
                            grand.Grand_Total = 0;
                            grand.Grand_Grade = CheckGrade(grand.Grand_Percentage);
                        }
                    }

                    var bimonthliResult = db.Results.Where(x => x.GR_NO.Equals(finalResultModel.GR_NO)).ToList();

                    MidTerm_Result midTerm_Result = new MidTerm_Result();

                    midTerm_Result.GR_NO = finalResultModel.GR_NO;
                    midTerm_Result.Term_Type = finalResultModel.Term_Type;
                    midTerm_Result.English = finalResultModel.English;
                    midTerm_Result.Urdu = finalResultModel.Urdu;
                    midTerm_Result.Maths = finalResultModel.Maths;
                    midTerm_Result.Science = finalResultModel.Science;
                    midTerm_Result.Social_Studies = finalResultModel.Social_Studies;
                    midTerm_Result.Islamiat = finalResultModel.Islamiat;
                    midTerm_Result.Computer = finalResultModel.Computer;
                    midTerm_Result.Speech = finalResultModel.Speech;
                    midTerm_Result.Language = finalResultModel.Language;
                    midTerm_Result.Concepts = finalResultModel.Concepts;
                    midTerm_Result.Art_and_Drawing = finalResultModel.Art_and_Drawing;
                    midTerm_Result.Sindhi = finalResultModel.Sindhi;
                    midTerm_Result.Obtained_Total = finalResultModel.Obtained_Total;
                    midTerm_Result.Percentage = finalResultModel.Percentage;
                    midTerm_Result.Grade = finalResultModel.Grade;
                    midTerm_Result.Grand_English = grand.Grand_English + finalResultModel.English;
                    midTerm_Result.Grand_Urdu = grand.Grand_Urdu + finalResultModel.Urdu;
                    midTerm_Result.Grand_Maths = grand.Grand_Maths + finalResultModel.Maths;
                    midTerm_Result.Grand_Science = grand.Grand_Science + finalResultModel.Science;
                    midTerm_Result.Grand_Social_Studies = grand.Grand_Social_Studies + finalResultModel.Social_Studies;
                    midTerm_Result.Grand_Islamiat = grand.Grand_Islamiat + finalResultModel.Islamiat;
                    midTerm_Result.Grand_Computer = grand.Grand_Computer + finalResultModel.Computer;
                    midTerm_Result.Grand_Speech = grand.Grand_Speech + finalResultModel.Speech;
                    midTerm_Result.Grand_Language = grand.Grand_Language + finalResultModel.Language;
                    midTerm_Result.Grand_Concepts = grand.Grand_Concepts + finalResultModel.Concepts;
                    midTerm_Result.Grand_Art_and_Drawing = grand.Grand_Art_and_Drawing + finalResultModel.Art_and_Drawing;
                    midTerm_Result.Grand_Sindhi = grand.Grand_Sindhi + finalResultModel.Sindhi;

                    midTerm_Result.Grand_Total = grand.Grand_Total;
                    var percentage = Convert.ToDecimal(grand.Grand_Total /*+ finalResultModel.Obtained_Total*/);
                    percentage = Convert.ToDecimal(percentage / 1800);
                    percentage = Math.Floor(percentage * 100);
                    grand.Grand_Percentage = (int)percentage;
                    midTerm_Result.Grand_Percentage = grand.Grand_Percentage;
                    midTerm_Result.Grand_Grade = CheckGrade(Convert.ToDouble(midTerm_Result.Grand_Percentage));
                    midTerm_Result.Result_Date = finalResultModel.Result_Date;

                    var data = db.MidTerm_Result.Where(o => o.Term_Type.Equals(finalResultModel.Term_Type) && o.GR_NO.Equals(finalResultModel.GR_NO)).ToList();
                    var lastIndex = data.Count - 1;
                    DateTime myDateTime = DateTime.Now;
                    string Currentyear = myDateTime.Year.ToString();
                    string year = Currentyear;
                    //midTerm_Result.
                    year = (data.Count() == 0) ? "0" : DateTime.Parse(data[lastIndex].Result_Date.ToString()).Year.ToString();

                    if (data.Count() == 0)
                    {
                        //    midTerm_Result.New_Admission = "fsfsdf";
                        // midTerm_Result.MidTerm_Result_ID = 6;
                        db.MidTerm_Result.Add(midTerm_Result);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (year == Currentyear)
                        {
                            data[lastIndex].Term_Type = midTerm_Result.Term_Type;
                            data[lastIndex].English = midTerm_Result.English;
                            data[lastIndex].Urdu = midTerm_Result.Urdu;
                            data[lastIndex].Maths = midTerm_Result.Maths;
                            data[lastIndex].Science = midTerm_Result.Science;
                            data[lastIndex].Social_Studies = midTerm_Result.Social_Studies;
                            data[lastIndex].Islamiat = midTerm_Result.Islamiat;
                            data[lastIndex].Computer = midTerm_Result.Computer;
                            data[lastIndex].Speech = midTerm_Result.Speech;
                            data[lastIndex].Language = midTerm_Result.Language;
                            data[lastIndex].Concepts = midTerm_Result.Concepts;
                            data[lastIndex].Art_and_Drawing = midTerm_Result.Art_and_Drawing;
                            data[lastIndex].Sindhi = midTerm_Result.Sindhi;
                            data[lastIndex].Obtained_Total = midTerm_Result.Obtained_Total;
                            data[lastIndex].Percentage = midTerm_Result.Percentage;
                            data[lastIndex].Grade = midTerm_Result.Grade;
                            data[lastIndex].Grand_English = grand.Grand_English + midTerm_Result.English;
                            data[lastIndex].Grand_Urdu = grand.Grand_Urdu + midTerm_Result.Urdu;
                            data[lastIndex].Grand_Maths = grand.Grand_Maths + midTerm_Result.Maths;
                            data[lastIndex].Grand_Science = grand.Grand_Science + midTerm_Result.Science;
                            data[lastIndex].Grand_Social_Studies = grand.Grand_Social_Studies + midTerm_Result.Social_Studies;
                            data[lastIndex].Grand_Islamiat = grand.Grand_Islamiat + midTerm_Result.Islamiat;
                            data[lastIndex].Grand_Computer = grand.Grand_Computer + midTerm_Result.Computer;
                            data[lastIndex].Grand_Speech = grand.Grand_Speech + midTerm_Result.Speech;
                            data[lastIndex].Grand_Language = grand.Grand_Language + midTerm_Result.Language;
                            data[lastIndex].Grand_Concepts = grand.Grand_Concepts + midTerm_Result.Concepts;
                            data[lastIndex].Grand_Art_and_Drawing = grand.Grand_Art_and_Drawing + midTerm_Result.Art_and_Drawing;
                            data[lastIndex].Grand_Sindhi = grand.Grand_Sindhi + midTerm_Result.Sindhi;
                            data[lastIndex].Grand_Total = grand.Grand_Total;
                            data[lastIndex].Grand_Percentage = midTerm_Result.Grand_Percentage;
                            data[lastIndex].Grand_Grade = midTerm_Result.Grand_Grade;
                            data[lastIndex].Result_Date = midTerm_Result.Result_Date;

                            db.Entry(data[lastIndex]).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                return 2;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            db.MidTerm_Result.Add(midTerm_Result);
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public HIResultModel GetHIResult(int GR_NO)

        {
            try
            {
                New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
                var IsPresent = db.New_Admission.Any(x => x.GR_NO == GR_NO);


                HIResultModel result = new HIResultModel();
                if (!IsPresent) return null;

                var FirstBTM = db.Results.Where(u => u.Test_Type == "1st Bi-Monthly" && u.GR_NO == GR_NO).OrderByDescending(x => x.Result_Date).FirstOrDefault();
                var SecondBTM = db.Results.Where(u => u.Test_Type == "2nd Bi-Monthly" && u.GR_NO == GR_NO).OrderByDescending(x => x.Result_Date).FirstOrDefault();
                var ThirdBTM = db.Results.Where(u => u.Test_Type == "3rd Bi-Monthly" && u.GR_NO == GR_NO).OrderByDescending(x => x.Result_Date).FirstOrDefault();
                var FourthBTM = db.Results.Where(u => u.Test_Type == "4th Bi-Monthly" && u.GR_NO == GR_NO).OrderByDescending(x => x.Result_Date).FirstOrDefault();
                var FirstMT = db.MidTerm_Result.Where(u => u.Term_Type == "1st Term" && u.GR_NO == GR_NO).OrderByDescending(x => x.Result_Date).FirstOrDefault();
                var SecondMT = db.MidTerm_Result.Where(u => u.Term_Type == "2nd Term" && u.GR_NO == GR_NO).OrderByDescending(x => x.Result_Date).FirstOrDefault();

                if (FirstBTM != null)
                {
                    result.FirstBTM_English = FirstBTM.English;
                    result.FirstBTM_Art_and_Drawing = FirstBTM.Art_and_Drawing;
                    result.FirstBTM_Concepts = FirstBTM.Concepts;
                    result.FirstBTM_Computer = FirstBTM.Computer;
                    result.FirstBTM_Islamiat = FirstBTM.Islamiat;
                    result.FirstBTM_Language = FirstBTM.Language;
                    result.FirstBTM_Maths = FirstBTM.Maths;
                    result.FirstBTM_Social_Studies = FirstBTM.Social_Studies;
                    result.FirstBTM_Speech = FirstBTM.Speech;
                    result.FirstBTM_Urdu = FirstBTM.Urdu;
                    result.FirstBTM_Sindhi = FirstBTM.Sindhi;
                    result.FirstBTM_Science = FirstBTM.Science;
                    result.FirstBTM_Grade = FirstBTM.Grade;
                    result.FirstBTM_Percentage = FirstBTM.Percentage;
                    result.FirstBTM_Obtained_Total = FirstBTM.Obtained_Total;
                }
                if (SecondBTM != null)
                {
                    result.SecondBTM_English = SecondBTM.English;
                    result.SecondBTM_Art_and_Drawing = SecondBTM.Art_and_Drawing;
                    result.SecondBTM_Concepts = SecondBTM.Concepts;
                    result.SecondBTM_Computer = SecondBTM.Computer;
                    result.SecondBTM_Islamiat = SecondBTM.Islamiat;
                    result.SecondBTM_Language = SecondBTM.Language;
                    result.SecondBTM_Maths = SecondBTM.Maths;
                    result.SecondBTM_Social_Studies = SecondBTM.Social_Studies;
                    result.SecondBTM_Speech = SecondBTM.Speech;
                    result.SecondBTM_Urdu = SecondBTM.Urdu;
                    result.SecondBTM_Sindhi = SecondBTM.Sindhi;
                    result.SecondBTM_Science = SecondBTM.Science;
                    result.SecondBTM_Grade = SecondBTM.Grade;
                    result.SecondBTM_Percentage = SecondBTM.Percentage;
                    result.SecondBTM_Obtained_Total = SecondBTM.Obtained_Total;
                }
                if (ThirdBTM != null)
                {
                    result.ThirdBTM_English = ThirdBTM.English;
                    result.ThirdBTM_Art_and_Drawing = ThirdBTM.Art_and_Drawing;
                    result.ThirdBTM_Concepts = ThirdBTM.Concepts;
                    result.ThirdBTM_Computer = ThirdBTM.Computer;
                    result.ThirdBTM_Islamiat = ThirdBTM.Islamiat;
                    result.ThirdBTM_Language = ThirdBTM.Language;
                    result.ThirdBTM_Maths = ThirdBTM.Maths;
                    result.ThirdBTM_Social_Studies = ThirdBTM.Social_Studies;
                    result.ThirdBTM_Speech = ThirdBTM.Speech;
                    result.ThirdBTM_Urdu = ThirdBTM.Urdu;
                    result.ThirdBTM_Sindhi = ThirdBTM.Sindhi;
                    result.ThirdBTM_Science = ThirdBTM.Science;
                    result.ThirdBTM_Grade = ThirdBTM.Grade;
                    result.ThirdBTM_Percentage = ThirdBTM.Percentage;
                    result.ThirdBTM_Obtained_Total = ThirdBTM.Obtained_Total;
                }
                if (FourthBTM != null)
                {
                    result.FourthBTM_English = FourthBTM.English;
                    result.FourthBTM_Art_and_Drawing = FourthBTM.Art_and_Drawing;
                    result.FourthBTM_Concepts = FourthBTM.Concepts;
                    result.FourthBTM_Computer = FourthBTM.Computer;
                    result.FourthBTM_Islamiat = FourthBTM.Islamiat;
                    result.FourthBTM_Language = FourthBTM.Language;
                    result.FourthBTM_Maths = FourthBTM.Maths;
                    result.FourthBTM_Social_Studies = FourthBTM.Social_Studies;
                    result.FourthBTM_Speech = FourthBTM.Speech;
                    result.FourthBTM_Urdu = FourthBTM.Urdu;
                    result.FourthBTM_Sindhi = FourthBTM.Sindhi;
                    result.FourthBTM_Science = FourthBTM.Science;
                    result.FourthBTM_Grade = FourthBTM.Grade;
                    result.FourthBTM_Percentage = FourthBTM.Percentage;
                    result.FourthBTM_Obtained_Total = FourthBTM.Obtained_Total;
                }
                if (FirstMT != null)
                {
                    result.FirstTerm_English = FirstMT.English;
                    result.FirstTerm_Art_and_Drawing = FirstMT.Art_and_Drawing;
                    result.FirstTerm_Concepts = FirstMT.Concepts;
                    result.FirstTerm_Computer = FirstMT.Computer;
                    result.FirstTerm_Islamiat = FirstMT.Islamiat;
                    result.FirstTerm_Language = FirstMT.Language;
                    result.FirstTerm_Maths = FirstMT.Maths;
                    result.FirstTerm_Social_Studies = FirstMT.Social_Studies;
                    result.FirstTerm_Speech = FirstMT.Speech;
                    result.FirstTerm_Urdu = FirstMT.Urdu;
                    result.FirstTerm_Sindhi = FirstMT.Sindhi;
                    result.FirstTerm_Science = FirstMT.Science;
                    result.FirstTerm_Grade = FirstMT.Grade;
                    result.FirstTerm_Percentage = FirstMT.Percentage;
                    result.FirstTerm_Total = FirstMT.Obtained_Total;
                    result.FirstGT_English = FirstMT.Grand_English.Value /*+ result.FirstBTM_English + result.SecondBTM_English*/;
                    result.FirstGT_Art_and_Drawing = FirstMT.Grand_Art_and_Drawing.Value /*+ result.FirstBTM_Art_and_Drawing + result.SecondBTM_Art_and_Drawing*/;
                    result.FirstGT_Concepts = FirstMT.Grand_Concepts.Value /*+ result.FirstBTM_Concepts + result.SecondBTM_Concepts*/;
                    result.FirstGT_Computer = FirstMT.Grand_Computer.Value /*+ result.FirstBTM_Computer + result.SecondBTM_Computer*/;
                    result.FirstGT_Islamiat = FirstMT.Grand_Islamiat.Value /*+ result.FirstBTM_Islamiat + result.SecondBTM_Islamiat*/;
                    result.FirstGT_Language = FirstMT.Grand_Language.Value /*+ result.FirstBTM_Language + result.SecondBTM_Language*/;
                    result.FirstGT_Maths = FirstMT.Grand_Maths.Value /*+ result.FirstBTM_Maths + result.SecondBTM_Maths*/;
                    result.FirstGT_Social_Studies = FirstMT.Grand_Social_Studies.Value /*+ result.FirstBTM_Social_Studies + result.SecondBTM_Social_Studies*/;
                    result.FirstGT_Speech = FirstMT.Grand_Speech.Value /*+ result.FirstBTM_Speech + result.SecondBTM_Speech*/;
                    result.FirstGT_Urdu = FirstMT.Grand_Urdu.Value /*+ result.FirstBTM_Urdu + result.SecondBTM_Urdu*/;
                    result.FirstGT_Sindhi = FirstMT.Grand_Sindhi.Value /*+ result.FirstBTM_Sindhi + result.SecondBTM_Sindhi*/;
                    result.FirstGT_Science = FirstMT.Grand_Science.Value /*+ result.FirstBTM_Science + result.SecondBTM_Science*/;
                    result.FirstGT_Total = FirstMT.Obtained_Total + result.FirstBTM_Obtained_Total + result.SecondBTM_Obtained_Total;
                    result.FirstGT_Percentage = (int)percentageCalc(result.FirstGT_Total);
                    result.FirstGT_Grade = CheckGrade(result.FirstGT_Percentage);
                    result.FourtyPT_English = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_English));
                    result.FourtyPT_Art_and_Drawing = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Art_and_Drawing));
                    result.FourtyPT_Concepts = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Concepts));
                    result.FourtyPT_Computer = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Computer));
                    result.FourtyPT_Islamiat = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Islamiat));
                    result.FourtyPT_Language = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Language));
                    result.FourtyPT_Maths = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Maths));
                    result.FourtyPT_Social_Studies = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Social_Studies));
                    result.FourtyPT_Speech = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Speech));
                    result.FourtyPT_Urdu = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Urdu));
                    result.FourtyPT_Sindhi = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Sindhi));
                    result.FourtyPT_Science = Convert.ToInt32(Fourty_Percent_Weightage(result.FirstGT_Science));

                }
                if (SecondMT != null)
                {
                    result.SecondTerm_English = SecondMT.English;
                    result.SecondTerm_Art_and_Drawing = SecondMT.Art_and_Drawing;
                    result.SecondTerm_Concepts = SecondMT.Concepts;
                    result.SecondTerm_Computer = SecondMT.Computer;
                    result.SecondTerm_Islamiat = SecondMT.Islamiat;
                    result.SecondTerm_Language = SecondMT.Language;
                    result.SecondTerm_Maths = SecondMT.Maths;
                    result.SecondTerm_Social_Studies = SecondMT.Social_Studies;
                    result.SecondTerm_Speech = SecondMT.Speech;
                    result.SecondTerm_Urdu = SecondMT.Urdu;
                    result.SecondTerm_Sindhi = SecondMT.Sindhi;
                    result.SecondTerm_Science = SecondMT.Science;
                    result.SecondTerm_Grade = SecondMT.Grade;
                    result.SecondTerm_Percentage = SecondMT.Percentage;
                    result.SecondTerm_Total = SecondMT.Obtained_Total;
                    result.SecondGT_English = SecondMT.Grand_English.Value /*+ result.ThirdBTM_English + result.FourthBTM_English*/;
                    result.SecondGT_Art_and_Drawing = SecondMT.Grand_Art_and_Drawing.Value /*+ result.ThirdBTM_Art_and_Drawing + result.FourthBTM_Art_and_Drawing*/;
                    result.SecondGT_Concepts = SecondMT.Grand_Concepts.Value /*+ result.ThirdBTM_Concepts + result.FourthBTM_Concepts*/;
                    result.SecondGT_Computer = SecondMT.Grand_Computer.Value /*+ result.ThirdBTM_Computer + result.FourthBTM_Computer*/;
                    result.SecondGT_Islamiat = SecondMT.Grand_Islamiat.Value /*+ result.ThirdBTM_Islamiat + result.FourthBTM_Islamiat*/;
                    result.SecondGT_Language = SecondMT.Grand_Language.Value /*+ result.ThirdBTM_Language + result.FourthBTM_Language*/;
                    result.SecondGT_Maths = SecondMT.Grand_Maths.Value /*+ result.ThirdBTM_Maths + result.FourthBTM_Maths*/;
                    result.SecondGT_Social_Studies = SecondMT.Grand_Social_Studies.Value /*+ result.ThirdBTM_Social_Studies + result.FourthBTM_Social_Studies*/;
                    result.SecondGT_Speech = SecondMT.Grand_Speech.Value /*+ result.ThirdBTM_Speech + result.FourthBTM_Speech*/;
                    result.SecondGT_Urdu = SecondMT.Grand_Urdu.Value /*+ result.ThirdBTM_Urdu + result.FourthBTM_Urdu*/;
                    result.SecondGT_Sindhi = SecondMT.Grand_Sindhi.Value /*+ result.ThirdBTM_Sindhi + result.FourthBTM_Sindhi*/;
                    result.SecondGT_Science = SecondMT.Grand_Science.Value /*+ result.ThirdBTM_Science + result.FourthBTM_Science*/;
                    result.SecondGT_Total = SecondMT.Obtained_Total + result.ThirdBTM_Obtained_Total + result.FourthBTM_Obtained_Total;
                    result.SecondGT_Percentage = (int)percentageCalc(result.SecondGT_Total);
                    result.SecondGT_Grade = CheckGrade(result.SecondGT_Percentage);
                    //result.SecondGT_Percentage = (int)percentageCalc(result.SecondGT_Total); 
                    result.SixtyPT_English = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_English));
                    result.SixtyPT_Art_and_Drawing = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Art_and_Drawing));
                    result.SixtyPT_Concepts = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Concepts));
                    result.SixtyPT_Computer = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Computer));
                    result.SixtyPT_Islamiat = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Islamiat));
                    result.SixtyPT_Language = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Language));
                    result.SixtyPT_Maths = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Maths));
                    result.SixtyPT_Social_Studies = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Social_Studies));
                    result.SixtyPT_Speech = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Speech));
                    result.SixtyPT_Urdu = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Urdu));
                    result.SixtyPT_Sindhi = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Sindhi));
                    result.SixtyPT_Science = Convert.ToInt32(Sixty_Percent_Weightage(result.SecondGT_Science));

                }
                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public StudentInfo GetStudentInfo(int id)
        {
            New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

            var dbRequest = db.New_Admission.FirstOrDefault(x => x.GR_NO == id);
            if (dbRequest == null) return null;

            var StdClass = db.Student_Current_Class.FirstOrDefault(x => x.GR_NO == id);
            if (StdClass != null) {
                StudentInfo studentInfo = new StudentInfo();
                studentInfo.Class = StdClass.Class.Value;
                studentInfo.Name = dbRequest.Student_First_Name + " " + dbRequest.Student_Last_Name;
                studentInfo.Father_Name = dbRequest.Father_Name;
                studentInfo.Disability = dbRequest.Disability;
                return studentInfo;
            }
            else
            {
                StudentInfo studentInfo = new StudentInfo();
                studentInfo.Class = dbRequest.Class;
                studentInfo.Name = dbRequest.Student_First_Name + " " + dbRequest.Student_Last_Name;
                studentInfo.Father_Name = dbRequest.Father_Name;
                studentInfo.Disability = dbRequest.Disability;
                return studentInfo;
            }
            
        }
    }

    public class StudentInfo
    {
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public int Class { get; set; }
        public string Disability { get; set; }
    }

}

