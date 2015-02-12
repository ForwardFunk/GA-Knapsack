using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApplication7
{
    class Population
    {
        public List<Element> Data { get; set; }
        
        private List<Chromosome> members;
        private int size;
        private int weightLimit;
        private float elitism;
        private float mutationChance;

        private static Random rand = new Random();

        public Population(int weightLimit, int size, float elitism, float mutationChance)
        {
            this.size = size;
            this.weightLimit = weightLimit;
            this.elitism = elitism;
            this.mutationChance = mutationChance;

            // Initialize element data
            this.Data = new List<Element>();
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                Data = JsonConvert.DeserializeObject<List<Element>>(json);
            }
            
            // Initialize chromosomes
            members = new List<Chromosome>();
            FillMembers();
        }
        
        public void FillMembers()
        {

            int currNumber;
            do
            {
                currNumber = members.Count;
                if (currNumber < size / 3)
                {
                    members.Add(new Chromosome(Data.Count, this, mutationChance));
                }
                else
                {
                    Mate();
                }

            } while (currNumber <= size);

            foreach(Chromosome chr in members)
                chr.Mutate(mutationChance);

        }

        public void Mate()
        {
            int father = rand.Next(members.Count);
            int mother = rand.Next(members.Count);

            while (father == mother)
            {
                mother = rand.Next(members.Count);
            }

            Chromosome[] children = members[father].Mate(members[mother]);
            members.AddRange(children);
        }

        public void CleansePopulation()
        {
            float goalf = (float)members.Count * elitism;
            int goal = (int)goalf;

            while (members.Count > goal)
            {
                members.Remove(members[members.Count - 1]);
            }

        }

        public void SortMembers()
        {
            for (int i = 0; i < members.Count - 1; i++)
                for (int j = i + 1; j < members.Count; j++)
                {
                    if (members[i].Code.Equals(""))
                        return;
                    if (members[j].Code.Equals(""))
                        return;
                    if (members[i].CalcFitness(weightLimit) < members[j].CalcFitness(weightLimit))
                    {
                        String temp = members[i].Code;
                        members[i].Code = members[j].Code;
                        members[j].Code = temp;
                    }

                }
        }

        public int GetTopWeight()
        {
            return members[0].GetWeight();
        }

        public int GetTopValue()
        {
            return members[0].GetValue();
        }

        public int GetTopFitness()
        {
            return members[0].CalcFitness(weightLimit);
        }

        public void Evolution()
        {
            SortMembers();
            CleansePopulation();
            Mate();
            FillMembers();
            SortMembers();            
        }


    }
}
