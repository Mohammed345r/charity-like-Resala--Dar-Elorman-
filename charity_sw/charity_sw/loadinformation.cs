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
    public partial class loadinformation : Form
    {
        OracleDataAdapter adapter;
        DataSet ds;
        OracleCommandBuilder bulder;
        public loadinformation()
        {
            InitializeComponent();
        }

        private void loadinformation_Load(object sender, EventArgs e)
        {

            string queryttString = "select serialNumber ,type_serv ,name_serv , Date_service, org_id_serv from Service   ";
            string ctyonn = "Data Source=orcl;User Id=scott;Password=tiger";

            adapter = new OracleDataAdapter(queryttString, ctyonn);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
           

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             bulder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
           
            MessageBox.Show("All saved");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string queryttString = "select serialNumber ,type_serv ,name_serv , Date_service, org_id_serv from Service where type_serv= :typ   ";
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
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show(this);
        }
    }
}
