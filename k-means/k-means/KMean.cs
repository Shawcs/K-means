using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class KMean
    {
        public static int nbCluster = 3;

        /// <summary>
        /// Cluster[i] will be the index of the individu i
        /// </summary>
        List<int> cluster = new List<int>();

        /// <summary>
        /// The clusters
        /// </summary>
        List<Item> seeds = new List<Item>();

        List<Item> items;

        public double compute(List<Item> data, int nbClutser, int restart)
        {

            //TODO modifier la fct compute du dessous pour faire en sorte de recup aussi les cluster.
            while (restart != 0)
            {


            }
            Console.WriteLine("finish computation finished");

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public double compute(List<Item> items)
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
                {
                    Console.WriteLine("Cluster equals find ! ");
                    break;
                }
                    
                cluster = newCluster;
                Console.WriteLine("Calcul cluster " + nbLoopCompute);
                ++nbLoopCompute;
            } while (true);
            cluster = newCluster;
         
            Result newResult = new Result(cluster, computeDispersion); // here is ok ???
            return computeDispersion(cluster, items, seeds);
        }

        /// <summary>
        /// Asign a cluster for each item.
        /// </summary>
        private void initData()
        {
            int seed = unchecked((int)DateTime.Now.Ticks);
            Random rand = new Random(seed); // Randomly sort
            for (int i = 0; i < items.Count; i++)
            {
                int randIndex = rand.Next(0, nbCluster);
                cluster.Add(randIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="cluster"></param>
        /// <param name="seeds"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbItem"></param>
        /// <param name="nbVariable"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cluster"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<Item> CalculCentroide(List<int> cluster, List<Item> items)
        {

            List<Item> result = initListItem(nbCluster, items.ElementAt(0).Variables.Count);

            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items.ElementAt(0).Variables.Count; j++)
                {
                    int currentCluster = cluster.ElementAt(i);
                    Item it = result.ElementAt(currentCluster);
                    it.Variables[j] += items.ElementAt(i).Variables[j];
                }
            }

            divide(result, cluster);
            Console.WriteLine("Seed : ");
            foreach(Item i in result)
            {
                Console.WriteLine(i.ToString());
            }
            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cluster"></param>
        /// <param name="items"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        private double computeDispersion(List<int> cluster, List<Item> items, List<Item> seed)
        {
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("Empty item");
            }

            List<Item> avgItems = initListItem(seed.Count, items.ElementAt(0).Variables.Count);

            for (int i = 0; i < items.Count; ++i)
            {
                int clusterItem = cluster.ElementAt(i);
                Item item = items.ElementAt(i);
                for (int x = 0; x < item.Variables.Count; ++x)
                {
                    avgItems.ElementAt(clusterItem).Variables[x] += Math.Pow(item.Variables.ElementAt(x) - seed.ElementAt(clusterItem).Variables.ElementAt(x),2.0);
                }
            }
            // divide(avgItems, cluster);

            double total = 0;
            foreach(Item clusterDispersion in avgItems)
            {
                foreach(double variable in clusterDispersion.Variables)
                {
                    total += variable;
                }
            }

            return total;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="cluster"></param>
        private void divide(List<Item> items, List<int> cluster)
        {
            IEnumerable<KeyValuePair<int, int>> listNbItemPerCluster = cluster.GroupBy(x => x).Select(x => new KeyValuePair<int, int>(x.ElementAt(0), x.Count()));
            for (int k = 0; k < listNbItemPerCluster.Count(); k++)
            {
                for (int l = 0; l < items.ElementAt(k).Variables.Count; l++)
                {
                    int index = listNbItemPerCluster.ElementAt(k).Key;
                    items.ElementAt(index).Variables[l] = items.ElementAt(index).Variables.ElementAt(l) / (double)listNbItemPerCluster.ElementAt(k).Value;
                }
            }
        }
    }
}
