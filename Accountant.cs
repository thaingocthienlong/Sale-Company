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
    public partial class Accountant : Form
    {
        public Accountant()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_P_Dashboard1.Visible=true;
            uC_P_Dashboard1.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pharmacist_Load(object sender, EventArgs e)
        {
            uC_P_Dashboard1.Visible = false;
            uC_P_AddMedicine1.Visible = false;
            uC_P_ViewMedicine1.Visible = false;
            uC_P_UpdateMedicine1.Visible = false;
            uC_P_MedicineValidation1.Visible = false;
            uC_P_SaleMedicine1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uC_P_AddMedicine1.Visible = true;
            uC_P_AddMedicine1.BringToFront();
        }

        private void uC_P_AddMedicine1_Load(object sender, EventArgs e)
        {

        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ViewMedicine1.Visible = true;
            uC_P_ViewMedicine1.BringToFront();
        }

        private void btnModifyMedicine_Click(object sender, EventArgs e)
        {
            uC_P_UpdateMedicine1.Visible = true;
            uC_P_UpdateMedicine1.BringToFront();
        }

        private void btnMedValidation_Click(object sender, EventArgs e)
        {
            uC_P_MedicineValidation1.Visible = true;
            uC_P_MedicineValidation1.BringToFront();
        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uC_P_SaleMedicine1.Visible = true;
            uC_P_SaleMedicine1.BringToFront();
        }
    }
}
