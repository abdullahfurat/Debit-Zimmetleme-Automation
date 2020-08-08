using Debit.Entity;
using Debit.Repository;
using DebitAutomationProject.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitAutomationProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        ProductRepository pr = new ProductRepository();
        EmployeeRepository er = new EmployeeRepository();
        InstanceResult<Product> result = new InstanceResult<Product>();
        // GET: Admin/Product
        public ActionResult AddProduct()
        {
            ProductViewModel pwm = new ProductViewModel();
            List<SelectListItem> EmpList = new List<SelectListItem>();
            foreach (Employee item in er.List().ProcessResult)
            {
                EmpList.Add(new SelectListItem { Value = item.EmployeeID.ToString(), Text = item.EmployeeName + " " + item.EmployeeSurName });
            }
            pwm.EmployeeList = EmpList;
            pwm.Product = null;
            return View(pwm);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model, HttpPostedFileBase photo)
        {
            string PhotoName = "";
            if (photo != null && photo.ContentLength > 0)
            {
                PhotoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                string path = Server.MapPath("~/Upload/" + PhotoName);
                photo.SaveAs(path);
            }
            model.Product.ProductPhoto = PhotoName;
            result.resultint = pr.Insert(model.Product);
            if (result.resultint.ProcessResult > 0)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }
        public ActionResult List()
        {
            result.resultList = pr.List();
            return View(result.resultList.ProcessResult);
        }
        public ActionResult Delete(int id)
        {
            result.resultint = pr.Delete(id);
            return RedirectToAction("List", new { @m = result.resultint.UserMessage, @id = id });
        }
        public ActionResult Edit(int id)
        {
            ProductViewModel pwm = new ProductViewModel();
            List<SelectListItem> empList = new List<SelectListItem>();

            foreach (Employee item in er.List().ProcessResult)
            {
                empList.Add(new SelectListItem { Value = item.EmployeeID.ToString(), Text = item.EmployeeName + " " + item.EmployeeSurName });
            }

            pwm.EmployeeList = empList;
            pwm.Product = pr.GetObjectById(id).ProcessResult;
            return View(pwm);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel model, HttpPostedFileBase photo)
        {
            string photoName = model.Product.ProductPhoto;
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string ext = Path.GetExtension(photo.FileName);
                    photoName = Guid.NewGuid().ToString().Replace("-", "");
                    if (ext == ".jpg")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".png")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".bmp")
                    {
                        photoName += ext;
                    }
                    else
                    {
                        ViewBag.Mesaj = "Lütfen .jpg,.png,.bmp tipinde  resim yükleyiniz.";
                        return View(model);
                    }
                    string path = Server.MapPath("~/Upload/" + photoName);
                    photo.SaveAs(path);
                }
            }
            model.Product.ProductPhoto = photoName;
            result.resultint = pr.Update(model.Product);
            if (result.resultint.ProcessResult > 0)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Debit(int id)
        {
            ProductViewModel pwm = new ProductViewModel();
            List<SelectListItem> empList = new List<SelectListItem>();
            foreach (Employee item in er.List().ProcessResult)
            {
                empList.Add(new SelectListItem { Value = item.EmployeeID.ToString(), Text = item.EmployeeName + " " + item.EmployeeSurName });
            }
            pwm.EmployeeList = empList;
            pwm.Product = pr.GetObjectById(id).ProcessResult;
            return View(pwm);
        }
        [HttpPost]
        public ActionResult Debit(ProductViewModel model)
        {
            result.resultint = pr.Debit(model.Product.ProductID, model.Product);
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