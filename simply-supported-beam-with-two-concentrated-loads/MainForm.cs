using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simply_supported_beam_with_two_concentrated_loads
{
    public partial class MainForm : Form
    {
        SimplySupportedBeamWithTwoConcentratedLoads myBeam;

        public MainForm()
        {
            InitializeComponent();
            myBeam = new SimplySupportedBeamWithTwoConcentratedLoads();
            propertyGrid1.SelectedObject = myBeam;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            double deltaX;
            deltaX = (double)numericUpDown1.Value;
            richTextBox1.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = myBeam.Length;
            myBeam.CaculateR();
            double SF, BM;
            for (double x = 0; x < myBeam.Length; x += deltaX)
            {
                SF = myBeam.GetShearForce(x);
                BM = myBeam.GetBendingMoment(x);
                richTextBox1.AppendText($"x = {x:0.00}  SF = {SF:0.00}  BM = {BM:0.00}\n");
                chart1.Series[0].Points.AddXY(x, SF);
                chart1.Series[1].Points.AddXY(x, BM);
            }
        }
    }
}
