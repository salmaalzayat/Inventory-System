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
    public partial class itemsExpiryDate : Form
    {
        Model5 Ent = new Model5();
        public itemsExpiryDate()
        {
            InitializeComponent();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int timeRemaining))
            {
                MessageBox.Show(" enter a valid integer.");
                return;
            }

            DateTime currentDate = DateTime.Now;
            var query = from report in Ent.inventoryReports
                        select new
                        {
                            report.itemName,
                            report.expiry_date,
                            report.production_date
                        };

            var results = query.ToList();
            var filter = results
                .Where(report =>
                    report.expiry_date.HasValue &&
                    ((DateTime)report.expiry_date - currentDate).TotalDays <= timeRemaining &&
                    ((DateTime)report.expiry_date - currentDate).TotalDays >= 0)
                .ToList();

            if (filter.Any())
            {
                dataGridView1.DataSource = filter;
            }
            else
            {
                MessageBox.Show("No items found with this expiry time");
            }
        }
    }
}
