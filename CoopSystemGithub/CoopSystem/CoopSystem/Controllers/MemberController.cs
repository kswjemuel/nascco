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
    public class MemberController : Controller
    {
        readonly MemberManager _memberManager = new MemberManager();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        private ActiveUserDataModel ActiveUser
        {
            get { return Session["activeUserData"] as ActiveUserDataModel; }
        }
        
        [HttpPost]
        public ActionResult SaveSpouse(SpouseModel model)
        {
            var message = "message";
            var result = "result";
            model.SpouseCreatedByUserId = ActiveUser.UserId;            
            result = _memberManager.SaveSpouse(model);
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

        [HttpPost]
        public ActionResult SaveMember(MemberModel model)
        {
            var message = "message";
            var result = "result";
            model.CreatedByUserId = ActiveUser.UserId;
            result = _memberManager.SaveMember(model);
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

        public ActionResult GetMemberList([DataSourceRequest] DataSourceRequest request)
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var skip = (request.Page - 1) * request.PageSize;
            var take = request.PageSize;
            var total = _memberManager.GetMemberList().Count;

            var result = new DataSourceResult
            {
                Data = _memberManager.GetMemberList(),
                Total = total
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRerencesList([DataSourceRequest] DataSourceRequest request, int? id)
        {
            int Id_ = NullIdProcessor(id);

            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var skip = (request.Page - 1) * request.PageSize;
            var take = request.PageSize;
            var total = _memberManager.ReferencesList(Id_).Count;

            var result = new DataSourceResult
            {
                Data = _memberManager.ReferencesList(Id_),
                Total = total
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSpouseList([DataSourceRequest] DataSourceRequest request, int? id)
        {
            int Id_ = NullIdProcessor(id);
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var skip = (request.Page - 1) * request.PageSize;
            var take = request.PageSize;
            var total = _memberManager.SpouseList(Id_).Count;

            var result = new DataSourceResult
            {
                Data = _memberManager.SpouseList(Id_),
                Total = total
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var memberModel = new MemberModel();            
            return PartialView("~/Views/Member/Create.cshtml", memberModel);
        }

        public ActionResult CreateSpouse(int? id)
        {
            int Id_ = NullIdProcessor(id);
            var memberModel = new SpouseModel();
            memberModel.SpouseMemberId = Id_;
            return PartialView("~/Views/Member/CreateSpouse.cshtml", memberModel);
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
        public ActionResult GetMemberDetail(int Id)
        {
            MemberModel model = new MemberModel();
            model = _memberManager.GetMemberDetail(Id);
            model.MemberIsEditMode = true;
            return PartialView("~/Views/Member/Create.cshtml", model);
        }

        public ActionResult GetSpouseDetail(int Id)
        {
            SpouseModel model = new SpouseModel();
            model = _memberManager.GetSpouseDetail(Id);
            model.SpouseIsEditMode = true;
            return PartialView("~/Views/Member/CreateSpouse.cshtml", model);
        }

        public ActionResult RemoveSpouse(int id)
        {
            string result = string.Empty;
            string message = string.Empty;
            result = _memberManager.RemoveSpouse(id);
            return Json(new { message = message, result = result });

        }

        [HttpPost]
        public ActionResult UpdateSpouse(SpouseModel model)
        {
            var message = "message";
            var result = "result";
            result = _memberManager.UpdateSpouse(model);
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

        [HttpPost]
        public ActionResult Update(MemberModel model)
        {
            var message = "message";
            var result = "result";
            result = _memberManager.Update(model);
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
    }
}