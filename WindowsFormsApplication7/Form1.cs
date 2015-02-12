using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {

        private EvolutionEngine engine;

        private const float mutationChance = 0.7f;
        private const float elitism = 0.2f;
        private const int numGenerations = 10000;
        private const int numUnchanged = 1000;
        private const int popSize = 20;
        private const int weightLimit = 1000;

        public Form1()
        {
            InitializeComponent();
            engine = new EvolutionEngine();
            engine.SetLblGenerations(lblGenerations);
            engine.SetLblUnchanged(lblUnchanged);
            engine.SetLblValue(lblValue);
            engine.SetLblWeight(lblWeight);
            engine.InitPopulation(mutationChance, elitism, popSize, weightLimit);
            engine.SetNumGenerations(numGenerations);
            engine.SetThreshold(numUnchanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            engine.Generate();
        }
    }
}
