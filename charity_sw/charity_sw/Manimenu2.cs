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
    public partial class Manimenu2 : Form
    {
        public Manimenu2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            veiwService veiwService = new veiwService();
            veiwService.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform loginform = new loginform();
            loginform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditProfile ff = new EditProfile();
            ff.Show();
        }
    }
}
