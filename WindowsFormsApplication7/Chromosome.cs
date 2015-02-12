using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class Chromosome
    {
        public String Code { get; set; }
        public int Length { get; set; }
        public int Fitness { get; set; }
        public float mutationChance { get; set; }

        private Population population;
        private static Random Rand = new Random();

        public Chromosome(String Code, Population pop, float mutationChance)
        {
            this.Code = Code;

            this.Length = Code.Length;
            this.Fitness = -1;
            this.population = pop;
            this.mutationChance = mutationChance;
        }

        public Chromosome(int Length, Population pop, float mutationChance)
        {
            this.Length = Length;
            this.Fitness = -1;
            this.population = pop;
            this.mutationChance = mutationChance;
            
            Randomize();
        }

        public void Randomize() 
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Length; ++i)
            {
                char toAppend = Rand.NextDouble() > 0.5 ? '1' : '0';
                builder.Append(toAppend);
            }

            Code = builder.ToString();
        }

        public int CalcFitness(int WeightLimit)
        {
            int total = 0, weight = 0;

            for (int i = 0; i < Length; ++i)
            {
                if (Code[i].Equals('1'))
                {
                    weight += population.Data[i].Weight;
                    total += population.Data[i].Value;
                }
            }

            if (weight > WeightLimit)
            {
                total -= (weight - WeightLimit) * 50;
            }

            Fitness = total;

            return Fitness;
        }

        public Chromosome[] Mate(Chromosome Partner)
        {
            int pivot = Rand.Next(Length);
            String partnerCode = Partner.Code;

            String child1 = Code.Substring(0, pivot + 1) + partnerCode.Substring(pivot + 1);
            String child2 = partnerCode.Substring(0, pivot + 1) + Code.Substring(pivot + 1);

            Chromosome[] retVal = { new Chromosome(child1, population, mutationChance), new Chromosome(child2, population, mutationChance) };
            return retVal;
        }

        public void Mutate(double chance)
        {
            double calcChance =  Rand.NextDouble();
             if (calcChance > chance)
                return;

            int index = Rand.Next(Length);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                if (i == index)
                {
                    char current = Code.ToCharArray()[i];
                    current = current.Equals('1') ? '0' : '1';
                    builder.Append(current);
                }
                else
                    builder.Append(Code[i]); 
            }

            Code = builder.ToString();

        }

        public int GetWeight()
        {
            int weight = 0;

            for (int i = 0; i < Length; ++i)
            {
                weight += Int32.Parse(Code[i].ToString()) * population.Data[i].Weight;
            }

            return weight;
        }

        public int GetValue()
        {
            int val = 0;

            for (int i = 0; i < Length; ++i)
            {
                val += Int32.Parse(Code[i].ToString()) * population.Data[i].Value;
            }

            return val;
        }
    }
}
