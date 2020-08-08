using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debit.Common;

namespace Debit.Repository
{
    public  class EmployeeRepository:DataRepository<Employee, int>
    {
        public static DebitEntities db = Tool.GetConection();
        ResultProcess<Employee> result = new ResultProcess<Employee>();

        public override Result<int> Debit(int Id, Employee item)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Delete(int id)
        {
            Employee emp = db.Employees.SingleOrDefault(e => e.EmployeeID == id);
            if (emp.Products.Count == 0 && emp.Adresses.Count == 0)
            {
                db.Employees.Remove(emp);
                return result.GetResult(db);
            }
            else
            {
                emp.Adresses.Clear();
                emp.Products.Clear();
                db.Employees.Remove(emp);
                return result.GetResult(db);
            }
        }

        public override Result<Employee> GetObjectById(int id)
        {
            Employee emp = db.Employees.SingleOrDefault(e => e.EmployeeID == id);
            return result.GetT(emp);
        }

        public override Result<int> Insert(Employee item)
        {
            db.Employees.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Employee>> List()
        {
            return result.GetListResult(db.Employees.ToList());
        }

        public override Result<int> Update(Employee item)
        {
            Employee emp = db.Employees.SingleOrDefault(e => e.EmployeeID == item.EmployeeID);
            emp.Email = item.Email;
            emp.EmployeeName = item.EmployeeName;
            emp.EmployeeSurName = item.EmployeeSurName;
            emp.Password = item.Password;
            emp.Phone = item.Phone;
            emp.Salary = item.Salary;
            emp.RoleId = item.RoleId;
            emp.EmployeePhoto = item.EmployeePhoto;
            return result.GetResult(db);
        }
    }
}
