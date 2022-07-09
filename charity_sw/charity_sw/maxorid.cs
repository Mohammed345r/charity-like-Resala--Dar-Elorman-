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

namespace charity_sw
{
    public partial class maxorid : Form
    {
        string odb = "Data Source=orcl;User Id=scott;Password=tiger";
        OracleConnection conn;
       
        public maxorid()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxid1, maxid2;
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "maxorg";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("id", OracleDbType.Int32,ParameterDirection.Output);
            c.ExecuteNonQuery();
            try
            {
                maxid1=Convert.ToInt32(c.Parameters["id"].Value.ToString());
                maxid2 = maxid1 + 1;

                textBox1.Text = maxid2.ToString();


            }
            catch
            {
                maxid2 = 1;
            }
        }

        private void maxorid_Load(object sender, EventArgs e)
        {
            
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            registeradmin ff=new registeradmin();
            ff.Show();
        }
    }
}
