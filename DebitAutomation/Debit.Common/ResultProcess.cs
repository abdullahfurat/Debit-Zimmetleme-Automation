using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debit.Common
{
    public class ResultProcess<T>
    {
        public Result<int> GetResult(DebitEntities db)
        {
            Result<int> result = new Result<int>();
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                result.UserMessage = "Basarili";
                result.ısSuccessed = true;
                result.ProcessResult = sonuc;
            }
            else
            {
                result.UserMessage = "Basarisiz";
                result.ısSuccessed = false;
                result.ProcessResult = sonuc;
            }
            return result;
        }
        public Result<List<T>> GetListResult(List<T> data)
        {
            Result<List<T>> result = new Result<List<T>>();
            if (data != null)
            {
                result.UserMessage = "Basarili";
                result.ısSuccessed = true;
                result.ProcessResult = data;
            }
            else
            {
                result.UserMessage = "Islem Basarisiz veri yok";
                result.ısSuccessed = false;
                result.ProcessResult = data;
            }
            return result;
        }
        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();
            if (data != null)
            {
                result.UserMessage = "Basarili";
                result.ısSuccessed = true;
                result.ProcessResult = data;
            }
            else
            {
                result.UserMessage = "Islem basarisiz veri yok";
                result.ısSuccessed = false;
                result.ProcessResult = data;
            }
            return result;
        }
    }
}
