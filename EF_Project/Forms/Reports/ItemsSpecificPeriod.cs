using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project.Forms.Reports
{
    public partial class ItemsSpecificPeriod : Form
    {
        Model5 Ent = new Model5();
        public ItemsSpecificPeriod()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            var query = from report in Ent.inventoryReports
                        where report.transactionDate >= startDate && report.transactionDate <= endDate
                        select new
                        {
                            report.inventoryName,
                            report.itemName,
                            report.itemCode,
                            report.itemUnit,
                            report.quantity,
                            report.expiry_date,
                            report.production_date,
                            report.supplierName

                        };

            dataGridView1.DataSource = query.ToList();
        }
    }
    
}
