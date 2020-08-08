using Debit.Entity;
using Debit.Repository;
using DebitAutomationProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitAutomationProject.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        EmployeeRepository er = new EmployeeRepository();
        InstanceResult<Employee> result = new InstanceResult<Employee>();
        // GET: Admin/Employee
        public ActionResult List()
        {
            result.resultList = er.List();
            return View(result.resultList.ProcessResult);
        }

        public ActionResult AddEmployee()
        {
            Employee emp = new Employee();
            emp.EmployeePhoto = "DenemeTest";
            return View(emp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddEmployee(Employee model, HttpPostedFileBase photoPath)
        {
            string photoName = "";
            if (photoPath != null && photoPath.ContentLength > 0)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                string path = Server.MapPath("~/Upload/" + photoName);
                photoPath.SaveAs(path);
            }
            model.EmployeePhoto = photoName;
            if (ModelState.IsValid)
            {
                result.resultint = er.Insert(model);
                if (result.resultint.ısSuccessed)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.Mesaj = result.resultint.UserMessage;
                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            result.resultint = er.Delete(id);
            return RedirectToAction("List", new { @mesaj = result.resultint.UserMessage });
        }

        public ActionResult Edit(int id)
        {
            result.TResult = er.GetObjectById(id);
            return View(result.TResult.ProcessResult);
        }
        [HttpPost]
        public ActionResult Edit(Employee model, HttpPostedFileBase photoPath)
        {
            string photoName = model.EmployeePhoto;
            if (photoPath != null && photoPath.ContentLength > 0)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                string path = Server.MapPath("~/Upload/" + photoName);
                photoPath.SaveAs(path);
            }
            model.EmployeePhoto = photoName;
            result.resultint = er.Update(model);
            if (result.resultint.ısSuccessed)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}