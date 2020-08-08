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
    public class AdressController : Controller
    {
        // GET: Admin/Adress
        AdressRepository ar = new AdressRepository();
        InstanceResult<Adress> result = new InstanceResult<Adress>();
        EmployeeRepository er = new EmployeeRepository();
        // GET: Admin/Adress
        public ActionResult AddAdress()
        {
            Adress ad = new Adress();
            return View(ad);
        }
        [HttpPost]
        public ActionResult AddAdress(Adress model)
        {
            result.resultint = ar.Insert(model);

            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            result.resultList = ar.List();
            return View(result.resultList.ProcessResult);
        }
        public ActionResult Delete(int id)
        {
            result.resultint = ar.Delete(id);
            return RedirectToAction("List", new { @mesaj = result.resultint.UserMessage });
        }
        public ActionResult Edit(int id)
        {
            result.TResult = ar.GetObjectById(id);
            return View(result.TResult.ProcessResult);
        }
        [HttpPost]
        public ActionResult Edit(Adress model)
        {
            result.resultint = ar.Update(model);
            ViewBag.Mesaj = result.resultint.UserMessage;
            return RedirectToAction("List");
        }
        public ActionResult Adressing(int id)
        {
            AdressViewModel awm = new AdressViewModel();
            List<SelectListItem> empList = new List<SelectListItem>();

            foreach (Employee item in er.List().ProcessResult)
            {
                empList.Add(new SelectListItem
                {
                    Value = item.EmployeeID.ToString(),
                    Text = item.EmployeeName + " " + item.EmployeeSurName
                });
            }

            awm.EmployeeList = empList;
            awm.adr = ar.GetObjectById(id).ProcessResult;
            return View(awm);
        }
        [HttpPost]
        public ActionResult Adressing(AdressViewModel model)
        {
            // Bu kısım yokkende çalışıyor fakat ekstra kendi bir employee ekleyip adressi onunda adress listesine ekliyor.
            /* var emp = from p in model.EmployeeList
                         where p.Selected
                         select p;
             model.emp = (Employee)emp;*/
            result.resultint = ar.Adressing(model.adr.AdressId, model.emp);
            if (result.resultint.ProcessResult > 0)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
    }
}