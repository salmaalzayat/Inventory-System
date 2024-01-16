namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemUnit")]
    public partial class ItemUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemUnit()
        {
            GoodsIssueItems = new HashSet<GoodsIssueItem>();
            GoodsReceiptItems = new HashSet<GoodsReceiptItem>();
            ItemTransfers = new HashSet<ItemTransfer>();
        }

        public int id { get; set; }

        public int? item_id { get; set; }

        [Required]
        [StringLength(100)]
        public string unit_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueItem> GoodsIssueItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptItem> GoodsReceiptItems { get; set; }

        public virtual Item Item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTransfer> ItemTransfers { get; set; }
    }
}
