using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Reading
    {
        public static List<Item> ReadFile()
        {

            const string f = @".\Qualitative_Bankruptcy.data.txt";
            List<Row> lines = new List<Row>();
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] temp = line.Split(',');
                    lines.Add(new Row(temp));
                }
            }
            Console.WriteLine("file Loaded ! ");
            return lines;
        }
    }
}
