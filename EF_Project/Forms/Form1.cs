using EF_Project.Forms.Reports;
using EF_Project.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class Form1 : Form
    {
        Model5 Ent = new Model5();
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    DisplayEmployees();
                    break;
                case 2:
                    DisplayItem();
                    break;
                case 5:
                    DisplayInventoryName();
                    DisplaySupplierName();
                    DisplayItemName();
                    break;
                case 6:
                    DisplayInventoryName();
                    DisplaySupplierName();
                    DisplayItemName();
                    DisplayCustomerId();
                    break;
                case 7:
                    DisplaySupplierName();
                    DisplayItemName();
                    DisplayInventory();
                    DisplayInventoryName();
                    break;

            }
        }
        #region Inventory
        private void DisplayEmployees()
        {
            foreach (Employee emp in Ent.Employees)
            {
                comboBox1.Items.Add(emp.id);
            }

        }
        //Display Inventory
        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            var inv = from v in Ent.Inventories select v;
            listBox1.Items.Add("ID\tName\t\tAddress\t\tEmployee ID");
            foreach (var i in inv)
            {
                listBox1.Items.Add(i.inventory_no + "\t" + i.name + "\t" + i.address + "\t" + i.employee_id);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //ADD Inventory
        private void button2_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            if (textBox1.Text != "" && textBox2.Text != ""
                && textBox3.Text != "")
            {
                Inventory inv = Ent.Inventories.Find(int.Parse(textBox1.Text));
                if (inv == null)
                {
                    inventory.inventory_no = int.Parse(textBox1.Text);
                    inventory.name = textBox2.Text;
                    inventory.address = textBox3.Text;
                    inventory.employee_id = int.Parse(comboBox1.Text);
                    Ent.Inventories.Add(inventory);
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
                    MessageBox.Show("Inventory added successfully.");
                }
                else
                {
                    MessageBox.Show("inventory alredy exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Update Inventory
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""
                   && textBox2.Text != ""
                   && textBox3.Text != ""
                   && comboBox1.Text != "")
            {
                Inventory inventory = Ent.Inventories.Find(int.Parse(textBox1.Text));
                if (inventory != null)
                {

                    inventory.name = textBox2.Text;
                    inventory.address = textBox3.Text;
                    inventory.employee_id = int.Parse(comboBox1.Text);
                    Ent.SaveChanges();
                    MessageBox.Show("Inventory Updated successfully.");
                    textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Available Data");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Delete Inventory
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Inventory inventory = Ent.Inventories.Find(int.Parse(textBox1.Text));
                if (inventory != null)
                {

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete Item {textBox1.Text}?"
                        , "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Ent.Inventories.Remove(inventory);
                        Ent.SaveChanges();
                        comboBox1.Items.Remove(textBox1.Text);
                        textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
                        MessageBox.Show("Inventory Deleted successfully.");

                    }
                }
                else
                {
                    MessageBox.Show("Inverntory Not Exist");
                }
            }
            else
            {
                MessageBox.Show(" Empty Inverntory Number");
            }
        }
        #endregion

        #region Item
        private void DisplayItem()
        {
            foreach (Supplier supplier in Ent.Suppliers)
            {
                comboBox2.Items.Add(supplier.id);
            }
            foreach (ItemUnit itemUnit in Ent.ItemUnits)
            {
                comboBox3.Items.Add(itemUnit.unit_name);
            }

        }

        //Display Items
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                listBox2.Items.Clear();
            }
            var items = from i in Ent.Items select i;
            var itemUnit = from u in Ent.ItemUnits select u;
            listBox2.Items.Add("ID\tCode\tName\tProduction Date\tExpiry Date\tSupplier Id");
            foreach (var item in items)
            {
                listBox2.Items.Add($"{item.id}\t{item.code}\t{item.name}\t{item.production_date}\t{item.expiry_date}\t{item.supplier_id}");
            }
            listBox2.Items.Add("________");
            listBox2.Items.Add("Unit:");
            foreach (var unit in itemUnit)
            {
                listBox2.Items.Add($"{unit.unit_name}");
            }
        }
        //Add Items
        private void button6_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            ItemUnit itemUnit = new ItemUnit();
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox2.Text != "")
            {
                Item i = Ent.Items.Find(int.Parse(textBox4.Text));
                if (i == null)
                {
                    item.id = int.Parse(textBox4.Text);
                    item.code = textBox5.Text;
                    item.name = textBox6.Text;
                    item.production_date = dateTimePicker1.Value;
                    item.expiry_date = dateTimePicker2.Value;
                    item.supplier_id = int.Parse(comboBox2.Text);
                    itemUnit.unit_name = comboBox3.Text;
                    itemUnit.item_id = int.Parse(textBox4.Text);
                    Ent.ItemUnits.Add(itemUnit);
                    Ent.Items.Add(item);
                    Ent.SaveChanges();
                    MessageBox.Show("Item added successfully.");
                    textBox4.Text = textBox5.Text = textBox6.Text = comboBox2.Text = comboBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("An item with the same code already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Update Items
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                int itemId = int.Parse(textBox4.Text);
                Item item = Ent.Items.Find(itemId);
                ItemUnit itemUnit = Ent.ItemUnits.FirstOrDefault(u => u.item_id == itemId);

                if (item != null && itemUnit != null)
                {
                    item.name = textBox6.Text;
                    item.production_date = dateTimePicker1.Value;
                    item.expiry_date = dateTimePicker2.Value;
                    item.supplier_id = int.Parse(comboBox2.Text);
                    itemUnit.unit_name = comboBox3.Text;
                    Ent.SaveChanges();
                    textBox4.Text = textBox5.Text = textBox6.Text = comboBox2.Text = comboBox3.Text = "";
                    MessageBox.Show("Item updated successfully.");
                }
                else
                {
                    MessageBox.Show("Item not found.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Delete item
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                int itemId = int.Parse(textBox4.Text);
                Item item = Ent.Items.Find(itemId);

                if (item != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete Item {textBox4.Text}?",
                        "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var ItemUnits = Ent.ItemUnits.Where(u => u.item_id == itemId);
                        Ent.ItemUnits.RemoveRange(ItemUnits);
                        Ent.Items.Remove(item);
                        Ent.SaveChanges();

                        textBox4.Text = textBox5.Text = textBox6.Text = comboBox2.Text = "";
                        MessageBox.Show("Item deleted successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("Item does not exist.");
                }
            }
            else
            {
                MessageBox.Show("Empty item ID.");
            }
        }

        #endregion

        #region Supplier
        //Display Supplier
        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count > 0)
            {
                listBox3.Items.Clear();
            }
            var supplier = from s in Ent.Suppliers select s;
            listBox3.Items.Add("ID\tName\t\tPhone\t\tFax\t\tMail\t\tWebsite");
            foreach (var i in supplier)
            {
                listBox3.Items.Add($"{i.id} \t {i.name}\t {i.phone}\t {i.fax}\t {i.mail}\t {i.website}");
            }
        }
        //ADD Supplier
        private void button11_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            if (textBox7.Text != "" && textBox8.Text != ""
                && textBox9.Text != "" && textBox11.Text != ""
                && textBox11.Text != "" && textBox12.Text != "")
            {
                Supplier s = Ent.Suppliers.Find(int.Parse(textBox7.Text));
                if (s == null)
                {
                    supplier.id = int.Parse(textBox7.Text);
                    supplier.name = textBox8.Text;
                    supplier.phone = textBox9.Text;
                    supplier.fax = textBox10.Text;
                    supplier.mail = textBox11.Text;
                    supplier.website = textBox12.Text;
                    Ent.Suppliers.Add(supplier);
                    Ent.SaveChanges();
                    textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text =
                    textBox11.Text = textBox12.Text = "";
                    MessageBox.Show("Supplier added successfully.");
                }
                else
                {
                    MessageBox.Show("A supplier with the same id already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }

        }
        //Update Supplier
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != ""
              && textBox9.Text != "" && textBox11.Text != ""
              && textBox11.Text != "" && textBox12.Text != "")
            {
                Supplier supplier = Ent.Suppliers.Find(int.Parse(textBox7.Text));
                if (supplier != null)
                {
                    supplier.id = int.Parse(textBox7.Text);
                    supplier.name = textBox8.Text;
                    supplier.phone = textBox9.Text;
                    supplier.fax = textBox10.Text;
                    supplier.mail = textBox11.Text;
                    supplier.website = textBox12.Text;
                    Ent.SaveChanges();
                    textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text =
                    textBox11.Text = textBox12.Text = "";
                    MessageBox.Show("Supplier Updated successfully.");
                }
                else
                {
                    MessageBox.Show("Supplier not found.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Delete Supplier
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                Supplier supplier = Ent.Suppliers.Find(int.Parse(textBox7.Text));
                if (supplier != null)
                {
                    DialogResult result = MessageBox.Show(
                           $"Are you sure you want to delete Item {textBox7.Text}?"
                           , "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Ent.Suppliers.Remove(supplier);
                        Ent.SaveChanges();
                        textBox7.Text = "";
                        MessageBox.Show("Supplier Deleted successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("Supplier Not Exist");
                }
            }
            else
            {
                MessageBox.Show("Empty Supplier ID.");
            }
        }
        #endregion

        #region Customer

        //Display Customer
        private void button16_Click(object sender, EventArgs e)
        {
            if (listBox4.Items.Count > 0)
            {
                listBox4.Items.Clear();
            }
            var customer = from c in Ent.Customers select c;
            listBox4.Items.Add("ID\tName\tPhone\t\tFax\tMail\t\tWebsite");
            foreach (var i in customer)
            {
                listBox4.Items.Add($"{i.id} \t {i.name}\t {i.phone}\t {i.fax}\t {i.mail}\t {i.website}");
            }
        }
        //Add Cutomer
        private void button15_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            if (textBox13.Text != "" && textBox14.Text != ""
               && textBox15.Text != "" && textBox16.Text != ""
               && textBox17.Text != "" && textBox18.Text != "")
            {
                Customer c = Ent.Customers.Find(int.Parse(textBox13.Text));
                if (c == null)
                {
                    customer.id = int.Parse(textBox13.Text);
                    customer.name = textBox14.Text;
                    customer.phone = textBox15.Text;
                    customer.fax = textBox16.Text;
                    customer.mail = textBox17.Text;
                    customer.website = textBox18.Text;
                    Ent.Customers.Add(customer);
                    Ent.SaveChanges();
                    textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text =
                    textBox13.Text = textBox18.Text = "";
                    MessageBox.Show("Cutomer Added successfully.");
                }
                else
                {
                    MessageBox.Show("A customer with the same id already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Update Customer
        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox14.Text != ""
               && textBox15.Text != "" && textBox16.Text != ""
               && textBox17.Text != "" && textBox18.Text != "")
            {
                Customer customer = Ent.Customers.Find(int.Parse(textBox13.Text));
                if (customer != null)
                {

                    customer.id = int.Parse(textBox13.Text);
                    customer.name = textBox14.Text;
                    customer.phone = textBox15.Text;
                    customer.fax = textBox16.Text;
                    customer.mail = textBox17.Text;
                    customer.website = textBox18.Text;
                    Ent.SaveChanges();
                    textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text =
                    textBox13.Text = textBox18.Text = "";
                    MessageBox.Show("Cutomer Updated successfully.");
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        //Delete Customer
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {

                Customer customer = Ent.Customers.Find(int.Parse(textBox13.Text));
                if (customer != null)
                {
                    DialogResult result = MessageBox.Show(
                           $"Are you sure you want to delete Item {textBox13.Text}?"
                           , "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Ent.Customers.Remove(customer);
                        Ent.SaveChanges();
                        textBox13.Text = "";
                        MessageBox.Show("Cutomer Deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Customer Not Exist");
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Customer ID.");
            }

        }

        #endregion

        #region Goods Receipt
        public void DisplayInventoryName()
        {
            foreach (Inventory inv in Ent.Inventories)
            {
                comboBox4.Items.Add(inv.name);
                comboBox7.Items.Add(inv.name);
                comboBox11.Items.Add(inv.name);
                comboBox12.Items.Add(inv.name);
            }
        }
        public void DisplaySupplierName()
        {
            foreach (Supplier supplier in Ent.Suppliers)
            {
                comboBox5.Items.Add(supplier.name);
                comboBox8.Items.Add(supplier.name);
                comboBox14.Items.Add(supplier.name);
            }
        }
        public void DisplayItemName()
        {
            foreach (Item item in Ent.Items)
            {
                comboBox6.Items.Add(item.name);
                comboBox9.Items.Add(item.name);
                comboBox13.Items.Add(item.name);
            }
        }
        //Diplay goodsReceipts and goodsReceiptItems
        private void button20_Click(object sender, EventArgs e)
        {
            if (listBox5.Items.Count > 0 || listBox6.Items.Count > 0)
            {
                listBox5.Items.Clear();
                listBox6.Items.Clear();
            }

            var goodsReceipts = from g in Ent.GoodsReceipts select g;
            listBox5.Items.Add("ID:\t Inventory ID:\tPermission No:\t Permission Date:\t Supplier ID:");
            foreach (var i in goodsReceipts)
            {
                listBox5.Items.Add($"{i.id} \t {i.inventory_no}\t\t{i.permission_no}\t {i.permission_date}\t {i.supplier_id}");
            }

            var goodsReceiptItems = from g in Ent.GoodsReceiptItems select g;
            listBox6.Items.Add("Goods Receipt ID:\t Item ID:\tQuantity:");
            foreach (var i in goodsReceiptItems)
            {
                listBox6.Items.Add($" {i.goods_receipt_id}\t\t{i.item_id}\t {i.quantity}");
            }

        }
        // Add goodsReceipts and goodsReceiptItems
        private void button19_Click(object sender, EventArgs e)
        {

            string selectedInventoryName = comboBox4.SelectedItem?.ToString();
            string selectedSupplierName = comboBox5.SelectedItem?.ToString();
            string selectedItemName = comboBox6.SelectedItem?.ToString();
            string permissionNo = textBox19.Text;
            string quantityText = textBox20.Text;

            if (selectedInventoryName == "" || selectedSupplierName == ""
               || selectedItemName == "" || permissionNo == ""
               || quantityText == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (Ent.GoodsReceipts.Any(gr => gr.permission_no == permissionNo))
            {
                MessageBox.Show("A Goods Receipt with the same permission number already exists.");
                return;
            }

            Inventory selectedInventory = Ent.Inventories.FirstOrDefault(inv => inv.name == selectedInventoryName);
            Supplier selectedSupplier = Ent.Suppliers.FirstOrDefault(supp => supp.name == selectedSupplierName);
            Item selectedItem = Ent.Items.FirstOrDefault(item => item.name == selectedItemName);

            if (selectedInventory == null || selectedSupplier == null || selectedItem == null)
            {
                MessageBox.Show("Selected inventory, supplier, or item not found.");
                return;
            }

            // add a new goods_receipt record
            GoodsReceipt newReceipt = new GoodsReceipt
            {
                inventory_no = selectedInventory.id,
                permission_no = permissionNo,
                permission_date = dateTimePicker5.Value,
                supplier_id = selectedSupplier.id
            };

            Ent.GoodsReceipts.Add(newReceipt);
            Ent.SaveChanges();

            // add a new goods_receipt_items record
            GoodsReceiptItem newReceiptItem = new GoodsReceiptItem
            {
                item_id = selectedItem.id,
                goods_receipt_id = newReceipt.id,
                quantity = int.Parse(quantityText)
            };

            Ent.GoodsReceiptItems.Add(newReceiptItem);
            Ent.SaveChanges();

            MessageBox.Show("Records added successfully.");
            selectedInventoryName = selectedSupplierName =
            selectedItemName = permissionNo = quantityText = "";
        }

        // Update goodsReceipts and goodsReceiptItems
        private void button18_Click(object sender, EventArgs e)
        {
            string selectedInventoryName = comboBox4.SelectedItem?.ToString();
            string selectedSupplierName = comboBox5.SelectedItem?.ToString();
            string selectedItemName = comboBox6.SelectedItem?.ToString();
            string permissionNo = textBox19.Text;
            string quantityText = textBox20.Text;

            if (selectedInventoryName == "" || selectedSupplierName == ""
               || selectedItemName == "" || permissionNo == ""
               || quantityText == "")
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            Inventory selectedInventory = Ent.Inventories.FirstOrDefault(inv => inv.name == selectedInventoryName);
            Supplier selectedSupplier = Ent.Suppliers.FirstOrDefault(supp => supp.name == selectedSupplierName);

            if (selectedInventory != null)
            {

                GoodsReceipt goodsReceipt = Ent.GoodsReceipts.FirstOrDefault(gr => gr.inventory_no == selectedInventory.id);

                if (goodsReceipt != null)
                {
                    goodsReceipt.inventory_no = selectedInventory.id;
                    goodsReceipt.permission_no = permissionNo;
                    goodsReceipt.permission_date = dateTimePicker5.Value;
                    goodsReceipt.supplier_id = selectedSupplier.id;
                    Ent.SaveChanges();
                    MessageBox.Show("Goods Receipt record updated successfully.");
                }
                else
                {
                    MessageBox.Show("Goods Receipt not found.");
                }
            }
            else
            {
                MessageBox.Show("Selected inventory not found.");
            }

            Item selectedItem = Ent.Items.FirstOrDefault(item => item.name == selectedItemName);

            if (selectedItem != null)
            {

                GoodsReceiptItem goodsReceiptItem = Ent.GoodsReceiptItems.FirstOrDefault(grItem => grItem.item_id == selectedItem.id);

                if (goodsReceiptItem != null)
                {
                    goodsReceiptItem.quantity = int.Parse(quantityText);
                    Ent.SaveChanges();
                    MessageBox.Show("Goods Receipt Item record updated successfully.");
                }
                else
                {
                    MessageBox.Show("Goods Receipt Item not found.");
                }
            }
            else
            {
                MessageBox.Show("Selected item not found.");
            }
            selectedInventoryName = selectedSupplierName =
            selectedItemName = permissionNo = quantityText = "";
        }
        #endregion

        #region Goods Issue
        public void DisplayCustomerId()
        {
            foreach (Customer customer in Ent.Customers)
            {
                comboBox10.Items.Add(customer.id);
            }
        }
        //Diplay goodsIssues and goodsIssueItems
        private void button22_Click(object sender, EventArgs e)
        {

            if (listBox7.Items.Count > 0 || listBox8.Items.Count > 0)
            {
                listBox7.Items.Clear();
                listBox8.Items.Clear();
            }

            var goodsIssues = from g in Ent.GoodsIssues select g;
            listBox8.Items.Add("ID:\t Inventory ID:Permission No:\t Permission Date:\t Supplier ID: Customer ID:");
            foreach (var i in goodsIssues)
            {
                listBox8.Items.Add($"{i.id} \t {i.inventory_no}\t{i.permission_no}\t {i.permission_date}\t {i.supplier_id}\t {i.customer_id}");
            }

            var goodsIssueItems = from g in Ent.GoodsIssueItems select g;
            listBox7.Items.Add("Goods Receipt ID:\t Item ID:\tQuantity:");
            foreach (var i in goodsIssueItems)
            {
                listBox7.Items.Add($" {i.goods_issue_id}\t\t{i.item_id}\t {i.quantity}");
            }

        }
        // Add goodsIssues and goodsIssueItems

        private void button21_Click(object sender, EventArgs e)
        {
            string selectedInventoryName = comboBox7.SelectedItem?.ToString();
            string selectedSupplierName = comboBox8.SelectedItem?.ToString();
            string selectedItemName = comboBox9.SelectedItem?.ToString();
            string selectedCustomerId = comboBox10.SelectedItem?.ToString();
            string permissionNo = textBox21.Text;
            string quantityText = textBox22.Text;

            if (selectedInventoryName == "" || selectedSupplierName == ""
               || selectedItemName == "" || permissionNo == "" || selectedCustomerId == ""
               || quantityText == "")
            {
                MessageBox.Show("Please fill in all required fields.");
            }

            if (Ent.GoodsIssues.Any(gr => gr.permission_no == permissionNo))
            {
                MessageBox.Show("A Goods Receipt with the same permission number already exists.");
            }

            Inventory selectedInventory = Ent.Inventories.FirstOrDefault(inv => inv.name == selectedInventoryName);
            Supplier selectedSupplier = Ent.Suppliers.FirstOrDefault(supp => supp.name == selectedSupplierName);
            Item selectedItem = Ent.Items.FirstOrDefault(item => item.name == selectedItemName);

            if (selectedInventory == null || selectedSupplier == null || selectedItem == null)
            {
                MessageBox.Show("Selected inventory, supplier, or item not found.");
            }

            // add a new goods_receipt record
            GoodsIssue newIssues = new GoodsIssue
            {
                inventory_no = selectedInventory.id,
                permission_no = permissionNo,
                permission_date = dateTimePicker5.Value,
                customer_id = int.Parse(selectedCustomerId),
                supplier_id = selectedSupplier.id
            };

            Ent.GoodsIssues.Add(newIssues);
            Ent.SaveChanges();

            // add a new goods_receipt_items record
            GoodsIssueItem newIssuesItem = new GoodsIssueItem
            {
                item_id = selectedItem.id,
                goods_issue_id = newIssues.id,
                quantity = int.Parse(quantityText)
            };

            Ent.GoodsIssueItems.Add(newIssuesItem);
            Ent.SaveChanges();

            MessageBox.Show("Records added successfully.");
            selectedInventoryName = selectedSupplierName =
            selectedItemName = permissionNo = quantityText = selectedCustomerId = "";
        }

        // Update goodsIssues and goodsIssueItems
        private void button17_Click(object sender, EventArgs e)
        {
            string selectedInventoryName = comboBox7.SelectedItem?.ToString();
            string selectedSupplierName = comboBox8.SelectedItem?.ToString();
            string selectedItemName = comboBox9.SelectedItem?.ToString();
            string selectedCustomerId = comboBox10.SelectedItem?.ToString();
            string permissionNo = textBox21.Text;
            string quantityText = textBox22.Text;

            if (selectedInventoryName == "" || selectedSupplierName == ""
               || selectedItemName == "" || permissionNo == "" || selectedCustomerId == ""
               || quantityText == "")
            {
                MessageBox.Show("Please fill in all required fields.");
            }

            Inventory selectedInventory = Ent.Inventories.FirstOrDefault(inv => inv.name == selectedInventoryName);
            Supplier selectedSupplier = Ent.Suppliers.FirstOrDefault(supp => supp.name == selectedSupplierName);

            if (selectedInventory != null)
            {

                GoodsIssue goodsIssues = Ent.GoodsIssues.FirstOrDefault(gr => gr.inventory_no == selectedInventory.id);

                if (goodsIssues != null)
                {
                    goodsIssues.inventory_no = selectedInventory.id;
                    goodsIssues.permission_no = permissionNo;
                    goodsIssues.permission_date = dateTimePicker5.Value;
                    goodsIssues.customer_id = int.Parse(selectedCustomerId);
                    goodsIssues.supplier_id = selectedSupplier.id;
                    Ent.SaveChanges();
                    MessageBox.Show("Goods Receipt record updated successfully.");
                }
                else
                {
                    MessageBox.Show("Goods Receipt not found.");
                }
            }
            else
            {
                MessageBox.Show("Selected inventory not found.");
            }

            Item selectedItem = Ent.Items.FirstOrDefault(item => item.name == selectedItemName);

            if (selectedItem != null)
            {

                GoodsIssueItem goodsIssueItem = Ent.GoodsIssueItems.FirstOrDefault(grItem => grItem.item_id == selectedItem.id);

                if (goodsIssueItem != null)
                {
                    goodsIssueItem.quantity = int.Parse(quantityText);
                    Ent.SaveChanges();
                    MessageBox.Show("Goods Receipt Item record updated successfully.");
                }
                else
                {
                    MessageBox.Show("Goods Receipt Item not found.");
                }
            }
            else
            {
                MessageBox.Show("Selected item not found.");
            }
            selectedInventoryName = selectedSupplierName =
            selectedItemName = permissionNo = quantityText = selectedCustomerId = "";
        }
        #endregion

        #region Transfer Item
        //Display
        private void button23_Click(object sender, EventArgs e)
        {
            if (listBox9.Items.Count > 0)
            {
                listBox9.Items.Clear();
            }

            var itemTransfers = from t in Ent.ItemTransfers
                                join i in Ent.Items on t.item_id equals i.id
                                select new
                                {
                                    t.from_address,
                                    t.to_address,
                                    t.item_id,
                                    t.quantity,
                                    t.supplier_id,
                                    i.production_date,
                                    i.expiry_date
                                };

            listBox9.Items.Add("From \tTo \tItem_id\tQuantity\tSupplier_id\tProduction Date\tExpiry Date");

            foreach (var t in itemTransfers)
            {
                listBox9.Items.Add($"{t.from_address}\t{t.to_address}\t{t.item_id}\t{t.quantity}\t{t.supplier_id}\t{t.production_date}\t\t{t.expiry_date}");
            }
        }

        //Transfer
        private void button24_Click(object sender, EventArgs e)
        {
            if (comboBox11.Text != "" && comboBox12.Text != ""
             && comboBox13.Text != "" && comboBox14.Text != ""
             && textBox25.Text != "")
            {

                string from = comboBox11.SelectedItem.ToString();
                string to = comboBox12.SelectedItem.ToString();
                string itemName = comboBox13.SelectedItem.ToString();
                string supplierName = comboBox14.SelectedItem.ToString();
                int quantity = int.Parse(textBox25.Text);
                if (from == to)
                {
                    MessageBox.Show("From and To addresses cannot be the same.");
                    return;
                }
                var item = Ent.Items.FirstOrDefault(i => i.name == itemName);
                var fromInventory = Ent.Inventories.FirstOrDefault(i => i.name == from);
                var toInventory = Ent.Inventories.FirstOrDefault(i => i.name == to);
                var supplier = Ent.Suppliers.FirstOrDefault(i => i.name == supplierName);

                ItemTransfer itemTransfer = new ItemTransfer
                {
                    from_address = fromInventory.inventory_no,
                    to_address = toInventory.inventory_no,
                    item_id = item.id,
                    quantity = quantity,
                    supplier_id = supplier.id
                };
                Ent.ItemTransfers.Add(itemTransfer);
                Ent.SaveChanges();

                MessageBox.Show("Transfer record added successfully.");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
        #endregion
        #region Reports

        private void DisplayView()
        {

        }
        private void button25_Click(object sender, EventArgs e)
        {
            var form = new Inventory_Report();
            form.Show();

        }
        private void button26_Click(object sender, EventArgs e)
        {
            var form = new item_Report();
            form.Show();
        }
        private void button27_Click(object sender, EventArgs e)
        {
            var form = new ItemMovementReport();
            form.Show();
        }
        private void button28_Click(object sender, EventArgs e)
        {
            var form = new itemsExpiryDate();
            form.Show();
        }
        private void button29_Click(object sender, EventArgs e)
        {
            var form = new ItemsSpecificPeriod();
            form.Show();
        }

        #endregion

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        public void DisplayInventory()
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }


    }
}
