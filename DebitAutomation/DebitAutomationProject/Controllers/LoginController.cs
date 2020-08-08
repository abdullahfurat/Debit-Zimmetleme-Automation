using Debit.Entity;
using Debit.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitAutomationProject.Controllers
{
    public class LoginController : Controller
    {
            EmployeeRepository er = new EmployeeRepository();

            // GET: Login
            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(Employee model)
            {

                bool giris = false;
                foreach (Employee item in er.List().ProcessResult)
                {
                    if (model.Email == item.Email && model.Password == item.Password)
                    {
                        Session["EmployeeID"] = model.EmployeeID;
                        giris = true;
                        break;
                    }
                    else
                    {
                        giris = false;
                    }
                }

                if (giris == true)
                {
                    if (model.RoleId == 1)
                    {
                        return RedirectToAction("List", "Employee", new { area = "Admin" });
                    }
                    else if (model.RoleId == 2)
                    {
                        return RedirectToAction("ListProductByEmployee", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Başarısız";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Message = "Başarısız";
                    return View(model);
                }
            }
        }
}