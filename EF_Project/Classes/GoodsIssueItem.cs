namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GoodsIssueItem
    {
        public int id { get; set; }

        public int? goods_issue_id { get; set; }

        public int item_id { get; set; }

        public int? unit_id { get; set; }

        public int? quantity { get; set; }

        public virtual GoodsIssue GoodsIssue { get; set; }

        public virtual Item Item { get; set; }

        public virtual ItemUnit ItemUnit { get; set; }
    }
}
