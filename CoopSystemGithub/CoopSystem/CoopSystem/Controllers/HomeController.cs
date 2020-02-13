using CoopSystemWebApp.DB;
using CoopSystemWebApp.Helper;
using CoopSystemWebApp.Manager;
using CoopSystemWebApp.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoopSystemWebApp.Controllers
{
    public class HomeController : Controller
    {
        //readonly CommercialManager _commercialManager = new CommercialManager();        
        //readonly GroupManager _groupManager = new GroupManager();

        readonly UserManager _userManager = new UserManager();
        

        public ActionResult Index()
        {
            //var user = ActiveUser.FullName;
            return View();
        }

        private ActiveUserDataModel ActiveUser
        {
            get { return Session["activeUserData"] as ActiveUserDataModel; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult GetCommercialList([DataSourceRequest] DataSourceRequest request)
        //{
        //    if (request.PageSize == 0)
        //    {
        //        request.PageSize = 10;
        //    }
        //    var skip = (request.Page - 1) * request.PageSize;
        //    var take = request.PageSize;
        //    var total = _commercialManager.GetUserCommercialList("Active").Count;

        //    var result = new DataSourceResult
        //    {
        //        Data = _commercialManager.GetUserCommercialList("Active"),
        //        Total = total
        //    };
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}