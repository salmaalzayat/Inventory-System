using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF_Project
{
    public partial class Model5 : DbContext
    {
        public Model5()
            : base("name=Model5")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<GoodsIssue> GoodsIssues { get; set; }
        public virtual DbSet<GoodsIssueItem> GoodsIssueItems { get; set; }
        public virtual DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public virtual DbSet<GoodsReceiptItem> GoodsReceiptItems { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemTransfer> ItemTransfers { get; set; }
        public virtual DbSet<ItemUnit> ItemUnits { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<inventoryReport> inventoryReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.GoodsIssues)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.customer_id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Inventories)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<GoodsIssue>()
                .Property(e => e.permission_no)
                .IsUnicode(false);

            modelBuilder.Entity<GoodsIssue>()
                .HasMany(e => e.GoodsIssueItems)
                .WithOptional(e => e.GoodsIssue)
                .HasForeignKey(e => e.goods_issue_id);

            modelBuilder.Entity<GoodsReceipt>()
                .Property(e => e.permission_no)
                .IsUnicode(false);

            modelBuilder.Entity<GoodsReceipt>()
                .HasMany(e => e.GoodsReceiptItems)
                .WithOptional(e => e.GoodsReceipt)
                .HasForeignKey(e => e.goods_receipt_id);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.GoodsIssueItems)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.item_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.GoodsReceiptItems)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.item_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ItemTransfers)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.item_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ItemUnits)
                .WithOptional(e => e.Item)
                .HasForeignKey(e => e.item_id);

            modelBuilder.Entity<ItemUnit>()
                .Property(e => e.unit_name)
                .IsUnicode(false);

            modelBuilder.Entity<ItemUnit>()
                .HasMany(e => e.GoodsIssueItems)
                .WithOptional(e => e.ItemUnit)
                .HasForeignKey(e => e.unit_id);

            modelBuilder.Entity<ItemUnit>()
                .HasMany(e => e.GoodsReceiptItems)
                .WithOptional(e => e.ItemUnit)
                .HasForeignKey(e => e.unit_id);

            modelBuilder.Entity<ItemUnit>()
                .HasMany(e => e.ItemTransfers)
                .WithOptional(e => e.ItemUnit)
                .HasForeignKey(e => e.unit_id);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.GoodsIssues)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.supplier_id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.GoodsReceipts)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.supplier_id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.supplier_id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.ItemTransfers)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.supplier_id);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.inventoryName)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.inventoryAddress)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.transactionType)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.itemName)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.itemCode)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.itemUnit)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.supplierName)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<inventoryReport>()
                .Property(e => e.employeeName)
                .IsUnicode(false);
        }
    }
}
