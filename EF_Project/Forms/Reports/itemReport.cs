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
    public partial class item_Report : Form
    {
        Model5 Ent = new Model5();
        public item_Report()
        {
            InitializeComponent();
        }
        private void item_Report_Load(object sender, EventArgs e)
        {
            foreach (Inventory inv in Ent.Inventories)
            {
                comboBox1.Items.Add(inv.name);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string selectedInventory = comboBox1.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedInventory))
            {
                MessageBox.Show("Please select a Inventory Name");
                return;
            }

            var query = from report in Ent.inventoryReports
                        where report.inventoryName == selectedInventory
                              && report.transactionDate == selectedDate
                        select new
                        {
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
