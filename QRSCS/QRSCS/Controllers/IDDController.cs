using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRSCS.Manager;
 
using QRSCS.Models;

namespace QRSCS.Controllers
{
 
    public class IDDController : Controller
    {
        // GET: IDD
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Performance()
        {
            return View();
        }

        public ActionResult IEP()
        {
            return View();
        }

        public ActionResult ViewAllIEP()
        {
            return View();
        }

        public ActionResult IEPPerformance()
        {
            return View();
        }


        [HttpGet]
        public ActionResult OT()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OT(OccupationalTherapy1ModelDTO occupationalTherapy1ModelDTO)
        {
            if (ModelState.IsValid)
            {
                OccupationalTherapy1Manager otm = new OccupationalTherapy1Manager();
                int otid = otm.AddOccupationalTherapy1(occupationalTherapy1ModelDTO);
                if (otid > 0)
                {
                    TempData["Message"] = "Student Occupational Therapy Added Successfuly and OT ID is " + otid;
                }
                else
                {
                    TempData["Message"] = "Student Occupational Therapy Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Error From Model !";
            }
            return View();
        }

        [HttpGet]
        public ActionResult OT2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OT2(OccupationalTherapy2ModelDTO occupationalTherapy2ModelDTO)
        {
            if (ModelState.IsValid)
            {
                OccupationalTherapy2Manager otm2 = new OccupationalTherapy2Manager();
                int otid = otm2.AddOccupationalTherapy2(occupationalTherapy2ModelDTO);
                if (otid > 0)
                {
                    TempData["Message"] = "Student Occupational Therapy 2 Added Successfuly and OT2 ID is " + otid;
                }
                else
                {
                    TempData["Message"] = "Student Occupational Therapy 2 Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Error From Model !";
            }
            return View();
        }


        public ActionResult PT()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PT(PhysiotherapyModelDTO PhysiotherapyModelDTO)
        {
            if (ModelState.IsValid)
            {
                PhysiotherapyManager pt = new PhysiotherapyManager();
                int ptid = pt.AddPhysiotherapy(PhysiotherapyModelDTO);
                if (ptid > 0)
                {
                    TempData["Message"] = "Student Physiotherapy Added Successfuly and PT ID is " + ptid;
                }
                else
                {
                    TempData["Message"] = "Student  Physiotherapy Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Error From Model !";
            }
            return View();
        }

        [HttpGet]
        public ActionResult BT()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BT(BehavioralTherapyModelDTO behavioralTherapyModelDTO)
        {
            if (ModelState.IsValid)
            {
                BehavioralTherapyManager btm = new BehavioralTherapyManager();
                int btid = btm.AddBehavioraltherapy(behavioralTherapyModelDTO);
                if (btid > 0)
                {
                    TempData["Message"] = "Student Behavioral Therapy Added Successfuly and BT ID is " + btid;
                }
                else
                {
                    TempData["Message"] = "Student Behavioral Therapy Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Error From Model !";
            }
            return View();
        }

        public ActionResult PA()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PA(PsychologicalAssessmentModel PsychologicalAssessment)
        {
            if (ModelState.IsValid)
            {
                PsychologicalAssessmentManager pa = new PsychologicalAssessmentManager();
                int paid = pa.AddPsychologicalAssessment(PsychologicalAssessment);
                if (paid > 0)
                {
                    TempData["Message"] = "Student Psychological Assessment Added Successfuly and PA ID is " + paid;
                }
                else
                {
                    TempData["Message"] = "Student  Psychological Assessment Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Error From Model !";
            }
            return View();
        }

        public ActionResult IQ()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IQ(IntelligenceQuotientModelDTO intelligenceQuotientModelDTO)
        {
            if (ModelState.IsValid)
            {
                IntelligenceQuotientManager iq = new IntelligenceQuotientManager();
                int iqid = iq.AddIntelligenceQuotient(intelligenceQuotientModelDTO);
                if (iqid > 0)
                {
                    TempData["Message"] = "Student IQ Test Added Successfuly and IQ ID is " + iqid;
                }
                else
                {
                    TempData["Message"] = "Student  IQ Test  Not Added !";
                }
            }
            else
            {
                TempData["Message"] = "Error From Model !";
            }
            return View();
        }

        public ActionResult AddIEP(IndividualizedEPlanModelDTO IEPModel)
        {
            var message = string.Empty;

            var IEP = new IndividualizedEPlanManager().AddIEP(IEPModel);

            if (IEP == 1)
            {
                message = ResponseMessage.Success;
            }
            else if (IEP == 2)
            {
                message = ResponseMessage.AlreadyPresent;
            }
            else
            {
                message = ResponseMessage.Error;
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetIEPData()
        {
            IndividualizedEPlanManager iep = new IndividualizedEPlanManager();

            var GRNO = Convert.ToInt32(Request.QueryString["GRNO"]);

            var student = iep.GetStudentById(GRNO);

            if (student != null)
            {
                var performance = new IndividualizedEPlanManager().GetIEPDatabyId(GRNO);
                return Json(new { Student = student, Performance = performance }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Student = "No Student Found" }, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpGet]
        public ActionResult UpdateIEP()
        {
            IndividualizedEPlanManager obj = new IndividualizedEPlanManager();
            var IEP_ID = Convert.ToInt32(Request.QueryString["IEP_ID"]);
            var GR_NO = Convert.ToInt32(Request.QueryString["GRNO"]);
            //var year = Convert.ToBoolean(Request.QueryString["year"]);

            var result = new IndividualizedEPlanManager().GetIEPData(IEP_ID, GR_NO);
            //return Json(new { Student = student, Performance = performance }, JsonRequestBehavior.AllowGet);
            return View(result);

        }

        [HttpPost]
        public ActionResult UpdateIEP(IEPModel iEPModel)
        {
            IndividualizedEPlanManager obj = new IndividualizedEPlanManager();

            //var student = obj.GetStudentById();
            //if (student != null)
            //{
            var performance = new IndividualizedEPlanManager().UpdateIEPData(iEPModel);

            if (performance)
                return RedirectToAction("ViewAllIEP");
            else return View(performance);
            //}

            //else
            //{
            //    return Json(new { Student = "No Student Found" }, JsonRequestBehavior.AllowGet);
            //}
        }

    }
}