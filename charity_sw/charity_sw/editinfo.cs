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
    public partial class editinfo : Form
    {
        string odb = "Data Source=orcl;User Id=scott;Password=tiger";
        OracleConnection conn;

        public editinfo()
        {
            InitializeComponent();
        }

        private void editinfo_Load(object sender, EventArgs e)
        {

            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = " selsssnd  ";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("id", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = c.ExecuteReader();
            while ( dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELCTMULT";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("ssd",comboBox1.SelectedItem.ToString());
            c.Parameters.Add("namerty",OracleDbType.Int32,ParameterDirection.Output);
            c.Parameters.Add("address", OracleDbType.Int32, ParameterDirection.Output);
            c.Parameters.Add("phonen", OracleDbType.Int32, ParameterDirection.Output);
            c.Parameters.Add("typeserv", OracleDbType.Int32, ParameterDirection.Output);
            
            
                c.ExecuteNonQuery();
            
            textBox1.Text =Convert.ToString( c.Parameters["namerty"].Value.ToString()).ToString();
                textBox2.Text = Convert.ToString(c.Parameters["address"].Value.ToString()).ToString();
                textBox3.Text = Convert.ToString(c.Parameters["phonen"].Value.ToString()).ToString();
                textBox4.Text = Convert.ToString(c.Parameters["typeserv"].Value.ToString()).ToString();*/
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select name_ned , phone_ned , address_ned , Neady_Type   from Needy where ssn_n =:idd";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("idd", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                


            }
            dr.Close();








        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select name_ned , phone_ned , address_ned , Neady_Type   from Needy where ssn_n =:id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", textBox6.Text.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();


            }
            dr.Close();
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "insert into Needy values(:id ,:namee_ned , :phonee_ned , :addreses_ned , :Neaedy_Type,:orgid) ";
            
            c.Parameters.Add("id", comboBox1.Text);
            c.Parameters.Add("namee_ned", textBox1.Text);
            c.Parameters.Add("phonee_ned", textBox2.Text);
            c.Parameters.Add("addreses_ned", textBox3.Text);
            c.Parameters.Add("Neaedy_Type", textBox4.Text);
            c.Parameters.Add("orgid", textBox5.Text);
            int r = c.ExecuteNonQuery();
            if (r !=-1)
            {
                comboBox1.Items.Add(comboBox1.Text.ToString());
                MessageBox.Show("The Neady is Added");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "update  Needy set name_ned= :namee_ned , phone_ned=:phonee_ned , address_ned=:addreses_ned , Neady_Type=:Neaedy_Type where ssn_n=:id ";

           
            c.Parameters.Add("namee_ned", textBox1.Text);
            c.Parameters.Add("phonee_ned", textBox2.Text);
            c.Parameters.Add("addreses_ned", textBox3.Text);
            c.Parameters.Add("Neaedy_Type", textBox4.Text);
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
          
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                
                MessageBox.Show("The Neady is Modefied");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(odb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "Delete  from Needy where ssn_n=:id ";
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("The Neady is Removed");
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainmenu mainmenu = new Mainmenu(); 
            mainmenu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
