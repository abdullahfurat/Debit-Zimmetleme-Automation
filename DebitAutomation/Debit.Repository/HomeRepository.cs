using Debit.Common;
using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debit.Repository
{
    public class HomeRepository
    {
        private static DebitEntities db = Tool.GetConection();
        ResultProcess<Product> result = new ResultProcess<Product>();

        public Result<List<Product>> ListProductByEmployee(int id)
        {
            Employee e = db.Employees.SingleOrDefault(emp => emp.EmployeeID == id);
            return result.GetListResult(e.Products.ToList());
        }
    }
}
