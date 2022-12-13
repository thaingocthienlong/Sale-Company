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
        function fn = new function();
        String query;
        DataSet ds;

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
            query = "select * from users";
            ds = fn.GetData(query);
            if(ds.Tables[0].Rows.Count == 0)
            {
                if(txtUserName.Text == "root" && txtPassword.Text == "root")
                {
                    Administrator admin = new Administrator();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username ='"+txtUserName.Text+"' and pass='"+txtPassword.Text+"'";
                ds= fn.GetData(query);  
                if(ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator") 
                    {
                        Administrator admin = new Administrator(txtUserName.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if(role == "Pharmacist")
                    {
                        Accountant pharm = new Accountant();
                        pharm.Show();
                        this.Hide();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
