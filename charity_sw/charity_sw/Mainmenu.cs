using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace charity_sw
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loadinformation log =new loadinformation();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            editinfo Editinfo = new editinfo();
            Editinfo.Show();
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

        private void Mainmenu_Load(object sender, EventArgs e)
        {

        }
    }
}
