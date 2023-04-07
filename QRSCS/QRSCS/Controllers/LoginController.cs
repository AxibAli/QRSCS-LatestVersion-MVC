using QRSCS.Manager;
using QRSCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebGrease;

namespace QRSCS.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel logindata)
        {
            if (ModelState.IsValid)
            {
                LoginManager obj = new LoginManager();
                
                CreateUserModel userdata = obj.checklogin(logindata);
                //issue resolved when providing wrong credentials, result in returning userdata null then exception generates on 
                // userdata.isactive is null == false

                
                if (userdata != null)
                {
                    if (userdata.IsActive == false)
                    {
                        TempData["Message"] = "You have currently disabled, kindly contact your Admin";
                        return View();
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(userdata.Full_Name, false);

                        Session["Full_Name"] = userdata.Full_Name;
                        Session["User_ID"] = userdata.User_ID;
                        Session["UserImage"] = userdata.Picture;
                        Session["Role"] = userdata.Desigation_Role;
                        
                    }
                    //Session["IsLogedIn"] = true;
                    

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Message"] = "UserName Or Password Incorrect";
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Please Enter UserName and Password First ";
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}