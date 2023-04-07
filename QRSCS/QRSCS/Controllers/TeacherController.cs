using QRSCS.Manager;
using QRSCS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace QRSCS.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ViewAllTeacher()
        {
            CreateUserManager obj = new CreateUserManager();
            List<CreateUserModel> User = obj.selectTeacher();
             
            return View(User);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewAllTeacherAndAssign()
        {
            CreateUserManager obj = new CreateUserManager();
            List<CreateUserModel> User = obj.selectTeacher();

            return View(User);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AssignTeacher(int User_ID) {
            New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
            var request = db.Assign_Teacher.Where(x => x.User_ID ==  User_ID).FirstOrDefault();
            if (request != null)
            {
                Assign_Teacher_Model assign_Teacher_Model = new Assign_Teacher_Model();
                assign_Teacher_Model.User_ID = request.User_ID;
                assign_Teacher_Model.Class = request.Class;
                assign_Teacher_Model.Section = request.Section;
                return View(assign_Teacher_Model);
            }

            else
            {
                Assign_Teacher_Model assign_Teacher_Model = new Assign_Teacher_Model();
                assign_Teacher_Model.User_ID = User_ID;
                return View(assign_Teacher_Model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AssignTeacher(Assign_Teacher_Model Teacher)
        {
            New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
            var request = db.Assign_Teacher.Where(x => x.User_ID == Teacher.User_ID).FirstOrDefault();
            if(request != null)
            {
                request.Class = Teacher.Class;
                request.Section = Teacher.Section;
                db.SaveChanges();
                TempData["Success"] = "Success";
                TempData["Message"] = "Class has been assigned Succesfully!";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                using (New_QRSCS_DatabaseEntities dab = new New_QRSCS_DatabaseEntities())
                {
                    Assign_Teacher assign_Teacher = new Assign_Teacher();
                    assign_Teacher.User_ID = Teacher.User_ID;
                    assign_Teacher.Section = Teacher.Section;
                    assign_Teacher.Class = Teacher.Class;
                    dab.Assign_Teacher.Add(assign_Teacher);
                    dab.SaveChanges();
                    TempData["Success"] = "Success";
                    TempData["Message"] = "Class has been assigned Succesfully!";
                }
                return RedirectToAction("Index", "Admin");

            }
             
        }
    }
}