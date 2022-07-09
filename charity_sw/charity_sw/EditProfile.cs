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
    public partial class EditProfile : Form
    {
        string odb = "Data Source=orcl;User Id=scott;Password=tiger";
        OracleConnection conn;
        public EditProfile()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select * from Donator where ssn_d =1568431";
            OracleDataReader r= c.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add ( r[0].ToString());
                textBox2.Text = r[1].ToString();
                textBox3.Text = r[2].ToString();
                textBox4.Text = r[3].ToString();
                textBox5.Text = r[4].ToString();
                textBox6.Text = r[5].ToString();


            }
            r.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "updaaat_don";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            c.Parameters.Add("name_dont", textBox2.Text);
            c.Parameters.Add("Adress_dont", textBox3.Text);
            c.Parameters.Add("phonee_dont", textBox4.Text);
            c.Parameters.Add("Emaill_dont", textBox5.Text);
            c.Parameters.Add("password_doon", textBox6.Text);


             c.ExecuteNonQuery();
            
            

           MessageBox.Show("Your profile  is updated");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manimenu2 ff = new Manimenu2();
            ff.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
