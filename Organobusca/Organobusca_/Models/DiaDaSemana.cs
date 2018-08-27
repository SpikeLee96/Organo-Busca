namespace Organobusca_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaDaSemana")]
    public partial class DiaDaSemana
    {
        public int id { get; set; }

        public int dia { get; set; }

        public TimeSpan hora_inicio { get; set; }

        public TimeSpan hora_fim { get; set; }

        public int Feira_id { get; set; }

        public virtual Feira Feira { get; set; }
    }
}
