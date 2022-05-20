using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApplication7
{
    
       
    public partial class Form3 : Form
    {
        string ordb = "Data Source=ORCL;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select productid,available from products , productrequest where productname=:name and fk_request_id= requestid";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("Name", txt_Name.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_ID.Text = dr[0].ToString();
                txt_status.Text = dr[1].ToString();
            }
            dr.Close();
        }

       
      
       

        

    }

}
