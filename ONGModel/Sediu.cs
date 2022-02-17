namespace ONGModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sediu")]
    public partial class Sediu
    {
        [Key]
        public int IdSediu { get; set; }

        [Column(TypeName = "text")]
        public string Adresa { get; set; }
    }
}
