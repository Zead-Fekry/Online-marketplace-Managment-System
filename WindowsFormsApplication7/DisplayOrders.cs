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
    public partial class DisplayOrders : Form
    {
        CrystalReport3 crystal2;
        public DisplayOrders()
        {
            InitializeComponent();
        }

        private void DisplayOrders_Load(object sender, EventArgs e)
        {
             crystal2=new CrystalReport3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = crystal2;
        }

    }
}
