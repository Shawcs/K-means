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
    }
}
