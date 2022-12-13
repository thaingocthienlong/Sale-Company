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
    public partial class UC_P_AddMedicine : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;
        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMedID.Text!="" && txtMedName.Text!="" && txtMedNumber.Text!="" && txtQuantity.Text!="" && txtPricePerUnit.Text != "") {
                String mid = txtMedID.Text;
                String mname = txtMedName.Text;
                String mnumber = txtMedNumber.Text;
                String mdate = txtManuDate.Text;
                String edate = txtExpDate.Text;
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 pricePerUnit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid,mname,mnumber,mDate,eDate,quantity,perUnit,sold) values ('"+mid+"','"+mname+"','"+mnumber+"','"+mdate+"','"+edate+"',"+quantity+","+pricePerUnit+",'0')";
                fn.setData(query, "Medicine added");
                clearAll();
            }
            else
            {
                MessageBox.Show("Enter all Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtMedID.Clear();
            txtMedName.Clear();
            txtQuantity.Clear();
            txtMedNumber.Clear();
            txtPricePerUnit.Clear();
            txtManuDate.ResetText();
            txtExpDate.ResetText();

        }
    }
}
