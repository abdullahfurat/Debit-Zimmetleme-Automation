using Debit.Entity;
using Debit.Repository;
using DebitAutomationProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitAutomationProject.Controllers
{
    public class HomeController : Controller
    {
        HomeRepository hr = new HomeRepository();
        InstanceResult<Product> result = new InstanceResult<Product>();
        // GET: Home
        public ActionResult ListProductByEmployee()
        {
            int id = (int)Session["EmployeeID"];
            result.resultList = hr.ListProductByEmployee(id);
            return View(result.resultList.ProcessResult);
        }
    }
}