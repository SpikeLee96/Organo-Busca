namespace Organobusca_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Preferencia")]
    public partial class Preferencia
    {
        public int id { get; set; }

        public int? Produto_id { get; set; }

        public int? Cliente_id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
