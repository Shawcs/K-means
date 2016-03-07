﻿using System;
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
            int y = 0;
            do
            {
                newCluster = new List<int>();
                seeds = CalculCentroide(cluster, listIris);
                computeCluster(items, newCluster, seeds);
                if (IsEquals(newCluster, cluster))
                    break;
                cluster = newCluster;
                Console.WriteLine("Calcul cluster " + y);
                ++y;
            } while (true);
            cluster = newCluster;
        }

        /// <summary>
        /// Define de k seed
        /// </summary>
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

        private static void computeCluster(List<Item> listIris, List<int> cluster, List<Item> seeds)
        {

            for (int i = 0; i < listIris.Count; i++)
            {
                cluster.Insert(i, LePlusProche(seeds, listIris.ElementAt(i)));
            }
        }

        private static int LePlusProche(List<Item> seeds, Item iris)
        {
            List<double> distances = new List<double>();
            for(int i=0; i < seeds.Count;++i)
            {
                distances.Add(iris.Distance(seeds.ElementAt(i)));
            }
            distances.Min(x);


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

        public  List<Item> CalculCentroide(List<int> cluster, List<Item> items)
        {
     
            List<Item> result = initListItem(nbCluster, items.ElementAt(0).Variables.Count);

            List <Double> moy = new List<double>();

            for (int i = 0; i < items.Count; ++i)
            {
                for (int j = 0; j < items.ElementAt(0).Variables.Count; j++)
                {

                    moy[j] = items.ElementAt(i).Variables[j];

                }
            }
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
                result.Add(new Item(List des moyenne , "centroide"));
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
    }
}
