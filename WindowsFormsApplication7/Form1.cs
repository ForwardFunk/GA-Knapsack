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

        private Population population;

        public Form1()
        {
            InitializeComponent();

            population = new Population("Hello World!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numGenerations = 10000;
            //BackgroundWorker bw = new BackgroundWorker();

            for (int i = 0; i < numGenerations; i++)
            {
                label1.Text = population.Evolution();

            }
            // what to do in the background thread
            /*bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

            });

            bw.RunWorkerAsync();*/
        }
    }
}
