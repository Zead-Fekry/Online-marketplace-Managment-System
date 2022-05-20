using CrystalDecisions.Shared;
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

    public partial class UserRequests : Form
    {
        CrystalReport2 crystal;
       
        public UserRequests()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            crystal = new CrystalReport2();
            foreach (ParameterDiscreteValue value in crystal.ParameterFields[1].DefaultValues)
            {
                comboBox1.Items.Add(value.Value);
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            crystal.SetParameterValue(0,textBox1.Text);
            crystal.SetParameterValue(1, comboBox1.Text);
            
            crystalReportViewer1.ReportSource = crystal;
        
        }

    }
}
