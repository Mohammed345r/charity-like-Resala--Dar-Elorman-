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
    public partial class veiwService : Form
    {
        OracleDataAdapter adapter;
        DataSet ds;
        public veiwService()
        {
            InitializeComponent();
        }

        private void veiwService_Load(object sender, EventArgs e)
        {
            string queryttString = @"select type_serv ,name_serv , Date_service , name_org  from Service f ,AdminTable g where f.org_id_serv = g.org_id   ";
            string ctyonn = "Data Source=orcl;User Id=scott;Password=tiger";

            adapter = new OracleDataAdapter(queryttString, ctyonn);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryttString = @"select type_serv ,name_serv , Date_service , name_org  from Service f ,AdminTable g where f.org_id_serv = g.org_id and type_serv=:typ  ";
            string ctyonn = "Data Source=orcl;User Id=scott;Password=tiger";

            OracleDataAdapter adaapter = new OracleDataAdapter(queryttString, ctyonn);
            adaapter.SelectCommand.Parameters.Add("typ", textBox1.Text);
            DataSet dss = new DataSet();
            adaapter.Fill(dss);
            dataGridView1.DataSource = dss.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manimenu2 ff = new Manimenu2();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
