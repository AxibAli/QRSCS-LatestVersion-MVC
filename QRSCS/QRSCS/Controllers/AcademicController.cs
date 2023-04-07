using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRSCS.Models;
using QRSCS.Manager;
//using QRSCS.Filters;
using System.IO;
using QRSCS_Database.QRSCS.Manager;

namespace QRSCS_Database
{
    //[AuthorizedUser]
    public class AcademicController : Controller
    {
        [HttpGet]
        public ActionResult GetAcademic()
        {
            var GRNO = Convert.ToInt32(Request.QueryString["GRNO"]);

            AcademicManager manager = new AcademicManager();
            var data = manager.GetData(GRNO);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}