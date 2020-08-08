using Debit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debit.Common
{
    public class Tool
    {
        public static DebitEntities db = null;
        public static DebitEntities GetConection()
        {
            if (db == null)
            {
                db = new DebitEntities();
            }
            return db;
        }
    }
}
