using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project.Reports
{
    public partial class Inventory_Report : Form
    {
        Model5 Ent = new Model5();
        public Inventory_Report()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker5.Value.Date; 
            var query = from report in Ent.inventoryReports
                        where report.transactionDate == selectedDate
                        select new
                        {
                            report.inventoryName,
                            report.supplierName,
                            report.inventoryAddress,
                            report.transactionType,
                            report.transactionDate,
                            report.itemName,
                            report.quantity

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void Inventory_Report_Load(object sender, EventArgs e)
        {

        }
    }
}
