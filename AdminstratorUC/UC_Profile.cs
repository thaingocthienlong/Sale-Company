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
    public partial class UC_Profile : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public UC_Profile()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { lblUserName.Text = value; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Profile_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDateOfBirth.Text;
            String mobile = txtMobile.Text;
            String email = txtEmail.Text;
            String username = lblUserName.Text;
            String pass = txtPassword.Text;

            query = "update users set userRole='" + role + "',name='" + name + "',dob='" + dob + "',mobile='" + mobile + "',email='" + email + "',pass='" + pass + "' where username='" + username + "'";
            fn.setData(query, "Profile Update Successfully.");
        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            query = "select * from users where username = '" + lblUserName.Text + "'";
            ds = fn.GetData(query);
            txtUserRole.Text = ds.Tables[0].Rows[0][1].ToString();
            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDateOfBirth.Text = ds.Tables[0].Rows[0][3].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][7].ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UC_Profile_Enter(this,null);
        }
    }
}
