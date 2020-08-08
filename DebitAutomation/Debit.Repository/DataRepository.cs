using Debit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debit.Repository
{
    public abstract class DataRepository<T,M>
    {
        public abstract Result<int> Insert(T item);
        public abstract Result<int> Delete(M id);
        public abstract Result<int> Update(T item);
        public abstract Result<List<T>> List();
        public abstract Result<T> GetObjectById(M id);
        public abstract Result<int> Debit(int Id, T item);
    }
}
