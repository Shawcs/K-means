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
        private Func<List<int>, List<Item>, List<Item>, double> computeDispersion;
        private double Dispersion;

        public Result(List<int> cluster, Func<List<int>, List<Item>, List<Item>, double> computeDispersion)
        {
            Cluster = cluster;
            this.computeDispersion = computeDispersion;
        }

        Result (List<int> Cluster, double Dispersion)
        {
            this.Cluster = Cluster;
            this.Dispersion = Dispersion;
        }


    }
}
