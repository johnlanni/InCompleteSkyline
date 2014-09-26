using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCompleteSkylineUI
{
    class DrawObj
    {
        public string DataType;
        public string Increment;
        public LinkedList<ResultList> AlgList;
        public DrawObj()
        {
            AlgList = new LinkedList<ResultList>();
        }

    }
}
