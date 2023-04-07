using QRSCS.Common.BiMonthlyResult;
using QRSCS.Common.FinalResult;
 
using QRSCS.Manager;
using QRSCS.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QRSCS.Controllers
{
 

    public class ResultController : Controller
    {

        // GET: Result
        public ActionResult HIResult()
        {
            return View();
        }

        //public ActionResult Result()
        //{
        //    return View();
        //}


        public ActionResult IDDResult()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add_BM_HIResult(BiMonthlyModel biMonthlyModel)
        {
            if (ModelState.IsValid)
            {
                ResultManager manager = new ResultManager();
                int result = manager.AddBiMonthlyResult(biMonthlyModel);
                if (result == 0) return Json("Admission not Found");
                else if (result == 1) return Json("Result Saved Successfully");
                else if (result == -1) return Json("Result not Saved");
                else return Json("Already Saved for this Year");
            }
            else return Json("Result not Saved");
        }

        [HttpGet]
        public ActionResult GetInfo()
        {
            var id = Convert.ToInt32(Request.QueryString["GRNO"]);
            ResultManager manager = new ResultManager();
            var data = manager.GetStudentInfo(id);
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Add_FT_HIResult(FinalResultModel finalResultModel)
        {
            if (ModelState.IsValid)
            {
                ResultManager manager = new ResultManager();
                int result = manager.AddMidTermResult(finalResultModel);
                if (result == 0) return Json("Admission not Found");
                else if (result == 1) return Json("Result Saved Successfully");
                else if (result == -1) return Json("Result not Saved");
                else return Json("Result Updated");
            }
            else return Json("saved unsuccessfully!");
        }

        [HttpPost]
        public JsonResult IsMidTermPresent(UserResponse response)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var res = db.MidTerm_Result.Any(u => u.Term_Type.Equals(response.Term_Type) && u.GR_NO.Equals(response.GR_NO));
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetHIResult(int GR_NO)
        {

            ResultManager response = new ResultManager();
            var result = response.GetHIResult(GR_NO);
            if (result == null)
            {
                result = null;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult GetHIResult(int id) 
        //{
        //    return Json("");
        //}

        public ActionResult VIResult()
        {
            return View();
        }
    }

    public class UserResponse
    {
        public int GR_NO { get; set; }
        public string Term_Type { get; set; }
    }


}