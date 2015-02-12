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

        private float mutationChance = 0.7f;
        private float elitism = 0.2f;
        private int numGenerations = 10000;
        private int numUnchanged = 1000;
        private int popSize = 20;
        private int weightLimit = 1000;

        public Form1()
        {
            InitializeComponent();
            engine = new EvolutionEngine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numGenerations = Int32.Parse(textBox4.Text);
            numUnchanged = Int32.Parse(textBox1.Text);
            elitism = (float)Double.Parse(textBox2.Text);
            mutationChance = (float)Double.Parse(textBox3.Text);
            popSize = Int32.Parse(textBox5.Text);
            weightLimit = Int32.Parse(textBox6.Text);

            engine.SetLblGenerations(lblGenerations);
            engine.SetLblUnchanged(lblUnchanged);
            engine.SetLblValue(lblValue);
            engine.SetLblWeight(lblWeight);
            engine.InitPopulation(mutationChance, elitism, popSize, weightLimit);
            engine.SetNumGenerations(numGenerations);
            engine.SetThreshold(numUnchanged);

            engine.Generate();
        }

    }
}
