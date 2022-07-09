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
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            string queryString = "select * from Donator where (name_don = :LOGIN_ID and password_don = :LOGIN_PASSWORD)";
            string conn = "Data Source=orcl;User Id=scott;Password=tiger";

            OracleDataAdapter adapter = new OracleDataAdapter(queryString, conn);
            adapter.SelectCommand.Parameters.Add("LOGIN_ID", textBox1.Text);
            adapter.SelectCommand.Parameters.Add("LOGIN_PASSWORD", textBox2.Text);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            
            if (ds.Rows.Count==1)
            {
                this.Hide();
                Manimenu2 dd = new Manimenu2();
                dd.Show();

            }
            else
            {
                MessageBox.Show("Check your username and password.");
                return;

            }


           





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 ff = new Form2();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            choosepers ff=new choosepers();
            ff.Show();
        }
    }
}
