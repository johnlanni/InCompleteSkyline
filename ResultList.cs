using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCompleteSkylineUI
{
   public class ResultList
    {
        public string AlgName;
        public LinkedList<ResultType> RList;
        public ResultList()
        {
            RList = new LinkedList<ResultType>();
        }
    }
}
