namespace Organobusca_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estoque")]
    public partial class Estoque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? Feirante_id { get; set; }

        public int? Produto_id { get; set; }

        public float? preco { get; set; }

        public virtual Feirante Feirante { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
