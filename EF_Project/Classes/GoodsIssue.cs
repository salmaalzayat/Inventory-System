namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodsIssue")]
    public partial class GoodsIssue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsIssue()
        {
            GoodsIssueItems = new HashSet<GoodsIssueItem>();
        }

        public int id { get; set; }

        public int? inventory_no { get; set; }

        [Required]
        [StringLength(50)]
        public string permission_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? permission_date { get; set; }

        public int? supplier_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? creationdate { get; set; }

        public int? customer_id { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueItem> GoodsIssueItems { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
