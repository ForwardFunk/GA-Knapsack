using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class Population
    {
        private Chromosome[] members;
        private String goal;
        private int population;

        public Population(String goal)
        {
            this.goal = goal;
            this.population = 10;

            members = new Chromosome[10];
            for (int i = 0; i < population; ++i)
            {
                members[i] = new Chromosome(goal);
            }
        }

        public void SortMembers()
        {
            for (int i = 0; i < population - 1; i++)
                for (int j = i+1; j < population; j++)
                {
                    if (members[i].Cost(goal) > members[j].Cost(goal))
                    {
                        String temp = members[i].code;
                        members[i].code = members[j].code;
                        members[j].code = temp;
                    }

                }
        }

        public String Evolution()
        {
           SortMembers();
           String child1, child2;

           child1 = members[0].Mate(members[1].code)[0];
           child2 = members[0].Mate(members[1].code)[1];

           members[population - 1].code = child2;
           members[population - 2].code = child1;

           SortMembers();

           for (int i = 0; i < population; i++)
           {
               members[i].Mutate(0.5);
           }

           SortMembers();
           
           return members[0].code;
            
        }

    }
}
