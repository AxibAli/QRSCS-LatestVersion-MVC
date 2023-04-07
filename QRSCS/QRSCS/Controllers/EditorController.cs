using QRSCS.Manager;
using QRSCS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;

namespace QRSCS.Controllers
{
    public class EditorController : Controller
    {
        // GET: Editor
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult NewAdmission()
        {
            ViewBag.Message = "";
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult NewAdmission(NewAdmissionModel student)
        {
            if (ModelState.IsValid)
            {
                NewAdmissionManager obj = new NewAdmissionManager();
                student.User_ID = Convert.ToInt32(Session["User_ID"]);
                int grno = obj.AddStudent(student);
                if (grno > 0)
                {
                    TempData["Message"] = "Student Added Successfuly and Student GR-NO is " + grno;
                    return RedirectToAction( "Index","Admin");
                }

                else
                {
                    TempData["Message"] = "Student Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Student Not Added !";
            }
            return View();
        }

        [HttpGet]
        public ActionResult CaseHistory()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult CaseHistory(CaseHistoryModelDTO student)
        {
            if (ModelState.IsValid)
            {
                CaseHistoryManager obj = new CaseHistoryManager();
                int chistoryID = obj.AddCaseHistory(student);
                if (chistoryID > 0)
                {
                    TempData["Message"] = "Student Case History Added Successfuly  " + chistoryID;
                }

                else
                {
                    TempData["Message"] = "Student Case History Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Student Case History Not Added !";
            }
            return View();
        }

        [HttpGet]
        public ActionResult SpeechTherapyAssessment()

        {
            return View();
        }
        [HttpPost]
        public ActionResult SpeechTherapyAssessment(SpeechTherapyAssessmentModel student )

        {
            if (ModelState.IsValid)
            {
                if (student.Speech_Test_Image_File == null)
                {
                    TempData["Message"] = "Upload User Picture !";
                    return View();
                }
                else
                {
                    string Filename = Path.GetFileNameWithoutExtension(student.Speech_Test_Image_File.FileName);
                    string Extension = Path.GetExtension(student.Speech_Test_Image_File.FileName);
                    Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
                    student.Speech_Test_Image = "~/ProjectData/" + Filename;
                    Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
                    student.Speech_Test_Image_File.SaveAs(Filename);

                    SpeechTherapyAssessmentManager obj = new SpeechTherapyAssessmentManager();

                    int staid = obj.AddSpeechTherapyAssessment(student);

                        TempData["Success"] = "Success";
                        TempData["Message"] = "Successfully Saved";
                        return View();
                  
                }
            }

            return RedirectToAction("Index","Admin");
        }
        public ActionResult SpeechCaseHistory()
        {
            return View();
        }
                                  
        public  string CSV_FILE_FOR_STA(int uid)
        {
            SpeechTherapyAssessmentModel User = null;
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var result = db.Speech_Therapy_Assessment.FirstOrDefault(x => x.GR_NO == uid);
                if (result != null)
                {
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Content\CSV_for_AI_Model\" + result.Full_Name.ToLower() + " speech therapy assessment.csv";

                    try
                    {
                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.File.Delete(fileName);
                        }
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            var request = db.Speech_Therapy_Assessment.Where(x => x.GR_NO == uid).Select(x => x.Marks).ToList();
                            var request1 = db.Speech_Therapy_Assessment.Where(x => x.GR_NO == uid).Select(x => x.Date).ToList();
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < request.Count; i++)
                            {
                                sb.Append(request1[i] + "," + request[i] + ",");
                                sb.Append("\r\n");

                            }
                            byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
                            fs.Write(bytes, 0, bytes.Length);
                        }
                         

                        return "Successful";
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.ToString());
                    }
                    return "failed";   
                }
                else
                {
                    TempData["Message"] = "No Records Found";
                    Debug.WriteLine(TempData["Message"]);
                    return "UnSuccessful";
                }



            }
        }
        public ActionResult AudiologyAssessment()
        {
            return View();
        }
        public ActionResult Predict_Marks()
        {
            return View();
        }
        public ActionResult VIPerformance()
        {
            return View();
        }
        public string exec(int uid)
        {

            SpeechTherapyAssessmentModel User = null;
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var result = db.Speech_Therapy_Assessment.FirstOrDefault(x => x.GR_NO == uid);

                Speech_Therapy_AI_Model model = new Speech_Therapy_AI_Model();
                bool outp = model.exec_model(result.Full_Name.ToLower(), uid);
                if (outp)
                {
                    return "success";
                }
                else
                {
                    return "unsuccesfull";
                }

            }
        }

        public ActionResult Prediction_CSV_to(int uid)
        {
            New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
            var result = db.Speech_Therapy_Assessment.FirstOrDefault(x => x.GR_NO == uid);
            var csv = new List<STP_data>();
            var lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Content\CSV_for_AI_Model\" +  result.Full_Name.ToLower() + " speech therapy assessment.csv");
            foreach (var line in lines)
            {
                csv.Add(new STP_data
                {
                    Date = DateTime.Parse(line.Split(',')[0]),
                    Marks = float.Parse(line.Split(',')[1])
                });
            }
            string value = string.Empty;
            value = JsonConvert.SerializeObject(csv, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            string json = JsonConvert.SerializeObject(csv);

            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Performance()
        {
            return View();
        }
    }

}