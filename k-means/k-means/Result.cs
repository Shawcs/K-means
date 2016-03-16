using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Result
    {
        private List<int> Cluster;
        private double Dispersion;


        Result (List<int> Cluster, double Dispersion)
        {
            this.Cluster = Cluster;
            this.Dispersion = Dispersion;

        }


    }
}
