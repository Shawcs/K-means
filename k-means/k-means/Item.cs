using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Item
    {
        private List<double> variables;

        public List<double> Variables
        {
            get
            {
                return variables;
            }

            set
            {
                variables = value;
            }
        }

        public Item(List<double> variables)
        {
            this.variables = variables;
        }

        /// <summary>
        /// Compute the distance between two items based on their variables.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Distance(Item b)
        {
            double total = 0;
            for(int i=0; i < variables.Count; ++i)
            {
                total += Math.Pow(variables.ElementAt(i) - b.Variables.ElementAt(0),2.0);
            }
            return Math.Sqrt(total);
        }

        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            strB.Append("(");

            foreach(double b in variables)
            {
                strB.Append(b).Append(" ; ");
            }
            return strB.ToString();
        }
    }
}
