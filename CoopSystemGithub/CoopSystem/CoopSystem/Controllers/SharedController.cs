using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoopSystemWebApp.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Header()
        {
            return PartialView("_Header");
        }

        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }

        public ActionResult SideBar()
        {
            return PartialView("_SideBar");
        }

        public ActionResult SideBarPatients()
        {
            return PartialView("_SideBarPatients");
        }

        public ActionResult SideBarSchedule()
        {
            return PartialView("_SideBarSchedule");
        }

        public ActionResult SideBarStatistics()
        {
            return PartialView("_SideBarStatistics");
        }

        public ActionResult SideBarReports()
        {
            return PartialView("_SideBarReports");
        }

        public ActionResult SideBarLettersForPatients()
        {
            return PartialView("_SideBarLettersForPatients");
        }

        public ActionResult SideBarHoursMaintenance()
        {
            return PartialView("_SideBarHoursMaintenance");
        }

        public ActionResult SideBarEvaluationMaintenance()
        {
            return PartialView("_SideBarEvaluationMaintenance");
        }

        public ActionResult SideBarPatientsFirstVisit()
        {
            return PartialView("_SideBarPatientsFirstVisit");
        }

        public ActionResult SideBarOfficeDoctor()
        {
            return PartialView("_SideBarOfficeDoctor");
        }

        public ActionResult SideBarPCPInfo()
        {
            return PartialView("_SideBarPCPInfo");
        }
    }
}