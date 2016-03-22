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
        private double dispersion;

        public Result(List<int> cluster, double v)
        {
            this.cluster = cluster;
            this.Dispersion = v;
        }

        public double Dispersion
        {
            get
            {
                return dispersion;
            }

            set
            {
                dispersion = value;
            }
        }

        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            strB.Append("(");
                strB.Append(Dispersion).Append(" ; ");      
            return strB.ToString();
        }
    }
}
