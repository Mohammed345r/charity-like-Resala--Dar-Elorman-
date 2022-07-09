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
    public partial class registeradmin : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger";
        OracleConnection conn;
        public registeradmin()
        {
            InitializeComponent();
        }

        private void registeradmin_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "insert into AdminTable (org_id,name_org,official_email,password_admin,phone) values(:id,:name,:email,:password,:phone)";
            cmd.Parameters.Add("id", comboBox1.Text.ToString());
            cmd.Parameters.Add("name", textBox2.Text);
            cmd.Parameters.Add("email", textBox4.Text);
            cmd.Parameters.Add("password", textBox5.Text);
            cmd.Parameters.Add("phone", textBox6.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {

                comboBox1.Items.Add(comboBox1.Text);

                this.Hide();
                Mainmenu mainMenu = new Mainmenu();
                mainMenu.Show();
                
            }
            else {
                MessageBox.Show("Charity is  Exist");
            }







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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            maxorid ff = new maxorid();
            ff.Show();
        }
    }
}
