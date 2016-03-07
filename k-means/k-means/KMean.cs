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
            initData();

            List<int> newCluster;
            int nbLoopCompute = 0;
            do
            {
                newCluster = new List<int>();
                seeds = CalculCentroide(cluster, items);
                computeCluster(items, newCluster, seeds);
                if (IsEquals(newCluster, cluster))
                    break;
                cluster = newCluster;
                Console.WriteLine("Calcul cluster " + nbLoopCompute);
                ++nbLoopCompute;
            } while (true);
            cluster = newCluster;
        }

        /// <summary>
        /// Define de k seed
        /// </summary>
        private void initData()
        {
            Random rand = new Random(); // Randomly sort
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

        private static void computeCluster(List<Item> items, List<int> cluster, List<Item> seeds)
        {

            for (int i = 0; i < items.Count; i++)
            {
                cluster.Insert(i, getNearestIndex(seeds, items.ElementAt(i)));
            }
        }

        /// <summary>
        /// Look for the nearest seed from the item.
        /// </summary>
        /// <param name="seeds"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private static int getNearestIndex(List<Item> seeds, Item item)
        {
            List<double> distances = new List<double>();
            for(int i=0; i < seeds.Count;++i)
            {
                distances.Add(item.Distance(seeds.ElementAt(i)));
            }
            return Utils.IndexOfMin(distances);
        }

        public static List<Item> CalculCentroide(List<int> cluster, List<Item> listIris)
        {
            List<Item> result = new List<Item>();
            for (int i = 0; i < 3; ++i)
            {
                int nbInCluser = 0;

                double sumV1 = 0;
                double sumV2 = 0;
                double sumV3 = 0;
                double sumV4 = 0;

                for (int x = 0; x < listIris.Count; ++x)
                {
                    if (cluster.ElementAt(x) == i)
                    {
                        Item curentIris = listIris.ElementAt(x);
                        sumV1 += curentIris.V1;
                        sumV2 += curentIris.V2;
                        sumV3 += curentIris.V3;
                        sumV4 += curentIris.V4;
                        nbInCluser++;
                    }
                }
                result.Add(new Item(sumV1 / nbInCluser, sumV2 / nbInCluser, sumV3 / nbInCluser, sumV4 / nbInCluser, "centroide"));
            }
            return result;
        }

        private static Boolean IsEquals(List<int> list1, List<int> list2)
        {
            if (list1.Count == list2.Count)
            {
                for (int i = 0; i < list1.Count; ++i)
                {
                    if (list1.ElementAt(i) != list2.ElementAt(i))
                        return false;
                }
                return true;
            }
            return false;
        }

        private void computeDispersion(List<int> cluster , List<Item> items, List<Item> seed)
        {
            List<Item> avgItems = new List<Item>();

            for(int i =0; i < items.Count; ++i)
            {
                int clusterItem = cluster.ElementAt(i);
                Item item = avgItems.ElementAt(clusterItem);
            }
        }
    }
}
