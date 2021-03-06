﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Reading
    {
        public static List<Item> ReadFile()
        {
            const string f = @"..\..\SPORT.txt";
            List<Item> lines = new List<Item>();
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] temp = line.Split(',');

                    double[] temps = new double[temp.Length];

                    int indexSearch = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        string tmp =temp[i].Replace('.', ',');
                        if (!double.TryParse(tmp,out temps[i]))
                            continue;
                        ++indexSearch;
                    }
                    lines.Add(new Item(new List<Double>(temps)));
                }
            }
            Console.WriteLine("file Loaded ! ");

            return lines;
        }
    }
}
