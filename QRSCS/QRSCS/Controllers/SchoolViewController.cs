using QRSCS.Manager;
using QRSCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRSCS.Controllers
{

    public class SchoolViewController : Controller
    {
        public ActionResult AllSpeechTherapy()
        {
            SpeechTherapyAssessmentManager obj = new SpeechTherapyAssessmentManager();
            List<SpeechTherapyAssessmentModel> AllSpeechTherapy = obj.selectStudentSpeechAssessment();
            return View(AllSpeechTherapy);
        }

    }
}