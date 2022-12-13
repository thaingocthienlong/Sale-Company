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

    public partial class UC_P_Dashboard : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;

        public UC_P_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_P_Dashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        public void loadChart()
        {
            query = "select count(mname) from medic where eDate >= getdate()";
            ds = fn.GetData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Valid Medicine"].Points.AddXY("Medicine Validtity Chart", count);

            query = "select count(mname) from medic where eDate <= getdate()";
            ds = fn.GetData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Expired Medicine"].Points.AddXY("Medicine Validtity Chart", count);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Valid Medicine"].Points.Clear();
            this.chart1.Series["Expired Medicine"].Points.Clear();
            loadChart();
        }
    }
}
