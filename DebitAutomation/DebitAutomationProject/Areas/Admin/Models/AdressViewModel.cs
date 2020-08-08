using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitAutomationProject.Areas.Admin.Models
{
    public class AdressViewModel
    {
        public Adress adr { get; set; }
        public Employee emp { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
    }
}