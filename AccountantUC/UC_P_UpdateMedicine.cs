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

    public partial class UC_P_UpdateMedicine : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;

        public UC_P_UpdateMedicine()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMedID.Text != "")
            {
                query = "select * from medic where mid = '"+txtMedID.Text+"'";
                ds = fn.GetData(query);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    txtMedName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMedNumber.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtManuDate.Text = ds.Tables[0].Rows[0][4].ToString();  
                    txtExpDate.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAvailableQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtMedPrice.Text = ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show("No Medicine found!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                clearAll();
            }
        }

        private void clearAll()
        {
            txtMedID.Clear();
            txtMedName.Clear();
            txtMedNumber.Clear();
            txtManuDate.ResetText();
            txtExpDate.ResetText();
            txtAvailableQuantity.Clear();
            txtMedPrice.Clear();
            if (txtAddQuantity.Text != "0")
            {
                txtAddQuantity.Text = "0";
            }
            else
            {
                txtAddQuantity.Text = "0";
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        Int64 totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mname = txtMedName.Text;
            String mnumber = txtMedNumber.Text;
            String mdate = txtManuDate.Text;
            String edate = txtExpDate.Text;
            Int64 quantity = Int64.Parse(txtAvailableQuantity.Text);
            Int64 addQuantity = Int64.Parse(txtAddQuantity.Text);
            Int64 unitPrice = Int64.Parse(txtMedPrice.Text);

            totalQuantity = quantity + addQuantity;
            query = "update medic set mname ='"+mname+"', mnumber = '"+mnumber+"', mDate = '"+mdate+"', eDate = '"+edate+"', quantity="+totalQuantity+", perUnit = "+unitPrice+" where mid = '"+txtMedID.Text+"'";

            fn.setData(query, "Medicine detials updated!");
        }
    }
}
