namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemTransfer")]
    public partial class ItemTransfer
    {
        public int id { get; set; }

        public int? from_address { get; set; }

        public int? to_address { get; set; }

        public int item_id { get; set; }

        public int? unit_id { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? creationdate { get; set; }

        public int? supplier_id { get; set; }

        public virtual Item Item { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ItemUnit ItemUnit { get; set; }
    }
}
