using Oracle.DataAccess.Client;
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
    public partial class Form4 : Form
    {
        string ordb = "Data Source=ORCL;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select UserID from Userinformation";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "Select username,email,phonenum from Userinformation where UserID =:id";
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into Userinformation values (:id,:name,:email,:num)";
            cm.Parameters.Add("id", comboBox1.Text);
            cm.Parameters.Add("name", textBox1.Text);
            cm.Parameters.Add("email", textBox2.Text);
            cm.Parameters.Add("num", textBox3.Text);
            int d = cm.ExecuteNonQuery();
            if (d != -1)
            {
                comboBox1.Items.Add(comboBox1.Text);
                MessageBox.Show("New User is added");
            }
        }
    }
}
