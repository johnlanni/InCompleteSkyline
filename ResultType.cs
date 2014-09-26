using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCompleteSkylineUI
{
   public class ResultType
    {
        public string CompNum;
        public string CpuTime;
        public ResultType(string compnum, string cputime)
        {
            CompNum = compnum;
            CpuTime = cputime;
        }
    }
}
