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
    public class UserController : Controller
    {
        readonly UserManager _userManager = new UserManager();
        readonly ResultHelper _resultHelper = new ResultHelper();

        
        public ActionResult RemoveUser(int id)
        {
            string result = string.Empty;
            string message = string.Empty;
            result = _userManager.RemoveUser(id);
            return Json(new { message = message, result = result });

        }

        [HttpPost]
        public ActionResult Update(UserModel model)
        {
            var message = "message";
            var result = "result";
            result = _userManager.Update(model);
            if (model != null && ModelState.IsValid)
            {
                message = result;
            }
            else
            {
                message = ModelState.ModelErrors();
            }
            return Json(new { message = message, result = result });
        }

        public ActionResult GetUserDetail(int Id)
        {
            UserModel model = new UserModel();
            model = _userManager.GetUserDetail(Id);
            model.UserIsEditMode = true;
            return PartialView("~/Views/User/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Save(UserModel model)
        {
            var message = "message";
            var result = "result";
            model.CreatedByUserId = ActiveUser.UserId;
            model.Password = _userManager.GetEmployeeId(model.UserMemberId).ToString();
            result = _userManager.Save(model);
            if (model != null && ModelState.IsValid)
            {
                message = result;
            }
            else
            {
                message = ModelState.ModelErrors();
            }

            return Json(new { message = message, result = result });
        }

        
        

        public int NullIdProcessor(int? id)
        {
            int Id_ = 0;
            if (id != null)
            {
                Id_ = int.Parse(id.ToString());
            }
            return Id_;
        }

        public ActionResult ChangePassword()
        {            
            var model = new UserModel();
            model.UserId = ActiveUser.UserId;
            model.Username = ActiveUser.UserName;
            return PartialView("~/Views/User/ChangePassword.cshtml", model);
        }

        [HttpPost]
        public ActionResult ReplacePassword(UserModel model)
        {
            var message = "message";
            var result = "result";
            var checking = _userManager.CheckPassword(ActiveUser.UserName, model.OldPassword);
            if (checking != _resultHelper.Success()){
                result = "Old password is invalid.";
                message = result;
            }
            else if(model != null && ModelState.IsValid)
            {
                result = _userManager.ChangePassword(model);
                message = result;
            }
            else
            {
                message = ModelState.ModelErrors();
            }
                        
            

            return Json(new { message = message, result = result });
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            return PartialView("~/Views/User/Create.cshtml", model);
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetUserList([DataSourceRequest] DataSourceRequest request)
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var skip = (request.Page - 1) * request.PageSize;
            var take = request.PageSize;
            var total = _userManager.GetUserList().Count;

            var result = new DataSourceResult
            {
                Data = _userManager.GetUserList(),
                Total = total
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(UserModel model)
        {
            var dataSession = SetSessionData(model.Username, model.Password);
            if(dataSession == null)
            {
                ViewBag.Error = "Invalid credentials. Please try again.";
                return View("Index");
            }
            else
            {                
                return RedirectToAction("Index", "Home");
            }
            
        }

        private ActiveUserDataModel ActiveUser
        {
            get { return Session["activeUserData"] as ActiveUserDataModel; }
        }

        public string SetSessionData(string username, string password)
        {
            string result = null;
            var userInfo = _userManager.CheckRecord(username, password);
            if (userInfo != null)
            {
                userInfo.UserId = userInfo.UserId;
                userInfo.FullName = userInfo.FullName;
                userInfo.UserName = userInfo.UserName;
                userInfo.RoleId = userInfo.RoleId;
                userInfo.RoleName = userInfo.RoleName;
                userInfo.IsAuthenticated = true;
                Session["activeUserData"] = userInfo;
                result = _resultHelper.Success();
            }
            return result;
        }

        public ActionResult Logout()
        {            
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }
    }


}