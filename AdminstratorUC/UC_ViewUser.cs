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
    public partial class UC_ViewUser : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        String currentUser = "";

        public UC_ViewUser()
        {
            InitializeComponent();
        }

        public String ID
        {
            set { currentUser = value; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '"+txtUsername.Text+"%'";
            ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        String userName;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                if (currentUser != userName)
                {
                    query = "delete from users where username='"+userName+"'";
                    fn.setData(query,"User Record Deleted.");
                    UC_ViewUser_Load(this, null);
                }
                else
                {
                    MessageBox.Show("You are trying to delete your own profile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null);
        }
    }
}
