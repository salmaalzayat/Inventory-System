namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class inventoryReport
    {
        [Key]
        [StringLength(150)]
        public string inventoryName { get; set; }

        [StringLength(150)]
        public string inventoryAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? transactionDate { get; set; }

        [StringLength(13)]
        public string transactionType { get; set; }

        [StringLength(200)]
        public string itemName { get; set; }

        [StringLength(100)]
        public string itemCode { get; set; }

        [StringLength(100)]
        public string itemUnit { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? production_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expiry_date { get; set; }

        [StringLength(150)]
        public string supplierName { get; set; }

        [StringLength(150)]
        public string customerName { get; set; }

        [StringLength(100)]
        public string employeeName { get; set; }
    }
}
