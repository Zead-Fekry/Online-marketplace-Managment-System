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
    public partial class Form5 : Form
    {
        OracleConnection connect;

        string ordb = "data source = orcl; user id = scott; password = tiger;";

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connect = new OracleConnection(ordb);
            connect.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connect;
            command.CommandText = "GETCATEGORYNAME";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("categoryname", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            OracleCommand command = new OracleCommand();
            command.Connection = connect;

            command.CommandText = "GETPRODUCTIDs";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("category", comboBox2.SelectedItem.ToString());
            command.Parameters.Add("productID", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            OracleCommand command = new OracleCommand();
            command.Connection = connect;
            command.CommandText = @"select pr.PRODUCTNAME,pr.description from PRODUCTREQUEST pr,Products p 
                                 where p.productid=:productid and pr.requestid = p.FK_REQUEST_ID";
            command.CommandType = CommandType.Text;
            command.Parameters.Add("productid", comboBox1.SelectedItem.ToString());

            OracleDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = connect;
            command.CommandText = "GetProductPrice";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("productid", Convert.ToInt32(comboBox1.SelectedItem.ToString()));
            command.Parameters.Add("productprice", OracleDbType.Int32, ParameterDirection.Output);

            command.ExecuteNonQuery();
            textBox1.Text = command.Parameters["productprice"].Value.ToString();
           
        }


    }
}
