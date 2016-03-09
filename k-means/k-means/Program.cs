using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> list = Reading.ReadFile();
            KMean algo = new KMean();
            algo.compute(list);
            Console.ReadKey();
        }
    }
}
