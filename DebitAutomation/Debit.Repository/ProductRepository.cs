using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debit.Common;

namespace Debit.Repository
{
    public class ProductRepository : DataRepository<Product, int>
    {
        private static DebitEntities db = Tool.GetConection();
        ResultProcess<Product> result = new ResultProcess<Product>();

        public override Result<int> Debit(int Id, Product item)
        {
            Product p = db.Products.SingleOrDefault(pr => pr.ProductID == Id);
            Employee e = db.Employees.SingleOrDefault(er => er.EmployeeID == item.EmployeeID);
            e.Products.Add(p);
            p.EmployeeID = item.EmployeeID;
            return result.GetResult(db);
        }

        public override Result<int> Delete(int id)
        {
            Product p = db.Products.SingleOrDefault(pr => pr.ProductID == id);
            if (p.EmployeeID != null)
            {
                p.EmployeeID = null;
                db.Products.Remove(p);
            }
            else
            {
                db.Products.Remove(p);
            }
            return result.GetResult(db);
        }

        public override Result<Product> GetObjectById(int id)
        {
            Product p = db.Products.SingleOrDefault(pr => pr.ProductID == id);
            return result.GetT(p);
        }

        public override Result<int> Insert(Product item)
        {
            db.Products.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Product>> List()
        {
            return result.GetListResult(db.Products.ToList());
        }

        public override Result<int> Update(Product item)
        {
            Product p = db.Products.SingleOrDefault(pr => pr.ProductID == item.ProductID);
            p.ProductName = item.ProductName;
            p.Brand = item.Brand;
            p.Description = item.Description;
            p.ProductPhoto = item.ProductPhoto;
            p.EmployeeID = item.EmployeeID;
            return result.GetResult(db);
        }
        /* public Result<int>Waste(int id)
        {
            Product p = db.Products.SingleOrDefault(pr => pr.ProductID == id);
            
            if (p.EmployeeID != null)
            {
                p.EmployeeID = null;
                db.Wasteds.Add(p);
            }
            else
            {
                db.Wasteds.Add(p);
            }
            return result.GetResult(db);
        }*/
    }
}
