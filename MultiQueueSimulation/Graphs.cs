using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Graphs : Form
    {
        int NumberOfServers;
        Dictionary<int, List<int>> plotting = new Dictionary<int, List<int>>();
        public Graphs(Dictionary<int,List<int>> plot, int ser_num)
        {
            NumberOfServers = ser_num;
            plotting = plot;
            InitializeComponent();
        }

        private void Graphs_Load(object sender, EventArgs e)
        {
            for(int i= 1;i<= NumberOfServers; i++)
            {
                comboBox1.Items.Add("Server :"+i.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            string selected = comboBox1.SelectedItem.ToString();
            string[] arr = new string[2];
            arr = selected.Split(':');

            int ind = int.Parse(arr[1]);
            var original = chart1.Series.Add("Server Graph");
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            try
            {
                for (int i = 0; i < plotting[ind - 1].Count; i++)
                {
                    original.Points.AddXY(plotting[ind - 1][i], 1);
                }
            }
            catch(Exception t)
            {
                MessageBox.Show("Always Idle");
                original.Points.AddXY(0, 0);
            }
        }
    }
}
