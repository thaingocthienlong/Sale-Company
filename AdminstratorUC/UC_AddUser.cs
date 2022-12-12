using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLT.AdminstratorUC
{
    public partial class UC_AddUser : UserControl
    {

        function fn = new function();
        String query;

        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDoB.Text;
            Int64 mobile = Int64.Parse(txtMobileNumber.Text);
            String email = txtEmail.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            try
            {
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values('"+role+"', '"+name+"','"+dob+"',"+mobile+",'"+email+"','"+username+"', '"+password+"')";
                fn.setData(query, "Sign Up Successful");
            }
            catch (Exception)
            {
                MessageBox.Show("Username allready existed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtName.Clear();
            txtDoB.ResetText();
            txtEmail.Clear();
            txtMobileNumber.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            txtUserRole.SelectedIndex = -1;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username='"+txtUsername.Text+"'";
            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pictureBox1.Image = Image.FromFile(@"image\yes.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"image\no.png");
            }
        }
    }
}
