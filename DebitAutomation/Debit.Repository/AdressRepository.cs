using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debit.Common;

namespace Debit.Repository
{
    public class AdressRepository : DataRepository<Adress, int>
    {
        private static DebitEntities db = Tool.GetConection();
        ResultProcess<Adress> result = new ResultProcess<Adress>();

        public override Result<int> Debit(int Id, Adress item)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Delete(int id)
        {
            Adress ad = db.Adresses.SingleOrDefault(a => a.AdressId == id);
            if (ad.Employees.Count == 0)
            {
                db.Adresses.Remove(ad);
            }
            else
            {
                ad.Employees.Clear();
                db.Adresses.Remove(ad);
            }
            return result.GetResult(db);
        }

        public override Result<Adress> GetObjectById(int id)
        {
            Adress ad = db.Adresses.SingleOrDefault(a => a.AdressId == id);
            return result.GetT(ad);
        }

        public override Result<int> Insert(Adress item)
        {
            db.Adresses.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Adress>> List()
        {
            return result.GetListResult(db.Adresses.ToList());
        }

        public override Result<int> Update(Adress item)
        {
            Adress ad = db.Adresses.SingleOrDefault(a => a.AdressId == item.AdressId);
            ad.City = item.City;
            ad.Country = item.Country;
            ad.Town = item.Town;
            ad.Street = item.Street;
            return result.GetResult(db);
        }
        public Result<int> Adressing(int id, Employee item)
        {
            Adress ad = db.Adresses.SingleOrDefault(a => a.AdressId == id);
            Employee emp = db.Employees.SingleOrDefault(e => e.EmployeeID == item.EmployeeID);
            ad.Employees.Add(emp);
            emp.Adresses.Add(ad);
            return result.GetResult(db);
        }
    }
}
