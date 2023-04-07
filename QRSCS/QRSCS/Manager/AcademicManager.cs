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
    public class AcademicManager
    {
        private bool IsPassed(decimal Percentage)
        {
            if (Percentage < 50) return false;
            return true;
        }

        public List<Student_Result_StatusModel> GetData(int GRNO)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var dbRequest = db.MidTerm_Result.ToList();
                var dbRequest1 = db.New_Admission.ToList();
                var dbRequest2 = db.Student_Current_Class.ToList();
                var dbRequest3 = db.Student_Result_Status.Where(x => x.GR_NO == GRNO).ToList();

                var IsPresent = dbRequest1.Any(x => x.GR_NO == GRNO);
                if (!IsPresent) return null;

                var check = dbRequest.Any(x => x.Term_Type == "2nd Term" && x.GR_NO == GRNO);
                if (!check) return null;
                else
                {
                    var percentage = dbRequest.FirstOrDefault(x => x.GR_NO == GRNO && x.Term_Type == "2nd Term").Grand_Percentage;

                    var getClass = dbRequest2.FirstOrDefault(x => x.GR_NO == GRNO);
                    var std_current_class = string.Empty;

                    if (getClass != null)
                    {
                        std_current_class = getClass.Class.ToString();
                    }
                    else
                    {
                        var std_class = dbRequest1.FirstOrDefault(x => x.GR_NO == GRNO);
                        std_current_class = std_class.Class.ToString();
                    }

                    Student_Result_Status data = new Student_Result_Status();
                    data.GR_NO = GRNO;
                    data.Presentage = percentage.ToString();
                    data.Date = DateTime.Now.ToShortDateString();
                    data.Class = Convert.ToInt32(std_current_class);

                    var student_current_class = 0;

                    if (IsPassed((decimal)percentage))
                    {
                        data.Result = "Passed";

                        student_current_class = Convert.ToInt32(std_current_class) + 1;
                    }
                    else
                    {
                        data.Result = "Failed";

                        student_current_class = Convert.ToInt32(std_current_class);
                    }

                    Student_Current_Class data1 = new Student_Current_Class();
                    data1.GR_NO = GRNO;
                    data1.Class = student_current_class;

                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var alreadyPresent = db.Student_Result_Status.OrderByDescending(x => x.Id).FirstOrDefault(x => x.GR_NO == GRNO);
                            var year = alreadyPresent == null ? "0" : Convert.ToDateTime(alreadyPresent.Date).Year.ToString();
                            var currentYear = DateTime.Now.Year.ToString();
                            if (year != currentYear)
                            {
                                db.Student_Result_Status.Add(data);
                                db.SaveChanges();

                                var classStatus = dbRequest2.FirstOrDefault(x => x.GR_NO == GRNO);
                                if (classStatus == null)
                                {
                                    db.Student_Current_Class.Add(data1);
                                }
                                else
                                {
                                    classStatus.Class = student_current_class;

                                    db.Entry(classStatus).State = EntityState.Modified;
                                }

                                db.SaveChanges();

                                transaction.Commit();
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }

                    List<Student_Result_StatusModel> data3 = new List<Student_Result_StatusModel>();
                    var fullName = dbRequest1.FirstOrDefault(x => x.GR_NO == GRNO);

                    foreach (var studentRecord in dbRequest3)
                    {
                        Student_Result_StatusModel record = new Student_Result_StatusModel();
                        record.GR_NO = GRNO;
                        record.Name = fullName.Student_First_Name + " " + fullName.Student_Last_Name;
                        record.FatherName = fullName.Father_Name;
                        record.Result = studentRecord.Result;
                        record.Presentage = studentRecord.Presentage;
                        record.Year = Convert.ToDateTime(studentRecord.Date).Year.ToString();
                        record.Class = studentRecord.Class.Value;
                        record.CurrentClass = Convert.ToString(student_current_class);

                        data3.Add(record);
                    }

                    return data3;
                }
            }
        }
    }
}