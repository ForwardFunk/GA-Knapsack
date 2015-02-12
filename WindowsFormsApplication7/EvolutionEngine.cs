using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    class EvolutionEngine
    {
        private int threshold;
        private int numGenerations;
        private Label lblWeight;
        private Label lblValue;
        private Label lblUnchanged;
        private Label lblGenerations;
        private Population pop;

        public void SetLblWeight(Label lblWeight)
        {
            this.lblWeight = lblWeight;
        }
        public void SetLblValue(Label lblValue)
        {
            this.lblValue = lblValue;
        }
        public void SetLblUnchanged(Label lblUnchanged)
        {
            this.lblUnchanged = lblUnchanged;
        }
        public void SetLblGenerations(Label lblGenerations)
        {
            this.lblGenerations = lblGenerations;
        }

        public void SetThreshold(int threshold)
        {
            this.threshold = threshold;
        }

        public void SetNumGenerations(int num)
        {
            this.numGenerations = num;
        }

        public void InitPopulation(float mutChance, float elitism, int size, int weightLimit)
        {
            pop = new Population(weightLimit, size, elitism, mutChance);
            pop.Evolution();
        }

        public void Generate()
        {
            int unchanged = 0;
            int numGen = 0;

            while (numGen < numGenerations && unchanged < threshold)
            {
                int lastScore = pop.GetTopFitness();
                pop.Evolution();
                if (pop.GetTopFitness() <= lastScore)
                {
                    unchanged++;
                }
                else
                {
                    unchanged = 0;
                }

                lblGenerations.Text = numGen.ToString();
                lblGenerations.Update();
                lblUnchanged.Text = unchanged.ToString();
                lblUnchanged.Update();
                lblValue.Text = pop.GetTopValue().ToString();
                lblValue.Update();
                lblWeight.Text = pop.GetTopWeight().ToString();
                lblWeight.Update();

                numGen++;
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
