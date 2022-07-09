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
    public partial class Form3 : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger";
        OracleConnection conn;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from AdminTable where (org_id =:id and password_admin=:password)";
            cmd.Parameters.Add("id", textBox1.Text.ToString());
            cmd.Parameters.Add("password", textBox2.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                this.Hide();
                Mainmenu mainmenu = new Mainmenu();
                mainmenu.Show();
            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            choosepers ff = new choosepers();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            registeradmin registeradmin = new registeradmin();
            registeradmin.Show();
        }
    }
}
