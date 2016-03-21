using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Result
    {
        private List<int> cluster;
        private double v;

        public Result(List<int> cluster, double v)
        {
            this.cluster = cluster;
            this.v = v;
        }
        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            strB.Append("(");
                strB.Append(v).Append(" ; ");      
            return strB.ToString();
        }


    }
}
