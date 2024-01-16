namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GoodsReceiptItem
    {
        public int id { get; set; }

        public int? goods_receipt_id { get; set; }

        public int item_id { get; set; }

        public int? unit_id { get; set; }

        public int? quantity { get; set; }

        public virtual GoodsReceipt GoodsReceipt { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemUnit ItemUnit { get; set; }
    }
}
