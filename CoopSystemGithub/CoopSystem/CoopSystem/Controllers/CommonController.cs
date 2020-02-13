using CoopSystemWebApp.Manager;
using CoopSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoopSystemWebApp.Controllers
{
    public class CommonController : Controller
    {
        readonly CommonManager _commonManager = new CommonManager();

        public ActionResult ExportToExcel(string contentType, string base64, string fileName)
        {
            byte[] fileContents = Convert.FromBase64String(base64);

            return new FileStreamResult(new MemoryStream(fileContents), contentType)
            {
                FileDownloadName = fileName
            };
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteConfirmation()
        {
            return PartialView("~/Views/Shared/_DeleteConfirmation.cshtml");
        }

        public ActionResult ConfirmAction()
        {
            return PartialView("~/Views/Shared/_ConfirmationDialog.cshtml");
        }

        private ActiveUserDataModel ActiveUser
        {
            get { return Session["activeUserData"] as ActiveUserDataModel; }
        }

        public JsonResult GetStatus()
        {
            var roleID = ActiveUser.RoleId;
            var Data = _commonManager.GetStatus(7);
            if (roleID == 1) //master-admin
            {
                Data = _commonManager.GetStatus(0);
            }
            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMember()
        {            
            var Data = _commonManager.GetMember();            
            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMemberEdit()
        {
            var Data = _commonManager.GetMemberEdit();
            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        


        public JsonResult GetRole()
        {
            var Data = _commonManager.GetRole();
            return Json(Data, JsonRequestBehavior.AllowGet);
        }


    }
}