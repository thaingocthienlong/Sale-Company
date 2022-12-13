using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLT.PharmacistUC
{
    public partial class UC_P_SaleMedicine : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;
        public UC_P_SaleMedicine()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxMedicine.Items.Clear();
            query = "select mname from medic where mname like '" + txtSearch.Text + "% and eDate >= getdate() and quantity > '0''";
            ds = fn.GetData(query);

            for(int i=0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void UC_P_SaleMedicine_Load(object sender, EventArgs e)
        {

            listBoxMedicine.Items.Clear();
            query = "select mname from medic where eDate >= getdate() and quantity > '0'";
            ds = fn.GetData(query);

            for(int i= 0; i < ds.Tables.Count; i++)
            {
                listBoxMedicine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_SaleMedicine_Load(this, null);
        }

        private void listBoxMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumberOfUnit.Clear();

            String name = listBoxMedicine.GetItemText(listBoxMedicine.SelectedItem);

            txtMedName.Text = name;
            query = "select mid,eDate,perUnit from medic where mname = '"+name+"'";
            ds = fn.GetData(query);
            txtMedID.Text = ds.Tables[0].Rows[0][0].ToString();
            txtExpDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPriceperUnit.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtNumberOfUnit_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberOfUnit.Text != "")
            {
                Int64 unitPrice = Int64.Parse(txtPriceperUnit.Text);
                Int64 noOfUnit = Int64.Parse(txtNumberOfUnit.Text);
                Int64 totalAmount = unitPrice * noOfUnit;
                txtTotalPrice.Text = totalAmount.ToString();
            }
            else
            {
                txtTotalPrice.Clear();
            }
        }

        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity, soldQuantity;

        

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if(txtMedID.Text != "")
            {
                query = "select quantity from medic where mid = '"+txtMedID.Text+"'";
                ds = fn.GetData(query);
                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = quantity - Int64.Parse(txtNumberOfUnit.Text);
                soldQuantity = quantity - newQuantity;

                if(newQuantity >= 0)
                {
                    n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtMedID.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtMedName.Text;
                    guna2DataGridView1.Rows[n].Cells[2].Value = txtExpDate.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value = txtPriceperUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[4].Value = txtNumberOfUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;

                    totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);
                    lblTotal.Text = totalAmount.ToString();
                    query = "update medic set quantity ='" + newQuantity + "' where mid = '" + txtMedID.Text + "'";
                    fn.setData(query, "Medicine Added");
                    query = "update medic set sold ='" + soldQuantity + "' where mid = '" + txtMedID.Text + "'";
                    fn.setData(query, "");
                }
                else
                {
                    MessageBox.Show("Medicine is Out of Stock.\nOnly " + quantity + " left", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clearAll();
                UC_P_SaleMedicine_Load(this, null);
            }
            else
            {
                MessageBox.Show("Select medicine first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        int valueAmount;
        String valueID;
        protected Int64 noOfUnit;

        
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueID = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfUnit = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            }
            catch (Exception)
            {

            }
        }

        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(valueID != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {
                    query = "select quantity from medic where mid = '" + valueID + "'";
                    ds = fn.GetData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfUnit;
                    query = "update medic set quantity = '" + newQuantity + "' where mid = '" + valueID + "'";
                    fn.setData(query, "Medicine removed from cart");
                    totalAmount = totalAmount - valueAmount;
                    lblTotal.Text = totalAmount.ToString();
                }
                UC_P_SaleMedicine_Load(this, null);
            }
        }

        private void btnPurchasePrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Medicine Bill";
            print.SubTitle = String.Format("Store: {0}", txtStore.Text);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total Payable Amount: " + lblTotal.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);
            
            

            totalAmount = 0;
            lblTotal.Text = "VND";
            guna2DataGridView1.DataSource = 0;
        }


        private void clearAll()
        {
            txtMedID.Clear();
            txtMedName.Clear();
            txtExpDate.ResetText();
            txtPriceperUnit.Clear();
            txtNumberOfUnit.Clear();
        }
    }
}
