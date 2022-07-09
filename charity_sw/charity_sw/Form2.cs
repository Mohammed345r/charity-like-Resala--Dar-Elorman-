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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryString = "insert into  Donator values ( :ssd,  :name   , :adress,  :phone ,:email, :password)";
            string conn = "Data Source=orcl;User Id=scott;Password=tiger";

            OracleDataAdapter adapter = new OracleDataAdapter(queryString, conn);
            adapter.SelectCommand.Parameters.Add("ssd", textBox1.Text);
            adapter.SelectCommand.Parameters.Add("name", textBox2.Text);
            adapter.SelectCommand.Parameters.Add("adress", textBox3.Text);
            adapter.SelectCommand.Parameters.Add("phone", textBox4.Text);
            adapter.SelectCommand.Parameters.Add("email", textBox5.Text);
            adapter.SelectCommand.Parameters.Add("password", textBox6.Text);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

            if (ds.Rows.Count!= 1)
            {
                this.Hide();
                Manimenu2 load = new Manimenu2();
                load.Show();
            }
            else
            {
                MessageBox.Show("faild sucess");
                return;

            }




        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            loginform gs = new loginform();
            gs.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            choosepers ff = new choosepers();
            ff.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
