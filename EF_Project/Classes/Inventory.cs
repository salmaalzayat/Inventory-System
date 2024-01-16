namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        public int id { get; set; }

        public int? inventory_no { get; set; }

        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [StringLength(150)]
        public string address { get; set; }

        public int? employee_id { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
