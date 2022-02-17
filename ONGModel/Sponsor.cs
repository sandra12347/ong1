namespace ONGModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sponsor")]
    public partial class Sponsor
    {
        [Key]
        public int IdSponsor { get; set; }

        [StringLength(50)]
        public string Nume { get; set; }

        [Column(TypeName = "text")]
        public string Adresa { get; set; }

        public int? Suma { get; set; }
    }
}
