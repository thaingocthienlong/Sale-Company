using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLT.PharmacistUC
{

    public partial class UC_P_MedicineValidation : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;

        public UC_P_MedicineValidation()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == 0)
            {
                query = "select * from medic where eDate >= getdate()";
                setDataGridView(query, "Valid Medicine", Color.Black);

            }
            else if(txtCheck.SelectedIndex == 1)
            {
                query = "select * from medic where eDate <= getdate()";
                setDataGridView(query, "Expired Medicine", Color.Red);
            }
            else if (txtCheck.SelectedIndex == 2)
            {
                query = "select * from medic";
                setDataGridView(query, "", Color.Black);
            }
        }

        private void setDataGridView(String query, String lblName, Color col)
        {
            query = "select * from medic";
            ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            setLabel.Text = lblName;
            setLabel.ForeColor = col;
        }

        private void UC_P_MedicineValidation_Load(object sender, EventArgs e)
        {
            setLabel.Text = "";
        }
    }
}
