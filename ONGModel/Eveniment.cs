namespace ONGModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Eveniment")]
    public partial class Eveniment
    {
        [Key]
        public int IdEveniment { get; set; }

        public DateTime? Data { get; set; }

        [StringLength(50)]
        public string Invitat { get; set; }

        public int? IdSediu { get; set; }
    }
}
