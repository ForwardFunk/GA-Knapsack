using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class Chromosome
    {
        public String code { get; set; }
        private int length;
        public int cost;

        private static Random randInit = new Random();
        private static Random randMut = new Random();
        private static Random randMut2 = new Random();

        public Chromosome(String code)
        {
            this.code = code;
            this.cost = 9999;
            this.length = code.Length;
            this.Randomize();
        }

        public void Randomize() 
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(Convert.ToChar(randInit.Next(256)));
            }

            code = builder.ToString();
        }

        public int Cost(String compareTo)
        {
            int total = 0;

            for (int i = 0; i < length; i++)
            {
                total += Math.Abs(Convert.ToInt32(code.ToCharArray()[i]) - Convert.ToInt32(compareTo.ToCharArray()[i]));
            }

            cost = total;
            return cost;
        }

        public String[] Mate(String partner)
        {
            int pivot = length / 2 - 1;

            String child1 = code.Substring(0, pivot + 1) + partner.Substring(pivot + 1);
            String child2 = partner.Substring(0, pivot + 1) + code.Substring(pivot + 1);

            String [] retVal = {child1, child2};
            return retVal;
        }

        public void Mutate(double chance)
        {
            double calcChance =  randMut.NextDouble();
             if (chance > calcChance)
                return;

            int index = randMut2.Next(length);
            int inc = randMut.NextDouble() > 0.5 ? 1 : -1;

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if (i == index)
                {
                    char current = code.ToCharArray()[i];
                    current += (char) inc;
                    builder.Append(current);
                }
                else
                    builder.Append(code[i]); 
            }

            code = builder.ToString();
        }
    }
}
