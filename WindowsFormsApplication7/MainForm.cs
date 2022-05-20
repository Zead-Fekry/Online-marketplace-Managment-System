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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 two=new Form2();
            two.Show();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 three = new Form3();
            three.Show();
        }

        

        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRequests four = new UserRequests();
            four.Show();
        }

        private void totalPriceOfEachOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayOrders display = new DisplayOrders();
            display.Show();
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form5 five=new Form5();
            five.Show();
        }

        private void form4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 four = new Form4();
            four.Show();
        }

       


       
    }
}
