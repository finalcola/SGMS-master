namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Status")]
    public partial class Status
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(20)]
        public string courseid { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        [StringLength(2)]
        public string global_status { get; set; }

    }
}
