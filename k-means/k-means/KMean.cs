using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class KMean
    {
        public static int nbCluster = 3; //usefull for centroide

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

        public static List<Item> initListItem(int nbItem,int nbVariable )
        {
            List<Item> result = new List<Item>();
            for (int i = 0; i < nbItem; i++)
            {

                Item item = new Item(new List<double>(Enumerable.Repeat(0d,nbVariable)));
                result.Add(item);
            }
            return result;

        }

        public List<Item> CalculCentroide(List<int> cluster, List<Item> items)
        {

            List<Item> result = initListItem(nbCluster, items.ElementAt(0).Variables.Count);

            int nbClusters = cluster.Max() + 1;
            List<int> nbrVariableCuster = new List<int>();



            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items.ElementAt(0).Variables.Count; j++)
                {
                    int currentCluster = cluster.ElementAt(i);
                    Item it = result.ElementAt(currentCluster);
                    it.Variables[j] += items.ElementAt(i).Variables[j];
                }
            }

            var listNbItemPerCluster = cluster.GroupBy(x => x).Select(x => new { value = x, count = x.Count() });
            foreach (var nb in listNbItemPerCluster)
            {
                nbrVariableCuster.Add(nb.count);
            }

            for (int k = 0; k <result.Count; k++)
            {
                for (int l = 0; l < result.ElementAt(k).Variables.Count; l++)
                {
                    result.ElementAt(k).Variables = result.ElementAt(k).Variables / nbrVariableCuster.ElementAt(k); 

                }
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
