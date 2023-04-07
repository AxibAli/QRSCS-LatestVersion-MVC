using QRSCS.Manager;
using QRSCS.Models;
using QRSCS_Database.QRSCS.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;


namespace QRSCS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(DashboardModel dbm)
        {
            if (User.IsInRole("Admin")) {
            DashboardManager obj = new DashboardManager();
            var request = obj.Cards_for_Admin(dbm);
            return View(request);
            }
            else
            {
                DashboardManager obj = new DashboardManager();
                var request = obj.Cards_for_Teacher(dbm, Convert.ToInt32(Session["User_ID"]));
                if (request == null)
                {
                    Session["not_assigned"] = true;
                    TempData["Message"] = "No Class Assigned Yet";
                    return View();
                }
                else {return View(request); }
                
            }
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult CreateUser()
        {
            New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
            var userroles = db.UserRoles.ToList();
            ViewBag.Roles = new SelectList(userroles,"ID","Role");
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateUser(CreateUserModel Users )
        {
                string Filename = Path.GetFileNameWithoutExtension(Users.Imageofuser.FileName);
                string Extension = Path.GetExtension(Users.Imageofuser.FileName);
                Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
                Users.Picture = "~/ProjectData/" + Filename;
                Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
                Users.Imageofuser.SaveAs(Filename);

                CreateUserManager obj = new CreateUserManager();
                Users.Created_By = Convert.ToString(Session["User_ID"]);
                Users.Creation_Date = DateTime.Now;
                int u_id = obj.AddUser(Users);
                if (u_id > 0)
                {
                    TempData["Success"] = "Success";
                    TempData["Message"] = "User Created Successfuly and User Id is " + u_id;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "User Not Created !";
                    return RedirectToAction("Index");
                }
            }
        [Authorize(Roles = "Admin")]
        public ActionResult ViewAllUser()
        {
            CreateUserManager obj = new CreateUserManager();
            List<CreateUserModel> User = obj.selectUser();
            //return Json(User,JsonRequestBehavior.AllowGet);
            return View(User);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateStudentStatus(bool Status, int userId)
        {
            CreateUserManager obj = new CreateUserManager();
            var response = obj.UpdateStudentStatus(Status, userId);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateUserStatus(bool Status, int userId)
        {
            CreateUserManager obj = new CreateUserManager();
            var response = obj.UpdateUserStatus(Status, userId);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult UpdateUser(int User_ID)
        {
            New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
            CreateUserManager obj = new CreateUserManager();
            CreateUserModel user = obj.GetUser(User_ID);
            var userroles = db.UserRoles.ToList();
            TempData["Date_of_Birth"] = user.DOB.ToString("yyyy-MM-dd");
            var for_picture =  user.Picture.Split('~');
            TempData["Picture"] = for_picture[1];
            user.RolesList = new SelectList(userroles, "ID", "Role");
            if (user == null)
            {
                TempData["Message"] = "Data not Found";
                return RedirectToAction("ViewAllUser");
            }

            else
            {
                return View(user);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateUser(CreateUserModel user)
        {

                if (user.Imageofuser != null)
                {
                    string Filename = Path.GetFileNameWithoutExtension(user.Imageofuser.FileName);
                    string Extension = Path.GetExtension(user.Imageofuser.FileName);
                    Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
                    user.Picture = "~/ProjectData/" + Filename;
                    Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
                    user.Imageofuser.SaveAs(Filename);
                }

                CreateUserManager obj = new CreateUserManager();
                user.Updated_By = Convert.ToString(Session["User_ID"]);
                user.Update_Date = DateTime.Now;

                bool check = obj.UpdateUser(user);
                if (check)
                {
                TempData["Success"] = "Success";
                TempData["Message"] = "User Updated Successfully!";
                return RedirectToAction("Index");
            }
                else
                {

                TempData["Message"] = "User Not Updated!";
                return RedirectToAction("Index");
            }
            }

        [HttpGet]
        public ActionResult ViewAllStudents()
        {
            if (Session["not_assigned"] != null && Convert.ToBoolean( Session["not_assigned"]) == true)
            {
                TempData["Message"] = "No Class Assigned Yet";
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult ViewAllStudent(int classe)
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            List<NewAdmissionModel> User = obj.selectAllAdmission(classe);
            return Json(User, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetTheStudent(int classe)
        {
            NewAdmissionManager obj = new NewAdmissionManager();
            NewAdmissionModel User = obj.GetStudent(classe);
            return Json(User, JsonRequestBehavior.AllowGet);

        }



    }

}