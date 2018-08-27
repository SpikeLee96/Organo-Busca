namespace Organobusca_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avaliacao")]
    public partial class Avaliacao
    {
        public int id { get; set; }

        public int? Cliente_id { get; set; }

        public int? Feirante_id { get; set; }

        public string comentario { get; set; }

        public int? pontuacao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Feirante Feirante { get; set; }
    }
}
