using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
    public partial class Form2 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder build;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string constr = " User Id=scott; Password=tiger;Data Source=orcl";
            string cmdstr = @"select r.revid, r.reviewdetail,UI.username  from productrequest pr, products p, review r, userinformation UI where pr.requestid= p.fk_request_id and p.productid= r.productrevid and UI.userid= r.usertid and pr.productname=:name";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("name", textBox1.Text);
            ds = new DataSet();
            adapter.Fill(ds);
           dataGridView1.DataSource = ds.Tables[0];
            
            
        }

       
        private void button2_Click_1(object sender, EventArgs e)
        {
         ds = new DataSet();
           adapter.Fill(ds);
            build = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }
        

       
    }
}
