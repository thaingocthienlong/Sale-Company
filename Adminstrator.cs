using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLT
{
    public partial class Adminstrator : Form
    {
        public Adminstrator()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login fm = new Login();
            fm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Adminstrator_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void uC_Dashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}
