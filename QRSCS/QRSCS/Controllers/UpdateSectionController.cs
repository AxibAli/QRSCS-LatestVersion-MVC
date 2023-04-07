using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRSCS.Models;
using QRSCS.Manager;
using System.IO;

namespace QRSCS.Controllers
{

    public class UpdateSectionController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult AllStudentView()
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            List<NewAdmissionModel> AllStudentView = obj.selectAllAdmission();
            return View(AllStudentView);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult HIView()
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            List<NewAdmissionModel> HIStudentView = obj.selectHI();
            return View(HIStudentView);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult VIView()
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            List<NewAdmissionModel> VIStudentView = obj.selectVI();
            return View(VIStudentView);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IDDView()
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            List<NewAdmissionModel> IDDStudentView = obj.selectIDD();
            return View(IDDStudentView);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult UpdateStudentView(int GR_NO)
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            NewAdmissionModel user = obj.GetStudent(GR_NO);
            if (user == null)
            {
                TempData["Message"] = "Data not Found";
                return RedirectToAction("AllStudentView");
            }

            else
            {
                return View(user);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateStudentView(NewAdmissionModel user)
        {
            if (ModelState.IsValid)
            {

                NewAdmissionManager obj = new NewAdmissionManager();
                user.Updated_By = Convert.ToString(Session["User_ID"]);
                user.Update_Date = DateTime.Now;
                bool check = obj.UpdateStudent(user);
                if (check)
                {
                    TempData["Message"] = "Data Update Successully";
                    return RedirectToAction("AllStudentView");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Data Not Updated";
                return View();
            }
        }
    }

}
