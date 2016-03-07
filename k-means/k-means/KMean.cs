using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class KMean
    {
        int nbCluster = 3;

        /// <summary>
        /// Cluster[i] will be the index of the individu i
        /// </summary>
        List<int> cluster = new List<int>();

        /// <summary>
        /// The clusters
        /// </summary>
        List<Item> seeds = new List<Item>();

        List<Item> items;


        private void compute(List<Item> items)
        {
            this.items = items;
        }

        private void initData()
        {
            Random rand = new Random(); // A tirer aléatoirement
            for (int i = 0; i < nbCluster; i++)
            {
                Item item;
                do
                {
                    item = items.ElementAt(rand.Next(0, items.Count - 1));

                } while (seeds.Contains(item));
                seeds.Add(item);
            }
        }
    }
}
