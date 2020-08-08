using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debit.Common
{
    public class Result<T>
    {
        public string UserMessage { get; set; }
        public bool ısSuccessed { get; set; }
        public T ProcessResult { get; set; }
    }
}
