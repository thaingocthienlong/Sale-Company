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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bynExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="admin" && txtPassword.Text == "1")
            {
                Adminstrator admin = new Adminstrator();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid user name or password!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
